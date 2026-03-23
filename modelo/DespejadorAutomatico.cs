using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Punto_Fijo_1.modelo
{
    public class DespejadorAutomatico
    {
        private readonly string _fx;
        private static readonly CultureInfo IC = CultureInfo.InvariantCulture;

        public DespejadorAutomatico(string fx)
        {
            _fx = fx.Trim().ToLower()
                    .Replace(" ", "")
                    .Replace("**", "^");
        }

        // ══════════════════════════════════════════════════════════════════
        //  Estructura interna de un término polinómico
        // ══════════════════════════════════════════════════════════════════
        private class Termino
        {
            public double Coef;          // magnitud, siempre >= 0
            public double Expo;          // 0 = constante, 1 = lineal, etc.
            public bool Neg;           // true → el término es negativo en f(x)

            public bool TieneX => Expo > 0;
            public double CoefSig => Neg ? -Coef : Coef; // coeficiente con signo

            /// <summary>Devuelve el término como string con el signo indicado.</summary>
            public string Str(bool negado)
            {
                string sg = negado ? "-" : "";

                if (!TieneX)
                    return sg + Coef.ToString("G", IC);

                string c = Math.Abs(Coef - 1.0) < 1e-12 ? "" : Coef.ToString("G", IC) + "*";
                string e = Math.Abs(Expo - 1.0) < 1e-12 ? "x" : $"x^{Expo.ToString("G", IC)}";
                return sg + c + e;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  API pública
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Genera todos los candidatos g(x) posibles para la función f(x).
        /// Cada elemento es string[2]: { expresión g(x), descripción }.
        /// </summary>
        public List<string[]> GenerarCandidatos()
        {
            var result = new List<string[]>();

            // 1 ── Despejes algebraicos (funciona para polinomios puros)
            var terms = ParsePoly(_fx);
            if (terms != null)
            {
                foreach (var t in terms.Where(t => t.TieneX))
                {
                    string gx = Despeje(t, terms.Where(r => r != t).ToList());
                    if (gx == null) continue;

                    string label = Math.Abs(t.Expo - 1.0) < 1e-12
                        ? "Despeje lineal de x"
                        : $"Despeje de x^{(int)t.Expo}: raíz {(int)t.Expo}ª";

                    result.Add(new[] { gx, label });
                }
            }

            // 2 ── Despejes trascendentes
            TryTrans(result, "sin(x)", r => ($"asin({r})", "Despeje de sin(x)  → arcsin(resto)"));
            TryTrans(result, "cos(x)", r => ($"acos({r})", "Despeje de cos(x)  → arccos(resto)"));
            TryTrans(result, "tan(x)", r => ($"atan({r})", "Despeje de tan(x)  → arctan(resto)"));
            TryTrans(result, "ln(x)", r => ($"e^({r})", "Despeje de ln(x)   → e^(resto)"));
            TryTrans(result, "log(x)", r => ($"e^({r})", "Despeje de log(x)  → e^(resto)"));
            TryTrans(result, "e^x", r => ($"ln({r})", "Despeje de eˣ      → ln(resto)"));
            TryTrans(result, "exp(x)", r => ($"ln({r})", "Despeje de exp(x)  → ln(resto)"));
            TryTrans(result, "sqrt(x)", r => ($"({r})^2", "Despeje de √x      → (resto)²"));

            // 3 ── Forma aditiva general (siempre al final, frecuentemente diverge)
            result.Add(new[] { $"x-({_fx})", "Forma aditiva general: x = x - f(x)" });

            return result;
        }

        /// <summary>
        /// Elige el mejor g(x) evaluando |g'(x0)| numéricamente.
        /// Prefiere |g'| menor a 1. Si ninguno converge devuelve el de menor |g'|.
        /// </summary>
        public string[] ElegirMejorDespeje(double x0)
        {
            var cands = GenerarCandidatos();
            double best = double.MaxValue;
            string[] winner = null;

            // Primera pasada: buscar |g'| < 1
            foreach (var c in cands)
            {
                try
                {
                    double xi = x0 == 0 ? 1e-4 : x0;
                    double gp = Math.Abs(NumDeriv(c[0], xi));
                    if (double.IsNaN(gp) || double.IsInfinity(gp)) continue;
                    if (gp < 1.0 && gp < best) { best = gp; winner = c; }
                }
                catch { }
            }

            // Segunda pasada: si ninguno converge, tomar el de menor |g'| absoluto
            if (winner == null)
            {
                best = double.MaxValue;
                foreach (var c in cands)
                {
                    try
                    {
                        double xi = x0 == 0 ? 1e-4 : x0;
                        double gp = Math.Abs(NumDeriv(c[0], xi));
                        if (double.IsNaN(gp) || double.IsInfinity(gp)) continue;
                        if (gp < best) { best = gp; winner = c; }
                    }
                    catch { }
                }
            }

            return winner ?? cands.Last();
        }

        /// <summary>
        /// Devuelve el estado de convergencia de un despeje en x0.
        /// "rápido" → |g'| &lt; 0.5 | "converge" → &lt; 1 | "lento" → cerca de 1 | "diverge" → ≥ 1
        /// </summary>
        public string GetEstado(string gx, double x0)
        {
            try
            {
                double xi = x0 == 0 ? 1e-4 : x0;
                double gp = Math.Abs(NumDeriv(gx, xi));
                if (double.IsNaN(gp) || double.IsInfinity(gp)) return "inválido";
                if (gp < 0.3) return "rápido";
                if (gp < 0.7) return "converge";
                if (gp < 1.0) return "lento";
                return "diverge";
            }
            catch { return "error"; }
        }

        // ══════════════════════════════════════════════════════════════════
        //  Parser polinómico
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Intenta parsear f(x) como polinomio de términos simples.
        /// Devuelve null si algún término no es polinómico (ej: sin(x), e^x, etc.).
        /// </summary>
        private List<Termino> ParsePoly(string expr)
        {
            var splits = SplitTerms(expr);
            if (splits == null) return null;

            var list = new List<Termino>();
            foreach (var (raw, neg) in splits)
            {
                var t = ParseOne(raw, neg);
                if (t == null) return null; // término no polinómico → salir
                list.Add(t);
            }
            return list.Count > 0 ? list : null;
        }

        /// <summary>
        /// Divide la expresión en términos respetando la profundidad de paréntesis.
        /// Devuelve lista de (término_sin_signo, es_negativo).
        /// </summary>
        private List<(string raw, bool neg)> SplitTerms(string expr)
        {
            var list = new List<(string, bool)>();
            int depth = 0, start = 0;
            bool neg = expr.Length > 0 && expr[0] == '-';
            if (neg) start = 1;

            for (int i = start; i < expr.Length; i++)
            {
                char ch = expr[i];
                if (ch == '(') depth++;
                else if (ch == ')') depth--;
                else if (depth == 0 && (ch == '+' || ch == '-') && i > 0)
                {
                    string part = expr.Substring(start, i - start);
                    if (part.Length > 0) list.Add((part, neg));
                    neg = ch == '-';
                    start = i + 1;
                }
            }
            if (start < expr.Length)
                list.Add((expr.Substring(start), neg));

            return list.Count > 0 ? list : null;
        }

        /// <summary>
        /// Parsea un único término sin signo. Devuelve null si no es polinómico.
        /// Patrones soportados: a*x^n | a*x | x^n | x | constante
        /// </summary>
        private Termino ParseOne(string s, bool neg)
        {
            Match m;

            // a*x^n
            m = Regex.Match(s, @"^(\d+\.?\d*)\*x\^(\d+\.?\d*)$");
            if (m.Success) return MkT(m.Groups[1].Value, m.Groups[2].Value, neg);

            // a*x
            m = Regex.Match(s, @"^(\d+\.?\d*)\*x$");
            if (m.Success) return MkT(m.Groups[1].Value, "1", neg);

            // x^n
            m = Regex.Match(s, @"^x\^(\d+\.?\d*)$");
            if (m.Success) return MkT("1", m.Groups[1].Value, neg);

            // x solo
            if (s == "x") return MkT("1", "1", neg);

            // constante numérica
            if (double.TryParse(s, NumberStyles.Any, IC, out double val))
                return new Termino { Coef = val, Expo = 0, Neg = neg };

            return null; // no es polinómico
        }

        private Termino MkT(string coef, string expo, bool neg) => new Termino
        {
            Coef = double.Parse(coef, IC),
            Expo = double.Parse(expo, IC),
            Neg = neg
        };

        // ══════════════════════════════════════════════════════════════════
        //  Construcción del despeje algebraico
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Construye g(x) despejando x del término pivot dado el resto.
        ///
        /// Lógica:
        ///   pivot.CoefSig · x^expo + Σ(resto) = 0
        ///   x^expo = -Σ(resto) / pivot.CoefSig
        ///   x      = rhs^(1/expo)
        /// </summary>
        private string Despeje(Termino pivot, List<Termino> resto)
        {
            string rhs = BuildRHS(resto, pivot.CoefSig);
            if (rhs == null) return null;

            double expo = pivot.Expo;
            if (Math.Abs(expo - 1.0) < 1e-12) return rhs;
            if (Math.Abs(expo - 2.0) < 1e-12) return $"sqrt({rhs})";
            return $"({rhs})^(1/{(int)expo})";
        }

        /// <summary>
        /// Calcula el lado derecho: -Σ(resto) / coefSig
        ///
        /// Si coefSig > 0 → negamos cada término del resto, dividimos por coefSig.
        /// Si coefSig &lt; 0 → tomamos los términos sin negar, dividimos por |coefSig|.
        ///   (los dos negativos se cancelan)
        /// </summary>
        private string BuildRHS(List<Termino> resto, double coefSig)
        {
            if (resto.Count == 0) return "0";

            bool negar = coefSig > 0;          // si coefSig > 0 negamos el resto
            double divisor = Math.Abs(coefSig);   // siempre positivo

            var parts = resto.Select(r => r.Str(negar ? !r.Neg : r.Neg)).ToList();

            string suma = parts[0];
            for (int i = 1; i < parts.Count; i++)
                suma += parts[i].StartsWith("-") ? parts[i] : "+" + parts[i];

            if (Math.Abs(divisor - 1.0) < 1e-12) return suma;
            return $"({suma})/{divisor.ToString("G", IC)}";
        }

        // ══════════════════════════════════════════════════════════════════
        //  Despejes trascendentes
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Intenta generar un despeje trascendente si el token aparece en f(x).
        /// Extrae el resto de la expresión (negado correctamente) y aplica build().
        /// </summary>
        private void TryTrans(List<string[]> list, string token,
                               Func<string, (string gx, string desc)> build)
        {
            int idx = _fx.IndexOf(token);
            if (idx < 0) return;

            // Determinar si el token lleva signo negativo en f(x)
            bool tokNeg = false;
            for (int i = idx - 1; i >= 0; i--)
            {
                if (_fx[i] == '-') { tokNeg = true; break; }
                if (_fx[i] == '+') { tokNeg = false; break; }
                if (!char.IsWhiteSpace(_fx[i])) break;
            }

            // Quitar el token (y su signo si existe justo antes)
            string s = _fx;
            if (idx > 0 && (s[idx - 1] == '+' || s[idx - 1] == '-'))
                s = s.Remove(idx - 1, 1 + token.Length);
            else
                s = s.Remove(idx, token.Length);

            if (s.StartsWith("+")) s = s.Substring(1);
            if (s.Length == 0) s = "0";

            // Negar el resto para obtener el despeje
            // Si tokNeg=false: token = +T → T = -resto → arcfun(-resto)
            // Si tokNeg=true:  token = -T → -T = -resto → T = resto → arcfun(resto)
            string restoNeg;
            if (tokNeg)
                restoNeg = s;
            else
                restoNeg = s.StartsWith("-") ? s.Substring(1) : $"-({s})";

            if (restoNeg.Length == 0) restoNeg = "0";

            try
            {
                var (gx, desc) = build(restoNeg);
                list.Add(new[] { gx, desc });
            }
            catch { }
        }

        // ══════════════════════════════════════════════════════════════════
        //  Derivada numérica y evaluación
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Derivada numérica de g(x) por diferencias centradas.</summary>
        private double NumDeriv(string gx, double x0)
        {
            const double h = 1e-6;
            return (Eval(gx, x0 + h) - Eval(gx, x0 - h)) / (2 * h);
        }

        private double Eval(string expr, double x)
        {
            var arg = new Argument("x", x);
            return new Expression(expr, arg).calculate();
        }
    }
}