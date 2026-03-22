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
            btnDespeje = new Button();
            lblResultado = new Label();
            btnLimpiar = new Button();
            btnProceso = new Button();
            btnCalcular = new Button();
            txtMaxIter = new TextBox();
            label1 = new Label();
            txtEpsilon = new TextBox();
            txtX0 = new TextBox();
            txtEpsilo = new Label();
            txtXo = new Label();
            txtDespeje = new TextBox();
            lblDespeje = new Label();
            txtFuncion = new TextBox();
            lblFuncion = new Label();
            splitContainer2 = new SplitContainer();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnDespeje);
            splitContainer1.Panel1.Controls.Add(lblResultado);
            splitContainer1.Panel1.Controls.Add(btnLimpiar);
            splitContainer1.Panel1.Controls.Add(btnProceso);
            splitContainer1.Panel1.Controls.Add(btnCalcular);
            splitContainer1.Panel1.Controls.Add(txtMaxIter);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(txtEpsilon);
            splitContainer1.Panel1.Controls.Add(txtX0);
            splitContainer1.Panel1.Controls.Add(txtEpsilo);
            splitContainer1.Panel1.Controls.Add(txtXo);
            splitContainer1.Panel1.Controls.Add(txtDespeje);
            splitContainer1.Panel1.Controls.Add(lblDespeje);
            splitContainer1.Panel1.Controls.Add(txtFuncion);
            splitContainer1.Panel1.Controls.Add(lblFuncion);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(882, 553);
            splitContainer1.SplitterDistance = 305;
            splitContainer1.TabIndex = 0;
            // 
            // btnDespeje
            // 
            btnDespeje.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDespeje.Location = new Point(22, 80);
            btnDespeje.Name = "btnDespeje";
            btnDespeje.Size = new Size(164, 29);
            btnDespeje.TabIndex = 14;
            btnDespeje.Text = "auto despeje";
            btnDespeje.UseVisualStyleBackColor = true;
            btnDespeje.Click += btnDespeje_Click;
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblResultado.AutoSize = true;
            lblResultado.BackColor = SystemColors.ActiveCaption;
            lblResultado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(22, 515);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(75, 20);
            lblResultado.TabIndex = 13;
            lblResultado.Text = "Resultado";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.Location = new Point(83, 452);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(133, 29);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnProceso
            // 
            btnProceso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnProceso.Location = new Point(83, 409);
            btnProceso.Name = "btnProceso";
            btnProceso.Size = new Size(133, 29);
            btnProceso.TabIndex = 11;
            btnProceso.Text = "Proceso";
            btnProceso.UseVisualStyleBackColor = true;
            btnProceso.Click += btnProceso_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCalcular.Location = new Point(83, 366);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(133, 29);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // txtMaxIter
            // 
            txtMaxIter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaxIter.Location = new Point(22, 312);
            txtMaxIter.Name = "txtMaxIter";
            txtMaxIter.Size = new Size(164, 27);
            txtMaxIter.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 289);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 8;
            label1.Text = "Máx. iteraciones";
            // 
            // txtEpsilon
            // 
            txtEpsilon.Location = new Point(169, 238);
            txtEpsilon.Name = "txtEpsilon";
            txtEpsilon.Size = new Size(125, 27);
            txtEpsilon.TabIndex = 7;
            // 
            // txtX0
            // 
            txtX0.Location = new Point(22, 238);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(125, 27);
            txtX0.TabIndex = 6;
            // 
            // txtEpsilo
            // 
            txtEpsilo.AutoSize = true;
            txtEpsilo.Location = new Point(169, 215);
            txtEpsilo.Name = "txtEpsilo";
            txtEpsilo.Size = new Size(28, 20);
            txtEpsilo.TabIndex = 5;
            txtEpsilo.Text = "ε%";
            // 
            // txtXo
            // 
            txtXo.AutoSize = true;
            txtXo.Location = new Point(22, 215);
            txtXo.Name = "txtXo";
            txtXo.Size = new Size(27, 20);
            txtXo.TabIndex = 4;
            txtXo.Text = "Xo";
            // 
            // txtDespeje
            // 
            txtDespeje.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDespeje.Location = new Point(22, 163);
            txtDespeje.Name = "txtDespeje";
            txtDespeje.Size = new Size(164, 27);
            txtDespeje.TabIndex = 3;
            // 
            // lblDespeje
            // 
            lblDespeje.AutoSize = true;
            lblDespeje.Location = new Point(22, 140);
            lblDespeje.Name = "lblDespeje";
            lblDespeje.Size = new Size(122, 20);
            lblDespeje.TabIndex = 2;
            lblDespeje.Text = "g(x) despejada =";
            // 
            // txtFuncion
            // 
            txtFuncion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFuncion.Location = new Point(22, 47);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(164, 27);
            txtFuncion.TabIndex = 1;
            // 
            // lblFuncion
            // 
            lblFuncion.AutoSize = true;
            lblFuncion.Location = new Point(22, 13);
            lblFuncion.Name = "lblFuncion";
            lblFuncion.Size = new Size(41, 20);
            lblFuncion.TabIndex = 0;
            lblFuncion.Text = "f(x)=";
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
            ClientSize = new Size(882, 553);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(700, 500);
            Name = "metodo_punto_fijo";
            Text = "Método de Punto Fijo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}
