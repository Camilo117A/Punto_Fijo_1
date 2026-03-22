using org.mariuszgromada.math.mxparser;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Punto_Fijo_1.controlador;
using Punto_Fijo_1.modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Punto_Fijo_1
{
    public partial class metodo_punto_fijo : Form
    {
        private punto_fijo_controlador _controlador;

        // Panel despeje inline
        private Panel _panelDespeje;
        private ListBox _listaCandidatos;
        private RichTextBox _rtbPreview;
        private List<string[]> _candidatosActuales = new List<string[]>();

        public metodo_punto_fijo()
        {
            InitializeComponent();
            _controlador = new punto_fijo_controlador();
            ConfigurarTabla();
            ConfigurarValoresPorDefecto();
            CrearPanelDespeje();
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
        // PANEL DESPEJE INLINE
        // ═══════════════════════════════════════════════════════════

        private void CrearPanelDespeje()
        {
            // Contenedor principal del panel
            _panelDespeje = new Panel
            {
                Visible = false,
                BackColor = Color.FromArgb(26, 26, 46),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(6),
                Height = 230,
                Dock = DockStyle.None
            };

            // — Título —
            var lblTitulo = new Label
            {
                Text = "⚡ Candidatos g(x)  —  click para previsualizar",
                Dock = DockStyle.Top,
                Height = 22,
                ForeColor = Color.FromArgb(86, 156, 214),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // — Lista de candidatos —
            _listaCandidatos = new ListBox
            {
                Dock = DockStyle.Top,
                Height = 72,
                BackColor = Color.FromArgb(37, 37, 64),
                ForeColor = Color.FromArgb(78, 201, 176),
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.None
            };
            _listaCandidatos.SelectedIndexChanged += ListaCandidatos_SelectedIndexChanged;

            // — Preview de iteraciones —
            _rtbPreview = new RichTextBox
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.FromArgb(26, 45, 26),
                ForeColor = Color.FromArgb(106, 153, 85),
                Font = new Font("Consolas", 9),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Text = "  ← Selecciona un candidato"
            };

            // — Botones —
            var panelBtns = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 34,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 3, 0, 0)
            };

            var btnUsar = new Button
            {
                Text = "Usar este despeje ↓",
                Width = 148,
                Height = 26,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8)
            };
            btnUsar.FlatAppearance.BorderSize = 0;
            btnUsar.Click += BtnUsarDespeje_Click;

            var btnX = new Button
            {
                Text = "× Cerrar",
                Width = 64,
                Height = 26,
                BackColor = Color.FromArgb(58, 58, 58),
                ForeColor = Color.FromArgb(180, 180, 180),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8)
            };
            btnX.FlatAppearance.BorderSize = 0;
            btnX.Click += (s, e) => _panelDespeje.Visible = false;

            panelBtns.Controls.Add(btnUsar);
            panelBtns.Controls.Add(btnX);

            // Agregar en orden inverso (Dock=Top apila de abajo hacia arriba)
            _panelDespeje.Controls.Add(panelBtns);
            _panelDespeje.Controls.Add(_rtbPreview);
            _panelDespeje.Controls.Add(_listaCandidatos);
            _panelDespeje.Controls.Add(lblTitulo);

            // Insertar en el panel izquierdo del SplitContainer
            // IMPORTANTE: cambia "splitContainer1" si tu split tiene otro nombre
            splitContainer1.Panel1.Controls.Add(_panelDespeje);
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN DESPEJE AUTOMÁTICO
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

            // Generar candidatos desde el controlador
            string mejor = _controlador.GenerarDespeje(
                txtFuncion.Text.Trim(), x0,
                out _candidatosActuales
            );

            // Llenar la lista
            _listaCandidatos.Items.Clear();
            foreach (var c in _candidatosActuales)
                _listaCandidatos.Items.Add(c[0]);

            // Seleccionar el mejor automáticamente
            int idx = _candidatosActuales.FindIndex(c => c[0] == mejor);
            if (idx >= 0) _listaCandidatos.SelectedIndex = idx;
            else if (_listaCandidatos.Items.Count > 0)
                _listaCandidatos.SelectedIndex = 0;

            // Posicionar debajo del botón despeje
            _panelDespeje.Location = new Point(
                btnDespeje.Left,
                btnDespeje.Bottom + 4
            );
            _panelDespeje.Width = splitContainer1.Panel1.Width - 20;
            _panelDespeje.Visible = true;
            _panelDespeje.BringToFront();
        }

        // ═══════════════════════════════════════════════════════════
        // PREVIEW AL SELECCIONAR CANDIDATO
        // ═══════════════════════════════════════════════════════════

        private void ListaCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listaCandidatos.SelectedItem == null) return;

            string gx = _listaCandidatos.SelectedItem.ToString();
            double.TryParse(txtX0.Text, out double x0);

            _rtbPreview.Clear();

            try
            {
                double xi = x0 == 0 ? 0.0001 : x0; // evitar división por 0
                bool converge = false;

                for (int i = 1; i <= 8; i++)
                {
                    var arg = new Argument("x", xi);
                    var expr = new Expression(gx, arg);
                    double sig = expr.calculate();

                    if (double.IsNaN(sig) || double.IsInfinity(sig))
                    {
                        _rtbPreview.ForeColor = Color.FromArgb(200, 80, 30);
                        _rtbPreview.Text = "⚠ Diverge — no converge desde X₀=" + x0;
                        return;
                    }

                    double err = xi != 0
                        ? Math.Abs((sig - xi) / sig) * 100
                        : Math.Abs(sig - xi) * 100;

                    converge = err < 1.0;

                    int ini = _rtbPreview.TextLength;
                    string lin = $"  i={i}  xᵢ={sig:F6}   err={err:F3}%{(converge ? " ✓" : "")}\n";
                    _rtbPreview.AppendText(lin);

                    if (converge)
                    {
                        _rtbPreview.Select(ini, lin.Length - 1);
                        _rtbPreview.SelectionColor = Color.FromArgb(106, 200, 85);
                        _rtbPreview.SelectionFont = new Font("Consolas", 9, FontStyle.Bold);
                    }

                    // Reset color
                    _rtbPreview.Select(_rtbPreview.TextLength, 0);
                    _rtbPreview.SelectionColor = Color.FromArgb(106, 153, 85);
                    _rtbPreview.SelectionFont = new Font("Consolas", 9);

                    xi = sig;
                    if (converge) break;
                }

                if (!converge)
                    _rtbPreview.AppendText("  → puede converger con más iteraciones\n");
            }
            catch
            {
                _rtbPreview.Text = "⚠ Error al evaluar g(x)";
            }
        }

        // ═══════════════════════════════════════════════════════════
        // BOTÓN "USAR ESTE DESPEJE"
        // ═══════════════════════════════════════════════════════════

        private void BtnUsarDespeje_Click(object sender, EventArgs e)
        {
            if (_listaCandidatos.SelectedItem == null) return;
            txtDespeje.Text = _listaCandidatos.SelectedItem.ToString();
            _panelDespeje.Visible = false;
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
                string errStr = iter.Iteracion == 0 ? "—" : $"{iter.Error:F4} %";
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
            _panelDespeje.Visible = false;
            ConfigurarValoresPorDefecto();
            txtFuncion.Focus();
        }
    }
}