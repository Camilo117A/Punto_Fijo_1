namespace Punto_Fijo_1
{
    partial class metodo_punto_fijo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            btnDespeje = new Button();
            txtEpsilon = new TextBox();
            lblResultado = new Label();
            lblFuncion = new Label();
            btnLimpiar = new Button();
            txtFuncion = new TextBox();
            btnProceso = new Button();
            lblDespeje = new Label();
            btnCalcular = new Button();
            txtDespeje = new TextBox();
            txtMaxIter = new TextBox();
            txtXo = new Label();
            label1 = new Label();
            txtEpsilo = new Label();
            txtX0 = new TextBox();
            splitContainer2 = new SplitContainer();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(882, 553);
            splitContainer1.SplitterDistance = 305;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnDespeje);
            panel1.Controls.Add(txtEpsilon);
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(lblFuncion);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(txtFuncion);
            panel1.Controls.Add(btnProceso);
            panel1.Controls.Add(lblDespeje);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(txtDespeje);
            panel1.Controls.Add(txtMaxIter);
            panel1.Controls.Add(txtXo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtEpsilo);
            panel1.Controls.Add(txtX0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 553);
            panel1.TabIndex = 1;
            // 
            // btnDespeje
            // 
            btnDespeje.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDespeje.BackColor = SystemColors.MenuHighlight;
            btnDespeje.ForeColor = SystemColors.Control;
            btnDespeje.Location = new Point(28, 89);
            btnDespeje.Name = "btnDespeje";
            btnDespeje.Size = new Size(122, 29);
            btnDespeje.TabIndex = 14;
            btnDespeje.Text = "auto despeje";
            btnDespeje.UseVisualStyleBackColor = false;
            btnDespeje.Click += btnDespeje_Click;
            // 
            // txtEpsilon
            // 
            txtEpsilon.BackColor = SystemColors.ScrollBar;
            txtEpsilon.Location = new Point(175, 247);
            txtEpsilon.Name = "txtEpsilon";
            txtEpsilon.Size = new Size(125, 27);
            txtEpsilon.TabIndex = 7;
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblResultado.AutoSize = true;
            lblResultado.BackColor = SystemColors.ActiveCaption;
            lblResultado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(28, 489);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(75, 20);
            lblResultado.TabIndex = 13;
            lblResultado.Text = "Resultado";
            // 
            // lblFuncion
            // 
            lblFuncion.AutoSize = true;
            lblFuncion.BackColor = SystemColors.Control;
            lblFuncion.ForeColor = SystemColors.MenuHighlight;
            lblFuncion.Location = new Point(28, 22);
            lblFuncion.Name = "lblFuncion";
            lblFuncion.Size = new Size(41, 20);
            lblFuncion.TabIndex = 0;
            lblFuncion.Text = "f(x)=";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.BackColor = Color.FromArgb(192, 57, 43);
            btnLimpiar.Location = new Point(112, 452);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(91, 29);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtFuncion
            // 
            txtFuncion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFuncion.BackColor = SystemColors.ScrollBar;
            txtFuncion.Location = new Point(28, 56);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(122, 27);
            txtFuncion.TabIndex = 1;
            // 
            // btnProceso
            // 
            btnProceso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnProceso.BackColor = Color.FromArgb(46, 109, 164);
            btnProceso.Location = new Point(112, 409);
            btnProceso.Name = "btnProceso";
            btnProceso.Size = new Size(91, 29);
            btnProceso.TabIndex = 11;
            btnProceso.Text = "Proceso";
            btnProceso.UseVisualStyleBackColor = false;
            btnProceso.Click += btnProceso_Click;
            // 
            // lblDespeje
            // 
            lblDespeje.AutoSize = true;
            lblDespeje.ForeColor = SystemColors.MenuHighlight;
            lblDespeje.Location = new Point(28, 149);
            lblDespeje.Name = "lblDespeje";
            lblDespeje.Size = new Size(122, 20);
            lblDespeje.TabIndex = 2;
            lblDespeje.Text = "g(x) despejada =";
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCalcular.BackColor = Color.SeaGreen;
            btnCalcular.ForeColor = SystemColors.ControlText;
            btnCalcular.Location = new Point(112, 366);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(91, 29);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // txtDespeje
            // 
            txtDespeje.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDespeje.BackColor = SystemColors.ScrollBar;
            txtDespeje.Location = new Point(28, 172);
            txtDespeje.Name = "txtDespeje";
            txtDespeje.Size = new Size(122, 27);
            txtDespeje.TabIndex = 3;
            // 
            // txtMaxIter
            // 
            txtMaxIter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaxIter.BackColor = SystemColors.ScrollBar;
            txtMaxIter.Location = new Point(28, 321);
            txtMaxIter.Name = "txtMaxIter";
            txtMaxIter.Size = new Size(122, 27);
            txtMaxIter.TabIndex = 9;
            // 
            // txtXo
            // 
            txtXo.AutoSize = true;
            txtXo.BackColor = SystemColors.Control;
            txtXo.ForeColor = SystemColors.MenuHighlight;
            txtXo.Location = new Point(28, 224);
            txtXo.Name = "txtXo";
            txtXo.Size = new Size(27, 20);
            txtXo.TabIndex = 4;
            txtXo.Text = "Xo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(28, 298);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 8;
            label1.Text = "Máx. iteraciones";
            // 
            // txtEpsilo
            // 
            txtEpsilo.AutoSize = true;
            txtEpsilo.ForeColor = SystemColors.MenuHighlight;
            txtEpsilo.Location = new Point(175, 224);
            txtEpsilo.Name = "txtEpsilo";
            txtEpsilo.Size = new Size(28, 20);
            txtEpsilo.TabIndex = 5;
            txtEpsilo.Text = "ε%";
            // 
            // txtX0
            // 
            txtX0.BackColor = SystemColors.ScrollBar;
            txtX0.Location = new Point(28, 247);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(125, 27);
            txtX0.TabIndex = 6;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(plotView1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(573, 553);
            splitContainer2.SplitterDistance = 348;
            splitContainer2.TabIndex = 0;
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.White;
            plotView1.Dock = DockStyle.Fill;
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.RightToLeft = RightToLeft.No;
            plotView1.Size = new Size(573, 348);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(573, 201);
            dataGridView1.TabIndex = 0;
            // 
            // metodo_punto_fijo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(882, 553);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(700, 500);
            Name = "metodo_punto_fijo";
            Text = "Método de Punto Fijo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblFuncion;
        private TextBox txtFuncion;
        private Label txtEpsilo;
        private Label txtXo;
        private TextBox txtDespeje;
        private Label lblDespeje;
        private TextBox txtEpsilon;
        private TextBox txtX0;
        private TextBox txtMaxIter;
        private Label label1;
        private Button btnLimpiar;
        private Button btnProceso;
        private Button btnCalcular;
        private Label lblResultado;
        private SplitContainer splitContainer2;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private DataGridView dataGridView1;
        private Button btnDespeje;
        private Panel panel1;
    }
}
