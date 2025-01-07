namespace SCM
{
    partial class frmCargoCompra_Mod_Precios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoCompra_Mod_Precios));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pCantidades = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPVP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidad1 = new System.Windows.Forms.Label();
            this.nudPVF = new System.Windows.Forms.NumericUpDown();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.cbVenc = new System.Windows.Forms.CheckBox();
            this.cbLote = new System.Windows.Forms.CheckBox();
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPVP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPVF)).BeginInit();
            this.SuspendLayout();
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
            this.btnGuardar.Location = new System.Drawing.Point(206, 91);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 20;
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
            this.btnCancelar.Location = new System.Drawing.Point(306, 91);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 1);
            this.label5.TabIndex = 18;
            // 
            // pCantidades
            // 
            this.pCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCantidades.Controls.Add(this.label7);
            this.pCantidades.Controls.Add(this.label8);
            this.pCantidades.Controls.Add(this.txtLote);
            this.pCantidades.Controls.Add(this.label6);
            this.pCantidades.Controls.Add(this.label4);
            this.pCantidades.Controls.Add(this.dtpVencimiento);
            this.pCantidades.Controls.Add(this.label2);
            this.pCantidades.Controls.Add(this.nudPVP);
            this.pCantidades.Controls.Add(this.label1);
            this.pCantidades.Controls.Add(this.label3);
            this.pCantidades.Controls.Add(this.lblCantidad1);
            this.pCantidades.Controls.Add(this.nudPVF);
            this.pCantidades.Location = new System.Drawing.Point(12, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(391, 61);
            this.pCantidades.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(271, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "*";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(271, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "*";
            // 
            // txtLote
            // 
            this.txtLote.Enabled = false;
            this.txtLote.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLote.Location = new System.Drawing.Point(289, 34);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(100, 21);
            this.txtLote.TabIndex = 3;
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLote.Visible = false;
            this.txtLote.Enter += new System.EventHandler(this.txtLote_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(217, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 41;
            this.label6.Text = "LOTE #:";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(94, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "*";
            this.label4.Visible = false;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Enabled = false;
            this.dtpVencimiento.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(112, 34);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(99, 21);
            this.dtpVencimiento.TabIndex = 2;
            this.dtpVencimiento.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "VENCIMIENTO:";
            this.label2.Visible = false;
            // 
            // nudPVP
            // 
            this.nudPVP.DecimalPlaces = 2;
            this.nudPVP.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudPVP.Location = new System.Drawing.Point(289, 6);
            this.nudPVP.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudPVP.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPVP.Name = "nudPVP";
            this.nudPVP.Size = new System.Drawing.Size(100, 22);
            this.nudPVP.TabIndex = 1;
            this.nudPVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPVP.Enter += new System.EventHandler(this.nudPVP_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(217, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "PVP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(94, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "*";
            // 
            // lblCantidad1
            // 
            this.lblCantidad1.AutoSize = true;
            this.lblCantidad1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad1.Location = new System.Drawing.Point(0, 8);
            this.lblCantidad1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad1.Name = "lblCantidad1";
            this.lblCantidad1.Size = new System.Drawing.Size(80, 14);
            this.lblCantidad1.TabIndex = 34;
            this.lblCantidad1.Text = "P/COMPRA:";
            // 
            // nudPVF
            // 
            this.nudPVF.DecimalPlaces = 2;
            this.nudPVF.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudPVF.Location = new System.Drawing.Point(112, 6);
            this.nudPVF.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudPVF.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPVF.Name = "nudPVF";
            this.nudPVF.Size = new System.Drawing.Size(99, 22);
            this.nudPVF.TabIndex = 0;
            this.nudPVF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPVF.Enter += new System.EventHandler(this.nudPVF_Enter);
            // 
            // cbVenc
            // 
            this.cbVenc.AutoSize = true;
            this.cbVenc.Location = new System.Drawing.Point(12, 100);
            this.cbVenc.Name = "cbVenc";
            this.cbVenc.Size = new System.Drawing.Size(104, 19);
            this.cbVenc.TabIndex = 22;
            this.cbVenc.TabStop = false;
            this.cbVenc.Text = "VENCIMIENTO";
            this.cbVenc.UseVisualStyleBackColor = true;
            this.cbVenc.Visible = false;
            this.cbVenc.CheckedChanged += new System.EventHandler(this.cbVenc_CheckedChanged);
            // 
            // cbLote
            // 
            this.cbLote.AutoSize = true;
            this.cbLote.Location = new System.Drawing.Point(119, 100);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(56, 19);
            this.cbLote.TabIndex = 23;
            this.cbLote.TabStop = false;
            this.cbLote.Text = "LOTE";
            this.cbLote.UseVisualStyleBackColor = true;
            this.cbLote.Visible = false;
            this.cbLote.CheckedChanged += new System.EventHandler(this.cbLote_CheckedChanged);
            // 
            // frmCargoCompra_Mod_Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 137);
            this.Controls.Add(this.cbLote);
            this.Controls.Add(this.cbVenc);
            this.Controls.Add(this.pCantidades);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargoCompra_Mod_Precios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACTUALIZAR LOS DATOS DEL PRODUCTO";
            this.Load += new System.EventHandler(this.frmCargoCompra_Mod_Precios_Load);
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPVP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPVF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pCantidades;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCantidad1;
        public System.Windows.Forms.NumericUpDown nudPVF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudPVP;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLote;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.CheckBox cbVenc;
        private System.Windows.Forms.CheckBox cbLote;
        private System.Windows.Forms.Label label7;
    }
}