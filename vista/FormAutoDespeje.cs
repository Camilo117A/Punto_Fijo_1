using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Punto_Fijo_1.vista
{
    public partial class FormAutoDespeje : Form
    {
        // Propiedad pública — Form1 la lee después de cerrar
        public string DespejElegido { get; private set; }

        private List<string[]> _candidatos;
        private string _mejorGx;
        private double _x0;

        public FormAutoDespeje(List<string[]> candidatos, string mejorGx, string fx, double x0)
        {
            InitializeComponent();
            _candidatos = candidatos;
            _mejorGx = mejorGx;
            _x0 = x0;

            lblFuncionIngresada.Text = fx;
            lblMejorGx.Text = string.IsNullOrEmpty(mejorGx) ? "No encontrado" : mejorGx;

            CargarCandidatos();
        }

        // ═══════════════════════════════════════════════════════════
        // CARGAR CANDIDATOS EN EL LISTVIEW
        // ═══════════════════════════════════════════════════════════

        private void CargarCandidatos()
        {
            listViewCandidatos.Items.Clear();

            foreach (var c in _candidatos)
            {
                string gx = c[0];
                string desc = c.Length > 1 ? c[1] : "";
                string estado = ProbarConvergencia(gx);

                var item = new ListViewItem(gx);
                item.SubItems.Add(estado);
                item.SubItems.Add(desc);

                if (gx == _mejorGx)
                {
                    item.BackColor = Color.FromArgb(20, 60, 20);
                    item.ForeColor = Color.FromArgb(106, 200, 85);
                    item.Font = new Font("Consolas", 9, FontStyle.Bold);
                }
                else if (estado == "diverge")
                {
                    item.ForeColor = Color.FromArgb(180, 80, 50);
                }
                else
                {
                    item.ForeColor = Color.FromArgb(78, 201, 176);
                }

                listViewCandidatos.Items.Add(item);
            }

            // Seleccionar el mejor automáticamente
            for (int i = 0; i < listViewCandidatos.Items.Count; i++)
            {
                if (listViewCandidatos.Items[i].Text == _mejorGx)
                {
                    listViewCandidatos.Items[i].Selected = true;
                    listViewCandidatos.EnsureVisible(i);
                    break;
                }
            }
        }

        // ═══════════════════════════════════════════════════════════
        // PROBAR CONVERGENCIA
        // ═══════════════════════════════════════════════════════════

        private string ProbarConvergencia(string gx)
        {
            try
            {
                double xi = _x0 == 0 ? 0.0001 : _x0;
                for (int i = 0; i < 5; i++)
                {
                    var arg = new Argument("x", xi);
                    var expr = new Expression(gx, arg);
                    double sig = expr.calculate();

                    if (double.IsNaN(sig) || double.IsInfinity(sig))
                        return "diverge";

                    double err = xi != 0
                        ? Math.Abs((sig - xi) / sig) * 100
                        : Math.Abs(sig - xi) * 100;

                    if (err < 1.0) return "converge";
                    xi = sig;
                }
                return "lento";
            }
            catch { return "error"; }
        }

        // ═══════════════════════════════════════════════════════════
        // SELECCIÓN EN LISTVIEW → PREVIEW Y DESCRIPCIÓN
        // ═══════════════════════════════════════════════════════════

        private void listViewCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCandidatos.SelectedItems.Count == 0) return;

            string gx = listViewCandidatos.SelectedItems[0].Text;
            string desc = listViewCandidatos.SelectedItems[0].SubItems[2].Text;

            lblDescripcion.Text = desc;
            MostrarPreview(gx);
        }

        // ═══════════════════════════════════════════════════════════
        // PREVIEW DE ITERACIONES
        // ═══════════════════════════════════════════════════════════

        private void MostrarPreview(string gx)
        {
            rtbPreview.Clear();
            rtbPreview.BackColor = Color.FromArgb(26, 45, 26);
            rtbPreview.ForeColor = Color.FromArgb(78, 201, 176);
            rtbPreview.Font = new Font("Consolas", 9);

            try
            {
                double xi = _x0 == 0 ? 0.0001 : _x0;
                bool converge = false;

                for (int i = 1; i <= 10; i++)
                {
                    var arg = new Argument("x", xi);
                    var expr = new Expression(gx, arg);
                    double sig = expr.calculate();

                    if (double.IsNaN(sig) || double.IsInfinity(sig))
                    {
                        int ini2 = rtbPreview.TextLength;
                        rtbPreview.AppendText("⚠ Diverge — no converge desde X₀\n");
                        rtbPreview.Select(ini2, rtbPreview.TextLength - ini2);
                        rtbPreview.SelectionColor = Color.FromArgb(200, 80, 30);
                        return;
                    }

                    double err = xi != 0
                        ? Math.Abs((sig - xi) / sig) * 100
                        : Math.Abs(sig - xi) * 100;

                    converge = err < 1.0;

                    int inicio = rtbPreview.TextLength;
                    string linea = $"  i={i,-2}  xᵢ={sig:F6}   err={err:F4}%{(converge ? " ✓" : "")}\n";
                    rtbPreview.AppendText(linea);

                    if (converge)
                    {
                        rtbPreview.Select(inicio, linea.Length);
                        rtbPreview.SelectionColor = Color.FromArgb(106, 200, 85);
                        rtbPreview.SelectionFont = new Font("Consolas", 9, FontStyle.Bold);
                    }

                    rtbPreview.Select(rtbPreview.TextLength, 0);
                    rtbPreview.SelectionColor = Color.FromArgb(78, 201, 176);
                    rtbPreview.SelectionFont = new Font("Consolas", 9);

                    xi = sig;
                    if (converge) break;
                }

                if (!converge)
                    rtbPreview.AppendText("  → puede converger con más iteraciones\n");
            }
            catch
            {
                rtbPreview.Text = "⚠ Error al evaluar esta g(x)";
            }
        }

        // ═══════════════════════════════════════════════════════════
        // DOBLE CLICK → USAR DIRECTO
        // ═══════════════════════════════════════════════════════════

        private void listViewCandidatos_DoubleClick(object sender, EventArgs e)
        {
            UsarSeleccionado();
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN USAR
        // ═══════════════════════════════════════════════════════════

        private void btnUsarDespeje_Click(object sender, EventArgs e)
        {
            UsarSeleccionado();
        }

        private void UsarSeleccionado()
        {
            if (listViewCandidatos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un candidato de la lista.",
                    "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DespejElegido = listViewCandidatos.SelectedItems[0].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN CANCELAR
        // ═══════════════════════════════════════════════════════════

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}