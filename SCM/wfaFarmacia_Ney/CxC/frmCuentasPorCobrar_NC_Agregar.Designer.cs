namespace SCM.CxC
{
    partial class frmCuentasPorCobrar_NC_Agregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentasPorCobrar_NC_Agregar));
            this.label10 = new System.Windows.Forms.Label();
            this.mtxtNC = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxtRUC = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtObser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.mtxtFactura = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(135, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 14);
            this.label10.TabIndex = 62;
            this.label10.Text = "*";
            // 
            // mtxtNC
            // 
            this.mtxtNC.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtNC.Location = new System.Drawing.Point(153, 15);
            this.mtxtNC.Name = "mtxtNC";
            this.mtxtNC.Size = new System.Drawing.Size(99, 22);
            this.mtxtNC.TabIndex = 0;
            this.mtxtNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtNC.TextChanged += new System.EventHandler(this.mtxtNC_TextChanged);
            this.mtxtNC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtNC_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 61;
            this.label1.Text = "NC #:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 14);
            this.label4.TabIndex = 64;
            this.label4.Text = "FECHA DOCUMENTO:";
            // 
            // dtpFechaDoc
            // 
            this.dtpFechaDoc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDoc.Location = new System.Drawing.Point(153, 43);
            this.dtpFechaDoc.Name = "dtpFechaDoc";
            this.dtpFechaDoc.Size = new System.Drawing.Size(99, 22);
            this.dtpFechaDoc.TabIndex = 1;
            this.dtpFechaDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaDoc_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 66;
            this.label6.Text = "RUC:";
            // 
            // mtxtRUC
            // 
            this.mtxtRUC.Enabled = false;
            this.mtxtRUC.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtRUC.Location = new System.Drawing.Point(153, 96);
            this.mtxtRUC.Mask = "#############";
            this.mtxtRUC.Name = "mtxtRUC";
            this.mtxtRUC.Size = new System.Drawing.Size(128, 22);
            this.mtxtRUC.TabIndex = 65;
            this.mtxtRUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtRUC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtRUC_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 74;
            this.label5.Text = "TELÉFONO:";
            // 
            // mtxtTelefono
            // 
            this.mtxtTelefono.Enabled = false;
            this.mtxtTelefono.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtTelefono.Location = new System.Drawing.Point(154, 196);
            this.mtxtTelefono.Mask = "##-#######";
            this.mtxtTelefono.Name = "mtxtTelefono";
            this.mtxtTelefono.Size = new System.Drawing.Size(109, 22);
            this.mtxtTelefono.TabIndex = 72;
            this.mtxtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtTelefono_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 14);
            this.label7.TabIndex = 73;
            this.label7.Text = "DIRECCIÓN:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(153, 154);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(311, 36);
            this.txtDireccion.TabIndex = 71;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // txtObser
            // 
            this.txtObser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObser.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtObser.Location = new System.Drawing.Point(154, 224);
            this.txtObser.Multiline = true;
            this.txtObser.Name = "txtObser";
            this.txtObser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObser.Size = new System.Drawing.Size(310, 61);
            this.txtObser.TabIndex = 2;
            this.txtObser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObser_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 14);
            this.label8.TabIndex = 76;
            this.label8.Text = "OBSERVACIÓN:";
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
            this.btnGuardar.Location = new System.Drawing.Point(445, 307);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 79;
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
            this.btnCancelar.Location = new System.Drawing.Point(545, 307);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 78;
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
            this.label18.Location = new System.Drawing.Point(16, 297);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(627, 1);
            this.label18.TabIndex = 77;
            // 
            // mtxtFactura
            // 
            this.mtxtFactura.Enabled = false;
            this.mtxtFactura.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtFactura.Location = new System.Drawing.Point(153, 68);
            this.mtxtFactura.Name = "mtxtFactura";
            this.mtxtFactura.Size = new System.Drawing.Size(99, 22);
            this.mtxtFactura.TabIndex = 80;
            this.mtxtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFactura_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 81;
            this.label2.Text = "VENTA AFECT. #:";
            // 
            // btnCliente
            // 
            this.btnCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCliente.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnCliente.Enabled = false;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(15, 307);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(97, 34);
            this.btnCliente.TabIndex = 82;
            this.btnCliente.TabStop = false;
            this.btnCliente.Text = "&CLIENTES";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnProv_Click);
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCliente.Location = new System.Drawing.Point(153, 124);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(311, 22);
            this.txtCliente.TabIndex = 83;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProv_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 14);
            this.label9.TabIndex = 84;
            this.label9.Text = "CLIENTE:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(465, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 279);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // frmCuentasPorCobrar_NC_Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(654, 353);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtFactura);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtxtTelefono);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtxtRUC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaDoc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mtxtNC);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCuentasPorCobrar_NC_Agregar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCIONES";
            this.Load += new System.EventHandler(this.frmCuentasPorCobrar_NC_Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.MaskedTextBox mtxtNC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpFechaDoc;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.MaskedTextBox mtxtRUC;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MaskedTextBox mtxtTelefono;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.TextBox txtObser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.MaskedTextBox mtxtFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCliente;
        public System.Windows.Forms.Timer tEnfoque;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}