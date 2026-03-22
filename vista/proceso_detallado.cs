using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_Fijo_1
{
    public partial class proceso_detallado : Form
    {
        // Lista de pasos: cada elemento es [titulo, contenido]
        private List<string[]> _pasos;
        private int _pasoActual = 0;

        public proceso_detallado(List<string[]> pasos)
        {
            InitializeComponent();
            _pasos = pasos;
            MostrarPaso(0);
        }

        // ─── Muestra el paso en pantalla ──────────────────────────────────────

        private void MostrarPaso(int indice)
        {
            if (indice < 0 || indice >= _pasos.Count) return;

            _pasoActual = indice;

            // Título
            lblTituloPaso.Text = _pasos[indice][0];

            // Contenido
            rtbPaso.Clear();
            rtbPaso.Font = new Font("Consolas", 10);
            rtbPaso.Text = _pasos[indice][1];

            // Colorear líneas con ✓
            ColorearTexto();

            // Contador
            lblContadorPaso.Text = $"Paso {indice + 1} de {_pasos.Count}";

            // Habilitar/deshabilitar botones
            btnAnterior.Enabled = indice > 0;
            btnSiguiente.Enabled = indice < _pasos.Count - 1;
        }

        // Colorea líneas especiales dentro del RichTextBox
        private void ColorearTexto()
        {
            string[] lineas = rtbPaso.Text.Split('\n');
            rtbPaso.Clear();

            foreach (string linea in lineas)
            {
                int inicio = rtbPaso.TextLength;
                rtbPaso.AppendText(linea + "\n");

                if (linea.Contains("✓") || linea.Contains("CONVERGIÓ"))
                {
                    rtbPaso.Select(inicio, linea.Length);
                    rtbPaso.SelectionColor = Color.FromArgb(40, 130, 40);
                    rtbPaso.SelectionFont = new Font("Consolas", 10, FontStyle.Bold);
                }
                else if (linea.Contains("⚠") || linea.Contains("NO convergió"))
                {
                    rtbPaso.Select(inicio, linea.Length);
                    rtbPaso.SelectionColor = Color.FromArgb(180, 80, 20);
                }
                else if (linea.TrimStart().StartsWith("g(x)") ||
                         linea.TrimStart().StartsWith("x ="))
                {
                    rtbPaso.Select(inicio, linea.Length);
                    rtbPaso.SelectionColor = Color.FromArgb(0, 150, 180);
                }

                // Restaurar color por defecto para la siguiente línea
                rtbPaso.Select(rtbPaso.TextLength, 0);
                rtbPaso.SelectionColor = rtbPaso.ForeColor;
            }

            rtbPaso.SelectionStart = 0;
            rtbPaso.ScrollToCaret();
        }

        // ─── Botones de navegación ────────────────────────────────────────────

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MostrarPaso(_pasoActual + 1);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            MostrarPaso(_pasoActual - 1);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
