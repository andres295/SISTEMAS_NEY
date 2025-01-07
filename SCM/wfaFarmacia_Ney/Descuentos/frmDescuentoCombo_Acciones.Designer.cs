namespace SCM.Descuentos
{
    partial class frmDescuentoCombo_Acciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescuentoCombo_Acciones));
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudPrecioCombo = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.nudCantidadMinima = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCantidadMaxima = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMinima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaxima)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "FECHA INICIO:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(134, 174);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(99, 22);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaDoc_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(137, 30);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(369, 39);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObserv_KeyPress);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(12, 244);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(700, 1);
            this.label18.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(119, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 14);
            this.label5.TabIndex = 72;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "DESCRIPCIÓN:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(134, 206);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(99, 22);
            this.dtpFechaFin.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 76;
            this.label1.Text = "FECHA FIN:";
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
            this.btnCancelar.Location = new System.Drawing.Point(615, 267);
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(515, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
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
            this.btnGuardar.Location = new System.Drawing.Point(515, 267);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(119, 83);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 14);
            this.label19.TabIndex = 117;
            this.label19.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(12, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 14);
            this.label12.TabIndex = 116;
            this.label12.Text = "PVP COMBO:";
            // 
            // nudPrecioCombo
            // 
            this.nudPrecioCombo.DecimalPlaces = 2;
            this.nudPrecioCombo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudPrecioCombo.Location = new System.Drawing.Point(137, 78);
            this.nudPrecioCombo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPrecioCombo.Name = "nudPrecioCombo";
            this.nudPrecioCombo.Size = new System.Drawing.Size(96, 22);
            this.nudPrecioCombo.TabIndex = 115;
            this.nudPrecioCombo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.Color.Navy;
            this.label25.Location = new System.Drawing.Point(12, 115);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 14);
            this.label25.TabIndex = 119;
            this.label25.Text = "CANT. MINIMA:";
            // 
            // nudCantidadMinima
            // 
            this.nudCantidadMinima.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidadMinima.Location = new System.Drawing.Point(137, 110);
            this.nudCantidadMinima.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCantidadMinima.Name = "nudCantidadMinima";
            this.nudCantidadMinima.Size = new System.Drawing.Size(96, 22);
            this.nudCantidadMinima.TabIndex = 118;
            this.nudCantidadMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 121;
            this.label2.Text = "CANT. MAXIMA:";
            // 
            // nudCantidadMaxima
            // 
            this.nudCantidadMaxima.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidadMaxima.Location = new System.Drawing.Point(137, 141);
            this.nudCantidadMaxima.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCantidadMaxima.Name = "nudCantidadMaxima";
            this.nudCantidadMaxima.Size = new System.Drawing.Size(96, 22);
            this.nudCantidadMaxima.TabIndex = 120;
            this.nudCantidadMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(119, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 122;
            this.label3.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(119, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 123;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 14);
            this.label8.TabIndex = 124;
            this.label8.Text = "ID:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(134, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(15, 14);
            this.lblID.TabIndex = 125;
            this.lblID.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(12, 267);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 14);
            this.label17.TabIndex = 127;
            this.label17.Text = "ESTADO:";
            // 
            // cbEstado
            // 
            this.cbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEstado.BackColor = System.Drawing.Color.Transparent;
            this.cbEstado.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbEstado.Checked = true;
            this.cbEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEstado.Location = new System.Drawing.Point(134, 257);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(34, 24);
            this.cbEstado.TabIndex = 126;
            this.cbEstado.TabStop = false;
            this.cbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbEstado.UseVisualStyleBackColor = false;
            // 
            // frmDescuentoCombo_Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(724, 313);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudCantidadMaxima);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.nudCantidadMinima);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudPrecioCombo);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDescuentoCombo_Acciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCIONES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoAjuste_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmDescuentoCombo_Acciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMinima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaxima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown nudPrecioCombo;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.NumericUpDown nudCantidadMinima;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudCantidadMaxima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.CheckBox cbEstado;
    }
}