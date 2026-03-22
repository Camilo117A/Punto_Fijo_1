using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;

namespace Punto_Fijo_1.modelo
{
    internal class punto_fijo_modelo
    {
        public string FuncionFx { get; set; }
        public string FuncionGx { get; set; }
        public double X0 { get; set; }
        public double Epsilon { get; set; }
        public int MaxIteraciones { get; set; }

        public List<IteracionData> Iteraciones { get; private set; }
        public double RaizAproximada { get; private set; }
        public bool Convergio { get; private set; }
        public string MensajeError { get; private set; }

        public punto_fijo_modelo()
        {
            Iteraciones = new List<IteracionData>();
        }

        public double EvaluarGx(double x)
        {
            Argument argX = new Argument("x", x);
            Expression expr = new Expression(FuncionGx, argX);
            return expr.calculate();
        }

        public double EvaluarFx(double x)
        {
            Argument argX = new Argument("x", x);
            Expression expr = new Expression(FuncionFx, argX);
            return expr.calculate();
        }

        public bool ValidarFunciones(out string error)
        {
            error = "";
            try
            {
                Argument argX = new Argument("x", 0);

                Expression exprF = new Expression(FuncionFx, argX);
                if (double.IsNaN(exprF.calculate()) && !FuncionFx.Contains("x"))
                { error = "La función f(x) no es válida."; return false; }

                Expression exprG = new Expression(FuncionGx, argX);
                if (double.IsNaN(exprG.calculate()) && !FuncionGx.Contains("x"))
                { error = "La función g(x) no es válida."; return false; }

                return true;
            }
            catch (Exception ex)
            {
                error = "Error al validar funciones: " + ex.Message;
                return false;
            }
        }

        public bool Calcular()
        {
            Iteraciones.Clear();
            Convergio = false;
            MensajeError = "";

            try
            {
                double xi = X0;
                double gxi = EvaluarGx(xi);

                Iteraciones.Add(new IteracionData
                {
                    Iteracion = 0,
                    Xi = xi,
                    Gxi = gxi,
                    Error = 0,
                    Convergio = false
                });

                for (int i = 1; i <= MaxIteraciones; i++)
                {
                    double xiAnterior = xi;
                    xi = gxi;
                    gxi = EvaluarGx(xi);

                    double errorActual = xi != 0
                        ? Math.Abs((xi - xiAnterior) / xi) * 100
                        : Math.Abs(xi - xiAnterior) * 100;

                    bool convergeEstaIter = errorActual < Epsilon;

                    Iteraciones.Add(new IteracionData
                    {
                        Iteracion = i,
                        Xi = xi,
                        Gxi = gxi,
                        Error = errorActual,
                        Convergio = convergeEstaIter
                    });

                    if (convergeEstaIter)
                    {
                        Convergio = true;
                        RaizAproximada = xi;
                        break;
                    }

                    if (double.IsNaN(xi) || double.IsInfinity(xi))
                    {
                        MensajeError = "El método diverge. Intenta con otro despeje g(x) o un X₀ diferente.";
                        return false;
                    }
                }

                if (!Convergio)
                {
                    MensajeError = $"No convergió en {MaxIteraciones} iteraciones.";
                    RaizAproximada = xi;
                }

                return true;
            }
            catch (Exception ex)
            {
                MensajeError = "Error en el cálculo: " + ex.Message;
                return false;
            }
        }
    }
}