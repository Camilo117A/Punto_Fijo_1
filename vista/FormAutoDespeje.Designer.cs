namespace Punto_Fijo_1.vista
{
    partial class FormAutoDespeje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            btnCancelar = new Button();
            btnUsarDespeje = new Button();
            rtbPreview = new RichTextBox();
            lblTitPreview = new Label();
            lblMejorGx = new Label();
            lblTitMejor = new Label();
            lblFuncionIngresada = new Label();
            lblTitFuncion = new Label();
            lblDescripcion = new Label();
            listViewCandidatos = new ListView();
            colGx = new ColumnHeader();
            colEstado = new ColumnHeader();
            colDescripcion = new ColumnHeader();
            lblTitCandidatos = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(btnCancelar);
            splitContainer1.Panel1.Controls.Add(btnUsarDespeje);
            splitContainer1.Panel1.Controls.Add(rtbPreview);
            splitContainer1.Panel1.Controls.Add(lblTitPreview);
            splitContainer1.Panel1.Controls.Add(lblMejorGx);
            splitContainer1.Panel1.Controls.Add(lblTitMejor);
            splitContainer1.Panel1.Controls.Add(lblFuncionIngresada);
            splitContainer1.Panel1.Controls.Add(lblTitFuncion);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblDescripcion);
            splitContainer1.Panel2.Controls.Add(listViewCandidatos);
            splitContainer1.Panel2.Controls.Add(lblTitCandidatos);
            splitContainer1.Size = new Size(885, 535);
            splitContainer1.SplitterDistance = 259;
            splitContainer1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancelar.Location = new Point(44, 458);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnUsarDespeje
            // 
            btnUsarDespeje.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUsarDespeje.Location = new Point(44, 410);
            btnUsarDespeje.Name = "btnUsarDespeje";
            btnUsarDespeje.Size = new Size(156, 29);
            btnUsarDespeje.TabIndex = 6;
            btnUsarDespeje.Text = "Usar este despeje";
            btnUsarDespeje.UseVisualStyleBackColor = true;
            btnUsarDespeje.Click += btnUsarDespeje_Click;
            // 
            // rtbPreview
            // 
            rtbPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbPreview.Location = new Point(24, 205);
            rtbPreview.Name = "rtbPreview";
            rtbPreview.ReadOnly = true;
            rtbPreview.Size = new Size(217, 182);
            rtbPreview.TabIndex = 5;
            rtbPreview.Text = "";
            // 
            // lblTitPreview
            // 
            lblTitPreview.AutoSize = true;
            lblTitPreview.Location = new Point(24, 182);
            lblTitPreview.Name = "lblTitPreview";
            lblTitPreview.Size = new Size(139, 20);
            lblTitPreview.TabIndex = 4;
            lblTitPreview.Text = "Preview iteraciones:";
            // 
            // lblMejorGx
            // 
            lblMejorGx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMejorGx.AutoSize = true;
            lblMejorGx.Location = new Point(24, 134);
            lblMejorGx.Name = "lblMejorGx";
            lblMejorGx.Size = new Size(45, 20);
            lblMejorGx.TabIndex = 3;
            lblMejorGx.Text = "******";
            // 
            // lblTitMejor
            // 
            lblTitMejor.AutoSize = true;
            lblTitMejor.Location = new Point(24, 103);
            lblTitMejor.Name = "lblTitMejor";
            lblTitMejor.Size = new Size(142, 20);
            lblTitMejor.TabIndex = 2;
            lblTitMejor.Text = "Mejor g(x) sugerida:";
            // 
            // lblFuncionIngresada
            // 
            lblFuncionIngresada.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFuncionIngresada.AutoSize = true;
            lblFuncionIngresada.Location = new Point(24, 55);
            lblFuncionIngresada.Name = "lblFuncionIngresada";
            lblFuncionIngresada.Size = new Size(45, 20);
            lblFuncionIngresada.TabIndex = 1;
            lblFuncionIngresada.Text = "******";
            // 
            // lblTitFuncion
            // 
            lblTitFuncion.AutoSize = true;
            lblTitFuncion.Location = new Point(24, 26);
            lblTitFuncion.Name = "lblTitFuncion";
            lblTitFuncion.Size = new Size(103, 20);
            lblTitFuncion.TabIndex = 0;
            lblTitFuncion.Text = "f(x) ingresada:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(18, 415);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(39, 20);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "*****";
            // 
            // listViewCandidatos
            // 
            listViewCandidatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewCandidatos.Columns.AddRange(new ColumnHeader[] { colGx, colEstado, colDescripcion });
            listViewCandidatos.FullRowSelect = true;
            listViewCandidatos.Location = new Point(18, 55);
            listViewCandidatos.Name = "listViewCandidatos";
            listViewCandidatos.Size = new Size(592, 332);
            listViewCandidatos.TabIndex = 1;
            listViewCandidatos.UseCompatibleStateImageBehavior = false;
            listViewCandidatos.View = View.Details;
            listViewCandidatos.SelectedIndexChanged += listViewCandidatos_SelectedIndexChanged;
            listViewCandidatos.DoubleClick += listViewCandidatos_DoubleClick;
            // 
            // colGx
            // 
            colGx.Text = "G(x)";
            colGx.Width = 200;
            // 
            // colEstado
            // 
            colEstado.Text = "Estado";
            colEstado.Width = 80;
            // 
            // colDescripcion
            // 
            colDescripcion.Text = "Descripcion";
            colDescripcion.Width = 200;
            // 
            // lblTitCandidatos
            // 
            lblTitCandidatos.AutoSize = true;
            lblTitCandidatos.Location = new Point(18, 26);
            lblTitCandidatos.Name = "lblTitCandidatos";
            lblTitCandidatos.Size = new Size(161, 20);
            lblTitCandidatos.TabIndex = 0;
            lblTitCandidatos.Text = "Candidatos generados:";
            // 
            // FormAutoDespeje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 535);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(580, 400);
            Name = "FormAutoDespeje";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Auto despeje — candidatos g(x)";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblFuncionIngresada;
        private Label lblTitFuncion;
        private Button btnCancelar;
        private Button btnUsarDespeje;
        private RichTextBox rtbPreview;
        private Label lblTitPreview;
        private Label lblMejorGx;
        private Label lblTitMejor;
        private Label lblDescripcion;
        private ListView listViewCandidatos;
        private Label lblTitCandidatos;
        private ColumnHeader colGx;
        private ColumnHeader colEstado;
        private ColumnHeader colDescripcion;
    }
}