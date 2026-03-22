using org.mariuszgromada.math.mxparser;
using Punto_Fijo_1.modelo;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Punto_Fijo_1.modelo
{
    public class DespejadorAutomatico
    {
        private string _fx;

        public DespejadorAutomatico(string fx)
        {
            _fx = fx.Trim().ToLower()
                    .Replace(" ", "")
                    .Replace("**", "^");
        }

        public List<string[]> GenerarCandidatos()
        {
            var candidatos = new List<string[]>();

            bool tieneExp = _fx.Contains("e^x") || _fx.Contains("exp(x)");
            bool tieneLn = _fx.Contains("ln(x)");
            bool tieneSin = _fx.Contains("sin(x)");
            bool tieneCos = _fx.Contains("cos(x)");
            bool tieneTan = _fx.Contains("tan(x)");
            bool tieneSqrt = _fx.Contains("sqrt(x)");

            var matchPot = Regex.Match(_fx, @"(\d+\.?\d*)\*x\^(\d+\.?\d*)|x\^(\d+\.?\d*)");
            bool tienePot = matchPot.Success;

            string coef = "1";
            string expo = "2";
            if (tienePot)
            {
                coef = string.IsNullOrEmpty(matchPot.Groups[1].Value) ? "1" : matchPot.Groups[1].Value;
                expo = string.IsNullOrEmpty(matchPot.Groups[2].Value)
                       ? matchPot.Groups[3].Value
                       : matchPot.Groups[2].Value;
            }

            // eˣ - a·xⁿ = 0
            if (tieneExp && tienePot)
            {
                candidatos.Add(new[] {
                    $"(e^x/{coef})^(1/{expo})",
                    $"Despeje de xⁿ: x = (eˣ/{coef})^(1/{expo})"
                });
                candidatos.Add(new[] {
                    $"ln({coef}*x^{expo})",
                    $"Despeje de eˣ: x = ln({coef}·x^{expo})"
                });
            }

            // polinomio a·xⁿ - b = 0
            var matchPoly = Regex.Match(_fx, @"(\d+\.?\d*)\*x\^(\d+\.?\d*)[+-](\d+\.?\d*)$");
            if (matchPoly.Success && !tieneExp && !tieneLn)
            {
                string a2 = matchPoly.Groups[1].Value;
                string n2 = matchPoly.Groups[2].Value;
                string b2 = matchPoly.Groups[3].Value;
                bool resta = _fx.Contains(a2 + "*x^" + n2 + "-");
                string signo = resta ? "" : "-";
                candidatos.Add(new[] {
                    $"({signo}{b2}/{a2})^(1/{n2})",
                    $"Despeje directo: x = ({signo}{b2}/{a2})^(1/{n2})"
                });
            }

            // ln(x) - f = 0
            if (tieneLn && !tieneExp)
            {
                string resto = _fx.Replace("ln(x)", "").TrimStart('-').TrimStart('+');
                candidatos.Add(new[] {
                    $"e^({resto})",
                    $"Despeje de ln(x): x = e^({resto})"
                });
            }

            // sin(x) = f
            if (tieneSin)
            {
                string resto = _fx.Replace("sin(x)", "").TrimStart('-').TrimStart('+');
                candidatos.Add(new[] {
                    $"arcsin({resto})",
                    $"Despeje de sin(x): x = arcsin({resto})"
                });
            }

            // cos(x) = f
            if (tieneCos)
            {
                string resto = _fx.Replace("cos(x)", "").TrimStart('-').TrimStart('+');
                candidatos.Add(new[] {
                    $"arccos({resto})",
                    $"Despeje de cos(x): x = arccos({resto})"
                });
            }

            // tan(x) = f
            if (tieneTan)
            {
                string resto = _fx.Replace("tan(x)", "").TrimStart('-').TrimStart('+');
                candidatos.Add(new[] {
                    $"arctan({resto})",
                    $"Despeje de tan(x): x = arctan({resto})"
                });
            }

            // sqrt(x) - f = 0
            if (tieneSqrt && !tieneExp)
            {
                string resto = _fx.Replace("sqrt(x)", "").TrimStart('-').TrimStart('+');
                candidatos.Add(new[] {
                    $"({resto})^2",
                    $"Despeje de √x: x = ({resto})²"
                });
            }

            // forma general x - f(x)
            candidatos.Add(new[] {
                $"x-({_fx})",
                "Forma aditiva general: x = x - f(x)"
            });

            return candidatos;
        }

        public string[] ElegirMejorDespeje(double x0)
        {
            var candidatos = GenerarCandidatos();
            string[] mejor = null;
            double mejorError = double.MaxValue;

            foreach (var c in candidatos)
            {
                try
                {
                    double xi = x0 == 0 ? 0.0001 : x0;
                    bool valido = true;
                    double errorFinal = double.MaxValue;

                    for (int i = 0; i < 5; i++)
                    {
                        var arg = new Argument("x", xi);
                        var expr = new Expression(c[0], arg);
                        double sig = expr.calculate();

                        if (double.IsNaN(sig) || double.IsInfinity(sig))
                        {
                            valido = false;
                            break;
                        }

                        errorFinal = xi != 0
                            ? Math.Abs((sig - xi) / sig)
                            : Math.Abs(sig - xi);

                        xi = sig;
                    }

                    if (valido && errorFinal < mejorError)
                    {
                        mejorError = errorFinal;
                        mejor = c;
                    }
                }
                catch { }
            }

            return mejor;
        }
    }
}