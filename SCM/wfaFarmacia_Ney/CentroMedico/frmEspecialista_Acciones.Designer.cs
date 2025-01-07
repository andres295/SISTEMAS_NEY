namespace SCM.CentroMedico
{
    partial class frmEspecialista_Acciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspecialista_Acciones));
            this.mtxtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrimerNombre = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mtxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnComposicionProducto = new System.Windows.Forms.Button();
            this.btnRefrescarPresentacion = new System.Windows.Forms.Button();
            this.txtProfesion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.CheckBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtCedula
            // 
            this.mtxtCedula.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtCedula.Location = new System.Drawing.Point(188, 12);
            this.mtxtCedula.Name = "mtxtCedula";
            this.mtxtCedula.Size = new System.Drawing.Size(132, 22);
            this.mtxtCedula.TabIndex = 0;
            this.mtxtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtCedula.TextChanged += new System.EventHandler(this.mtxtCedula_TextChanged);
            this.mtxtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCedula_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(170, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "CÉDULA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(170, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 14);
            this.label10.TabIndex = 37;
            this.label10.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 14);
            this.label3.TabIndex = 33;
            this.label3.Text = "NOMBRES Y APELLIDOS:";
            // 
            // txtPrimerNombre
            // 
            this.txtPrimerNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrimerNombre.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPrimerNombre.Location = new System.Drawing.Point(188, 40);
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Size = new System.Drawing.Size(413, 22);
            this.txtPrimerNombre.TabIndex = 1;
            this.txtPrimerNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrimerNombre_KeyPress);
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO"});
            this.cmbGenero.Location = new System.Drawing.Point(188, 68);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(109, 22);
            this.cmbGenero.TabIndex = 2;
            this.cmbGenero.DropDownClosed += new System.EventHandler(this.cmbGenero_DropDownClosed);
            this.cmbGenero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGenero_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "GÉNERO:";
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNacimiento.Location = new System.Drawing.Point(188, 96);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.Size = new System.Drawing.Size(109, 22);
            this.dtpNacimiento.TabIndex = 3;
            this.dtpNacimiento.CloseUp += new System.EventHandler(this.dtpNacimiento_CloseUp);
            this.dtpNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNacimiento_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 14);
            this.label7.TabIndex = 44;
            this.label7.Text = "FECHA NACIMIENTO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(170, 98);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 14);
            this.label8.TabIndex = 45;
            this.label8.Text = "*";
            // 
            // mtxtTelefono
            // 
            this.mtxtTelefono.Font = new System.Drawing.Font("Tahoma", 9F);
            this.mtxtTelefono.Location = new System.Drawing.Point(188, 189);
            this.mtxtTelefono.Mask = "########";
            this.mtxtTelefono.Name = "mtxtTelefono";
            this.mtxtTelefono.Size = new System.Drawing.Size(109, 22);
            this.mtxtTelefono.TabIndex = 5;
            this.mtxtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtTelefono.TextChanged += new System.EventHandler(this.mtxtTelefono_TextChanged);
            this.mtxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtTelefono_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 14);
            this.label9.TabIndex = 47;
            this.label9.Text = "TELÉFONO:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 220);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 14);
            this.label17.TabIndex = 50;
            this.label17.Text = "DIRECCIÓN:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(188, 217);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(413, 36);
            this.txtDireccion.TabIndex = 6;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(12, 256);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(766, 1);
            this.label18.TabIndex = 52;
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
            this.btnGuardar.Location = new System.Drawing.Point(581, 266);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 54;
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
            this.btnCancelar.Location = new System.Drawing.Point(681, 266);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnComposicionProducto
            // 
            this.btnComposicionProducto.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnComposicionProducto.ForeColor = System.Drawing.Color.White;
            this.btnComposicionProducto.Location = new System.Drawing.Point(564, 124);
            this.btnComposicionProducto.Name = "btnComposicionProducto";
            this.btnComposicionProducto.Size = new System.Drawing.Size(37, 22);
            this.btnComposicionProducto.TabIndex = 89;
            this.btnComposicionProducto.TabStop = false;
            this.btnComposicionProducto.Text = "...";
            this.ttMensaje.SetToolTip(this.btnComposicionProducto, "Nueva Composición Quimica");
            this.btnComposicionProducto.UseVisualStyleBackColor = false;
            this.btnComposicionProducto.Click += new System.EventHandler(this.btnComposicionProducto_Click);
            // 
            // btnRefrescarPresentacion
            // 
            this.btnRefrescarPresentacion.BackColor = System.Drawing.Color.Transparent;
            this.btnRefrescarPresentacion.FlatAppearance.BorderSize = 0;
            this.btnRefrescarPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarPresentacion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescarPresentacion.ForeColor = System.Drawing.Color.White;
            this.btnRefrescarPresentacion.Image = global::SCM.Properties.Resources.Refresh24;
            this.btnRefrescarPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescarPresentacion.Location = new System.Drawing.Point(531, 121);
            this.btnRefrescarPresentacion.Name = "btnRefrescarPresentacion";
            this.btnRefrescarPresentacion.Size = new System.Drawing.Size(31, 28);
            this.btnRefrescarPresentacion.TabIndex = 97;
            this.btnRefrescarPresentacion.TabStop = false;
            this.btnRefrescarPresentacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.btnRefrescarPresentacion, "Refrescar Presentación");
            this.btnRefrescarPresentacion.UseVisualStyleBackColor = false;
            this.btnRefrescarPresentacion.Click += new System.EventHandler(this.btnRefrescarPresentacion_Click);
            // 
            // txtProfesion
            // 
            this.txtProfesion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfesion.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtProfesion.Location = new System.Drawing.Point(188, 124);
            this.txtProfesion.Multiline = true;
            this.txtProfesion.Name = "txtProfesion";
            this.txtProfesion.Size = new System.Drawing.Size(337, 50);
            this.txtProfesion.TabIndex = 4;
            this.txtProfesion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfesion_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 14);
            this.label14.TabIndex = 56;
            this.label14.Text = "ESPECIALIDADES:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(170, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 14);
            this.label16.TabIndex = 57;
            this.label16.Text = "*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(603, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(326, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 77;
            this.label4.Text = "ESTADO:";
            // 
            // cbEstado
            // 
            this.cbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEstado.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbEstado.Checked = true;
            this.cbEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEstado.Location = new System.Drawing.Point(390, 12);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(187, 17);
            this.cbEstado.TabIndex = 76;
            this.cbEstado.TabStop = false;
            this.cbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbEstado.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMensaje.Location = new System.Drawing.Point(185, 172);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(375, 11);
            this.lblMensaje.TabIndex = 98;
            this.lblMensaje.Text = "La especialidad se debe de ingresar cuando el especialiste este registrado.";
            this.lblMensaje.Visible = false;
            // 
            // frmEspecialista_Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(793, 313);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnRefrescarPresentacion);
            this.Controls.Add(this.btnComposicionProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtProfesion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mtxtTelefono);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpNacimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrimerNombre);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtCedula);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEspecialista_Acciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACCIONES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEspecialista_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmEspecialista_Acciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox mtxtCedula;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPrimerNombre;
        public System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.MaskedTextBox mtxtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.TextBox txtProfesion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cbEstado;
        public System.Windows.Forms.Button btnRefrescarPresentacion;
        public System.Windows.Forms.Button btnComposicionProducto;
        public System.Windows.Forms.Label lblMensaje;
    }
}