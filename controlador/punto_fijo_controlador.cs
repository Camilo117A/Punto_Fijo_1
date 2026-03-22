using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Punto_Fijo_1.modelo;
using System.Collections.Generic;

namespace Punto_Fijo_1.controlador
{
    internal class punto_fijo_controlador
    {
        private punto_fijo_modelo _modelo;

        public punto_fijo_controlador()
        {
            _modelo = new punto_fijo_modelo();
        }

        public bool Calcular(string fx, string gx, double x0, double epsilon, int maxIter, out string error)
        {
            error = "";
            _modelo.FuncionFx = fx;
            _modelo.FuncionGx = gx;
            _modelo.X0 = x0;
            _modelo.Epsilon = epsilon;
            _modelo.MaxIteraciones = maxIter;

            if (!_modelo.ValidarFunciones(out error)) return false;

            bool ok = _modelo.Calcular();
            if (!ok) { error = _modelo.MensajeError; return false; }
            return true;
        }

        public List<IteracionData> ObtenerIteraciones() => _modelo.Iteraciones;

        public string ObtenerResultado()
        {
            if (_modelo.Convergio)
                return $"✓ Raíz ≈ {_modelo.RaizAproximada:F6}   |   Iteraciones: {_modelo.Iteraciones.Count - 1}";
            else
                return $"⚠ No convergió. Último valor: {_modelo.RaizAproximada:F6}";
        }

        public PlotModel ObtenerGrafica()
        {
            var plot = new PlotModel
            {
                Title = "Convergencia xᵢ",
                Background = OxyColors.White
            };

            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Iteración",
                MajorGridlineStyle = LineStyle.Dot,
                MinorGridlineStyle = LineStyle.None
            });
            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "xᵢ",
                MajorGridlineStyle = LineStyle.Dot,
                MinorGridlineStyle = LineStyle.None
            });

            var serie = new LineSeries
            {
                Title = "xᵢ",
                Color = OxyColor.FromRgb(0, 122, 204),
                StrokeThickness = 2,
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerFill = OxyColor.FromRgb(244, 135, 113)
            };

            foreach (var iter in _modelo.Iteraciones)
                serie.Points.Add(new DataPoint(iter.Iteracion, iter.Xi));

            var lineaRaiz = new LineSeries
            {
                Title = $"Raíz ≈ {_modelo.RaizAproximada:F4}",
                Color = OxyColor.FromRgb(106, 153, 85),
                StrokeThickness = 1.5,
                LineStyle = LineStyle.Dash
            };
            double r = _modelo.RaizAproximada;
            lineaRaiz.Points.Add(new DataPoint(0, r));
            lineaRaiz.Points.Add(new DataPoint(_modelo.Iteraciones.Count - 1, r));

            plot.Series.Add(serie);
            plot.Series.Add(lineaRaiz);
            return plot;
        }

        public List<string[]> ObtenerPasos()
        {
            var pasos = new List<string[]>();

            pasos.Add(new string[]
            {
                "Paso 1 — Función original f(x)",
                $"Se define la función:\n\n   f(x) = {_modelo.FuncionFx}\n\n" +
                $"Condición de parada:  ε < {_modelo.Epsilon}%\n" +
                $"Valor inicial:        X₀ = {_modelo.X0}\n" +
                $"Máx. iteraciones:     {_modelo.MaxIteraciones}"
            });

            pasos.Add(new string[]
            {
                "Paso 2 — Despeje g(x)",
                $"Se despeja x de la ecuación f(x) = 0:\n\n" +
                $"   {_modelo.FuncionFx} = 0\n\n" +
                $"   g(x) = {_modelo.FuncionGx}\n\n" +
                $"El método aplica:  xᵢ₊₁ = g(xᵢ)"
            });

            foreach (var iter in _modelo.Iteraciones)
            {
                if (iter.Iteracion == 0)
                {
                    pasos.Add(new string[]
                    {
                        "Paso 3 — Iteración inicial (i = 0)",
                        $"Se evalúa g(x) con el valor inicial:\n\n" +
                        $"   x₀ = {iter.Xi}\n" +
                        $"   g(x₀) = {iter.Gxi:F6}\n\n" +
                        $"   → x₁ = {iter.Gxi:F6}"
                    });
                }
                else
                {
                    string estado = iter.Convergio ? "   ✓ CONVERGIÓ" : "";
                    pasos.Add(new string[]
                    {
                        $"Iteración i = {iter.Iteracion}",
                        $"   xᵢ     = {iter.Xi:F6}\n" +
                        $"   g(xᵢ)  = {iter.Gxi:F6}\n" +
                        $"   Error  = |({iter.Xi:F6} - {_modelo.Iteraciones[iter.Iteracion - 1].Xi:F6}) / {iter.Xi:F6}| × 100\n" +
                        $"          = {iter.Error:F4} %\n" +
                        $"{estado}"
                    });
                }
            }

            string conclusion = _modelo.Convergio
                ? $"✓ El método CONVERGIÓ\n\n   Raíz aproximada:  x ≈ {_modelo.RaizAproximada:F6}\n   Iteraciones:      {_modelo.Iteraciones.Count - 1}\n   Error final:      {_modelo.Iteraciones[^1].Error:F4} %"
                : $"⚠ El método NO convergió en {_modelo.MaxIteraciones} iteraciones.\n\n   Último valor:  x = {_modelo.RaizAproximada:F6}\n\n   Sugerencia: cambia g(x) o el valor de X₀.";

            pasos.Add(new string[] { "Conclusión", conclusion });
            return pasos;
        }

        public string GenerarDespeje(string fx, double x0, out List<string[]> todosCandidatos)
        {
            var despejador = new DespejadorAutomatico(fx);
            todosCandidatos = despejador.GenerarCandidatos();
            var mejor = despejador.ElegirMejorDespeje(x0);
            return mejor != null ? mejor[0] : "";
        }
    }
}