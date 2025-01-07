namespace SCM
{
    partial class frmCargoAjuste_Acciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoAjuste_Acciones));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.txtTipoMov = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
            this.txtObserv = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProveedor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROVEEDOR:";
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlmacen.Enabled = false;
            this.txtAlmacen.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAlmacen.Location = new System.Drawing.Point(175, 12);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(38, 22);
            this.txtAlmacen.TabIndex = 3;
            this.txtAlmacen.Text = "M";
            this.txtAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTipoMov
            // 
            this.txtTipoMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoMov.Enabled = false;
            this.txtTipoMov.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTipoMov.Location = new System.Drawing.Point(175, 40);
            this.txtTipoMov.Name = "txtTipoMov";
            this.txtTipoMov.Size = new System.Drawing.Size(38, 22);
            this.txtTipoMov.TabIndex = 4;
            this.txtTipoMov.Text = "CJ";
            this.txtTipoMov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "ALMACEN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "TIPO DE MOVIMIENTO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "FECHA DEL DOCUMENTO:";
            // 
            // dtpFechaDoc
            // 
            this.dtpFechaDoc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDoc.Location = new System.Drawing.Point(175, 97);
            this.dtpFechaDoc.Name = "dtpFechaDoc";
            this.dtpFechaDoc.Size = new System.Drawing.Size(99, 22);
            this.dtpFechaDoc.TabIndex = 1;
            this.dtpFechaDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaDoc_KeyPress);
            // 
            // txtObserv
            // 
            this.txtObserv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObserv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObserv.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtObserv.Location = new System.Drawing.Point(175, 125);
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObserv.Size = new System.Drawing.Size(351, 62);
            this.txtObserv.TabIndex = 2;
            this.txtObserv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObserv_KeyPress);
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
            this.btnGuardar.Location = new System.Drawing.Point(515, 210);
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
            this.btnCancelar.Location = new System.Drawing.Point(615, 210);
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
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(12, 200);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(700, 1);
            this.label18.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(157, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 14);
            this.label5.TabIndex = 72;
            this.label5.Text = "*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(527, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "OBSERVACION:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProveedor.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbProveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbProveedor.Location = new System.Drawing.Point(175, 68);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(351, 21);
            this.cmbProveedor.TabIndex = 95;
            // 
            // frmCargoAjuste_Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(724, 256);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtObserv);
            this.Controls.Add(this.dtpFechaDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTipoMov);
            this.Controls.Add(this.txtAlmacen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargoAjuste_Acciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCIONES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoAjuste_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmCargoAjuste_Acciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtAlmacen;
        public System.Windows.Forms.TextBox txtTipoMov;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpFechaDoc;
        public System.Windows.Forms.TextBox txtObserv;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbProveedor;
    }
}