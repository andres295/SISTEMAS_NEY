namespace SCM
{
    partial class frmCargoCompra_Agregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoCompra_Agregar));
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtFactura = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDiasPago = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObserv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCredito = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tDias = new System.Windows.Forms.Timer(this.components);
            this.cmbProveedor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasPago)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "FACTURA #:";
            // 
            // mtxtFactura
            // 
            this.mtxtFactura.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtFactura.Location = new System.Drawing.Point(149, 12);
            this.mtxtFactura.Name = "mtxtFactura";
            this.mtxtFactura.Size = new System.Drawing.Size(175, 22);
            this.mtxtFactura.TabIndex = 0;
            this.mtxtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtFactura.TextChanged += new System.EventHandler(this.mtxtFactura_TextChanged);
            this.mtxtFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFactura_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(130, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "PROVEEDOR:";
            // 
            // dtpFechaDoc
            // 
            this.dtpFechaDoc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDoc.Location = new System.Drawing.Point(148, 69);
            this.dtpFechaDoc.Name = "dtpFechaDoc";
            this.dtpFechaDoc.Size = new System.Drawing.Size(99, 22);
            this.dtpFechaDoc.TabIndex = 2;
            this.dtpFechaDoc.ValueChanged += new System.EventHandler(this.dtpFechaDoc_ValueChanged);
            this.dtpFechaDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaDoc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 14);
            this.label4.TabIndex = 50;
            this.label4.Text = "FECHA DOCUMENTO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 51;
            this.label5.Text = "DIAS PAGO:";
            // 
            // nudDiasPago
            // 
            this.nudDiasPago.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudDiasPago.Location = new System.Drawing.Point(148, 99);
            this.nudDiasPago.Name = "nudDiasPago";
            this.nudDiasPago.Size = new System.Drawing.Size(61, 22);
            this.nudDiasPago.TabIndex = 4;
            this.nudDiasPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasPago.Enter += new System.EventHandler(this.nudDiasPago_Enter);
            this.nudDiasPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudDiasPago_KeyDown);
            this.nudDiasPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDiasPago_KeyPress);
            this.nudDiasPago.Leave += new System.EventHandler(this.nudDiasPago_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(130, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 14);
            this.label6.TabIndex = 53;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 14);
            this.label7.TabIndex = 54;
            this.label7.Text = "FECHA DE PAGO:";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.ForeColor = System.Drawing.Color.Blue;
            this.lblFechaPago.Location = new System.Drawing.Point(145, 130);
            this.lblFechaPago.Margin = new System.Windows.Forms.Padding(3, 6, 6, 7);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(85, 14);
            this.lblFechaPago.TabIndex = 5;
            this.lblFechaPago.Text = "10/10/2019";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 14);
            this.label9.TabIndex = 57;
            this.label9.Text = "OBSERVACIÓN:";
            // 
            // txtObserv
            // 
            this.txtObserv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObserv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObserv.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtObserv.Location = new System.Drawing.Point(148, 158);
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObserv.Size = new System.Drawing.Size(333, 84);
            this.txtObserv.TabIndex = 6;
            this.txtObserv.Enter += new System.EventHandler(this.txtObserv_Enter);
            this.txtObserv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObserv_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(130, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 14);
            this.label10.TabIndex = 59;
            this.label10.Text = "*";
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
            this.btnGuardar.Location = new System.Drawing.Point(284, 266);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 7;
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
            this.btnCancelar.Location = new System.Drawing.Point(384, 266);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 8;
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
            this.label18.Location = new System.Drawing.Point(12, 256);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(470, 1);
            this.label18.TabIndex = 66;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblCredito);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(253, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 70);
            this.panel1.TabIndex = 72;
            // 
            // lblCredito
            // 
            this.lblCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredito.ForeColor = System.Drawing.Color.Green;
            this.lblCredito.Location = new System.Drawing.Point(3, 48);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(222, 14);
            this.lblCredito.TabIndex = 73;
            this.lblCredito.Text = "FACTURA #:";
            this.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(98, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // tDias
            // 
            this.tDias.Enabled = true;
            this.tDias.Tick += new System.EventHandler(this.tDias_Tick);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProveedor.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbProveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbProveedor.Location = new System.Drawing.Point(148, 40);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(296, 21);
            this.cmbProveedor.TabIndex = 97;
            // 
            // frmCargoCompra_Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(494, 312);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtObserv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFechaPago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudDiasPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFactura);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargoCompra_Agregar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoCompra_Agregar_FormClosing);
            this.Load += new System.EventHandler(this.frmCargoCompra_Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasPago)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.MaskedTextBox mtxtFactura;
        public System.Windows.Forms.DateTimePicker dtpFechaDoc;
        public System.Windows.Forms.NumericUpDown nudDiasPago;
        public System.Windows.Forms.Label lblFechaPago;
        public System.Windows.Forms.TextBox txtObserv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Timer tDias;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbProveedor;
    }
}