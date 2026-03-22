using org.mariuszgromada.math.mxparser;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Punto_Fijo_1.controlador;
using Punto_Fijo_1.modelo;
using Punto_Fijo_1.vista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Punto_Fijo_1
{
    public partial class metodo_punto_fijo : Form
    {
        private punto_fijo_controlador _controlador;

        public metodo_punto_fijo()
        {
            InitializeComponent();
            _controlador = new punto_fijo_controlador();
            ConfigurarTabla();
            ConfigurarValoresPorDefecto();
        }

        // ═══════════════════════════════════════════════════════════
        // CONFIGURACIÓN INICIAL
        // ═══════════════════════════════════════════════════════════

        private void ConfigurarTabla()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("colI", "i");
            dataGridView1.Columns.Add("colXi", "xᵢ");
            dataGridView1.Columns.Add("colGxi", "g(xᵢ)");
            dataGridView1.Columns.Add("colError", "Error %");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurarValoresPorDefecto()
        {
            txtFuncion.Text = "e^x - 8*x^2";
            txtDespeje.Text = "";
            txtX0.Text = "0";
            txtEpsilon.Text = "0.01";
            txtMaxIter.Text = "100";
            lblResultado.Text = "";
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN AUTO DESPEJE — abre FormAutoDespeje
        // ═══════════════════════════════════════════════════════════

        private void btnDespeje_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFuncion.Text))
            {
                MessageBox.Show("Primero escribe f(x).", "Campo vacío",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double.TryParse(txtX0.Text, out double x0);

            string mejor = _controlador.GenerarDespeje(
                txtFuncion.Text.Trim(), x0,
                out List<string[]> candidatos
            );

            if (candidatos == null || candidatos.Count == 0)
            {
                MessageBox.Show("No se pudieron generar candidatos para esta función.",
                    "Sin candidatos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formDespeje = new FormAutoDespeje(candidatos, mejor, txtFuncion.Text.Trim(), x0);

            if (formDespeje.ShowDialog(this) == DialogResult.OK)
                txtDespeje.Text = formDespeje.DespejElegido;
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN CALCULAR
        // ═══════════════════════════════════════════════════════════

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFuncion.Text) ||
                string.IsNullOrWhiteSpace(txtDespeje.Text))
            {
                MessageBox.Show("Ingresa f(x) y g(x) antes de calcular.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtX0.Text, out double x0) ||
                !double.TryParse(txtEpsilon.Text, out double eps) ||
                !int.TryParse(txtMaxIter.Text, out int maxIter))
            {
                MessageBox.Show("Revisa que X₀, ε y Máx. iteraciones sean números válidos.",
                    "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ok = _controlador.Calcular(
                txtFuncion.Text.Trim(),
                txtDespeje.Text.Trim(),
                x0, eps, maxIter,
                out string error
            );

            if (!ok)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LlenarTabla();
            MostrarGrafica();
            lblResultado.Text = _controlador.ObtenerResultado();
        }

        // ═══════════════════════════════════════════════════════════
        // LLENAR TABLA
        // ═══════════════════════════════════════════════════════════

        private void LlenarTabla()
        {
            dataGridView1.Rows.Clear();

            foreach (IteracionData iter in _controlador.ObtenerIteraciones())
            {
                string errStr = $"{iter.Error:F4} %";
                int fila = dataGridView1.Rows.Add(
                    iter.Iteracion,
                    iter.Xi.ToString("F6"),
                    iter.Gxi.ToString("F6"),
                    errStr
                );

                if (iter.Convergio)
                {
                    dataGridView1.Rows[fila].DefaultCellStyle.BackColor = Color.FromArgb(230, 245, 220);
                    dataGridView1.Rows[fila].DefaultCellStyle.ForeColor = Color.FromArgb(40, 100, 20);
                }
            }
        }

        // ═══════════════════════════════════════════════════════════
        // GRÁFICA OXYPLOT
        // ═══════════════════════════════════════════════════════════

        private void MostrarGrafica()
        {
            plotView1.Model = _controlador.ObtenerGrafica();
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN VER PROCESO
        // ═══════════════════════════════════════════════════════════

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (_controlador.ObtenerIteraciones().Count == 0)
            {
                MessageBox.Show("Primero debes calcular.", "Sin datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var pasos = _controlador.ObtenerPasos();
            var ventana = new proceso_detallado(pasos);
            ventana.ShowDialog(this);
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN LIMPIAR
        // ═══════════════════════════════════════════════════════════

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            plotView1.Model = null;
            lblResultado.Text = "";
            ConfigurarValoresPorDefecto();
            txtFuncion.Focus();
        }
    }
}