namespace SCM
{
    partial class frmCargoCompra_Opciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoCompra_Opciones));
            this.cbIVA = new System.Windows.Forms.CheckBox();
            this.cbDesc = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnIVA_Todos = new System.Windows.Forms.RadioButton();
            this.rbtnIVA_Sel = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnDesc_Todos = new System.Windows.Forms.RadioButton();
            this.rbtnDesc_Sel = new System.Windows.Forms.RadioButton();
            this.nuDescuento = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIVA
            // 
            this.cbIVA.AutoSize = true;
            this.cbIVA.Location = new System.Drawing.Point(29, 97);
            this.cbIVA.Name = "cbIVA";
            this.cbIVA.Size = new System.Drawing.Size(52, 18);
            this.cbIVA.TabIndex = 0;
            this.cbIVA.Text = "IVA:";
            this.cbIVA.UseVisualStyleBackColor = true;
            this.cbIVA.CheckedChanged += new System.EventHandler(this.cbIVA_CheckedChanged);
            // 
            // cbDesc
            // 
            this.cbDesc.AutoSize = true;
            this.cbDesc.Location = new System.Drawing.Point(29, 16);
            this.cbDesc.Name = "cbDesc";
            this.cbDesc.Size = new System.Drawing.Size(101, 18);
            this.cbDesc.TabIndex = 1;
            this.cbDesc.Text = "DESCUENTO:";
            this.cbDesc.UseVisualStyleBackColor = true;
            this.cbDesc.CheckedChanged += new System.EventHandler(this.cbDesc_CheckedChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(64, 174);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 71;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(164, 174);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(12, 164);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(316, 1);
            this.label18.TabIndex = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnIVA_Todos);
            this.panel1.Controls.Add(this.rbtnIVA_Sel);
            this.panel1.Location = new System.Drawing.Point(29, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 26);
            this.panel1.TabIndex = 72;
            // 
            // rbtnIVA_Todos
            // 
            this.rbtnIVA_Todos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnIVA_Todos.AutoSize = true;
            this.rbtnIVA_Todos.ForeColor = System.Drawing.Color.Blue;
            this.rbtnIVA_Todos.Location = new System.Drawing.Point(158, 4);
            this.rbtnIVA_Todos.Name = "rbtnIVA_Todos";
            this.rbtnIVA_Todos.Size = new System.Drawing.Size(67, 18);
            this.rbtnIVA_Todos.TabIndex = 5;
            this.rbtnIVA_Todos.Text = "TODOS";
            this.rbtnIVA_Todos.UseVisualStyleBackColor = true;
            // 
            // rbtnIVA_Sel
            // 
            this.rbtnIVA_Sel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnIVA_Sel.AutoSize = true;
            this.rbtnIVA_Sel.Checked = true;
            this.rbtnIVA_Sel.ForeColor = System.Drawing.Color.Blue;
            this.rbtnIVA_Sel.Location = new System.Drawing.Point(33, 4);
            this.rbtnIVA_Sel.Name = "rbtnIVA_Sel";
            this.rbtnIVA_Sel.Size = new System.Drawing.Size(119, 18);
            this.rbtnIVA_Sel.TabIndex = 4;
            this.rbtnIVA_Sel.TabStop = true;
            this.rbtnIVA_Sel.Text = "SELECCIONADO";
            this.rbtnIVA_Sel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnDesc_Todos);
            this.panel2.Controls.Add(this.rbtnDesc_Sel);
            this.panel2.Location = new System.Drawing.Point(29, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 26);
            this.panel2.TabIndex = 73;
            // 
            // rbtnDesc_Todos
            // 
            this.rbtnDesc_Todos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnDesc_Todos.AutoSize = true;
            this.rbtnDesc_Todos.ForeColor = System.Drawing.Color.Blue;
            this.rbtnDesc_Todos.Location = new System.Drawing.Point(158, 4);
            this.rbtnDesc_Todos.Name = "rbtnDesc_Todos";
            this.rbtnDesc_Todos.Size = new System.Drawing.Size(67, 18);
            this.rbtnDesc_Todos.TabIndex = 5;
            this.rbtnDesc_Todos.Text = "TODOS";
            this.rbtnDesc_Todos.UseVisualStyleBackColor = true;
            // 
            // rbtnDesc_Sel
            // 
            this.rbtnDesc_Sel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnDesc_Sel.AutoSize = true;
            this.rbtnDesc_Sel.Checked = true;
            this.rbtnDesc_Sel.ForeColor = System.Drawing.Color.Blue;
            this.rbtnDesc_Sel.Location = new System.Drawing.Point(33, 4);
            this.rbtnDesc_Sel.Name = "rbtnDesc_Sel";
            this.rbtnDesc_Sel.Size = new System.Drawing.Size(119, 18);
            this.rbtnDesc_Sel.TabIndex = 4;
            this.rbtnDesc_Sel.TabStop = true;
            this.rbtnDesc_Sel.Text = "SELECCIONADO";
            this.rbtnDesc_Sel.UseVisualStyleBackColor = true;
            // 
            // nuDescuento
            // 
            this.nuDescuento.DecimalPlaces = 2;
            this.nuDescuento.Enabled = false;
            this.nuDescuento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuDescuento.ForeColor = System.Drawing.Color.Black;
            this.nuDescuento.Location = new System.Drawing.Point(156, 35);
            this.nuDescuento.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nuDescuento.Name = "nuDescuento";
            this.nuDescuento.Size = new System.Drawing.Size(75, 22);
            this.nuDescuento.TabIndex = 74;
            this.nuDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(26, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 14);
            this.label8.TabIndex = 75;
            this.label8.Text = "PORC. DESCUENTO:";
            // 
            // frmCargoCompra_Opciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(340, 220);
            this.Controls.Add(this.nuDescuento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbDesc);
            this.Controls.Add(this.cbIVA);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargoCompra_Opciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPCIONES";
            this.Load += new System.EventHandler(this.frmCargoCompra_Opciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.CheckBox cbIVA;
        public System.Windows.Forms.CheckBox cbDesc;
        public System.Windows.Forms.RadioButton rbtnIVA_Todos;
        public System.Windows.Forms.RadioButton rbtnIVA_Sel;
        public System.Windows.Forms.RadioButton rbtnDesc_Todos;
        public System.Windows.Forms.RadioButton rbtnDesc_Sel;
        public System.Windows.Forms.NumericUpDown nuDescuento;
        private System.Windows.Forms.Label label8;
    }
}