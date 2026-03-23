namespace Punto_Fijo_1
{
    partial class proceso_detallado
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTituloPaso = new Label();
            rtbPaso = new RichTextBox();
            panelBotones = new Panel();
            lblContadorPaso = new Label();
            btnSiguiente = new Button();
            btnCerrar = new Button();
            btnAnterior = new Button();
            tableLayoutPanel1.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTituloPaso, 0, 0);
            tableLayoutPanel1.Controls.Add(rtbPaso, 0, 1);
            tableLayoutPanel1.Controls.Add(panelBotones, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // lblTituloPaso
            // 
            lblTituloPaso.BackColor = SystemColors.Info;
            lblTituloPaso.Dock = DockStyle.Fill;
            lblTituloPaso.ForeColor = SystemColors.MenuHighlight;
            lblTituloPaso.Location = new Point(3, 0);
            lblTituloPaso.Name = "lblTituloPaso";
            lblTituloPaso.Size = new Size(794, 45);
            lblTituloPaso.TabIndex = 0;
            lblTituloPaso.Text = "TituloPaso";
            lblTituloPaso.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rtbPaso
            // 
            rtbPaso.BackColor = SystemColors.Window;
            rtbPaso.Dock = DockStyle.Fill;
            rtbPaso.Location = new Point(3, 48);
            rtbPaso.Name = "rtbPaso";
            rtbPaso.ReadOnly = true;
            rtbPaso.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbPaso.Size = new Size(794, 329);
            rtbPaso.TabIndex = 1;
            rtbPaso.Text = "";
            // 
            // panelBotones
            // 
            panelBotones.BackColor = SystemColors.Info;
            panelBotones.Controls.Add(lblContadorPaso);
            panelBotones.Controls.Add(btnSiguiente);
            panelBotones.Controls.Add(btnCerrar);
            panelBotones.Controls.Add(btnAnterior);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.Location = new Point(3, 383);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(794, 64);
            panelBotones.TabIndex = 2;
            // 
            // lblContadorPaso
            // 
            lblContadorPaso.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblContadorPaso.AutoSize = true;
            lblContadorPaso.BackColor = SystemColors.GrayText;
            lblContadorPaso.Location = new Point(349, 14);
            lblContadorPaso.Name = "lblContadorPaso";
            lblContadorPaso.Size = new Size(87, 20);
            lblContadorPaso.TabIndex = 3;
            lblContadorPaso.Text = "Paso 1 de N";
            lblContadorPaso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSiguiente.BackColor = SystemColors.Highlight;
            btnSiguiente.ForeColor = SystemColors.HighlightText;
            btnSiguiente.Location = new Point(683, 15);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(102, 29);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente →";
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCerrar.BackColor = SystemColors.WindowFrame;
            btnCerrar.ForeColor = SystemColors.Window;
            btnCerrar.Location = new Point(191, 26);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAnterior.BackColor = SystemColors.Highlight;
            btnAnterior.ForeColor = SystemColors.HighlightText;
            btnAnterior.Location = new Point(9, 15);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(94, 29);
            btnAnterior.TabIndex = 0;
            btnAnterior.Text = "← Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // proceso_detallado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(400, 380);
            Name = "proceso_detallado";
            StartPosition = FormStartPosition.CenterParent;
            Text = "proceso_detallado";
            tableLayoutPanel1.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTituloPaso;
        private RichTextBox rtbPaso;
        private Panel panelBotones;
        private Button btnSiguiente;
        private Button btnCerrar;
        private Button btnAnterior;
        private Label lblContadorPaso;
    }
}