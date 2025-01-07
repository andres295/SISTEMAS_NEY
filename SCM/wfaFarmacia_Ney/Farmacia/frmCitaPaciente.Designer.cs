namespace SCM.Farmacia
{
    partial class frmCitaPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCitaPaciente));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRefrescarPresentacionCompra = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbPaciente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDoctor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbServicio = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label9 = new System.Windows.Forms.Label();
            this.udHora = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cbAtendida = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.udDia = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDia)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.button4);
            this.ultraGroupBox1.Controls.Add(this.button5);
            this.ultraGroupBox1.Controls.Add(this.button1);
            this.ultraGroupBox1.Controls.Add(this.button2);
            this.ultraGroupBox1.Controls.Add(this.btnRefrescarPresentacionCompra);
            this.ultraGroupBox1.Controls.Add(this.button3);
            this.ultraGroupBox1.Controls.Add(this.cmbPaciente);
            this.ultraGroupBox1.Controls.Add(this.label10);
            this.ultraGroupBox1.Controls.Add(this.cmbDoctor);
            this.ultraGroupBox1.Controls.Add(this.label8);
            this.ultraGroupBox1.Controls.Add(this.cmbServicio);
            this.ultraGroupBox1.Controls.Add(this.label9);
            this.ultraGroupBox1.Controls.Add(this.udHora);
            this.ultraGroupBox1.Controls.Add(this.cbAtendida);
            this.ultraGroupBox1.Controls.Add(this.label23);
            this.ultraGroupBox1.Controls.Add(this.udDia);
            this.ultraGroupBox1.Controls.Add(this.label7);
            this.ultraGroupBox1.Controls.Add(this.txtDescripcion);
            this.ultraGroupBox1.Controls.Add(this.label6);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.btnCancelar);
            this.ultraGroupBox1.Controls.Add(this.btnGuardar);
            this.ultraGroupBox1.Location = new System.Drawing.Point(-4, -1);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(509, 392);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::SCM.Properties.Resources.Refresh24;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(431, 120);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 28);
            this.button4.TabIndex = 133;
            this.button4.TabStop = false;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.button4, "Refrescar Tipo Sangre");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.RoyalBlue;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(461, 125);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 22);
            this.button5.TabIndex = 132;
            this.button5.TabStop = false;
            this.button5.Text = "...";
            this.ttMensaje.SetToolTip(this.button5, "Nuevo Tipo Sangre");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::SCM.Properties.Resources.Refresh24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(431, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 28);
            this.button1.TabIndex = 131;
            this.button1.TabStop = false;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.button1, "Refrescar Tipo Sangre");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(461, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 22);
            this.button2.TabIndex = 130;
            this.button2.TabStop = false;
            this.button2.Text = "...";
            this.ttMensaje.SetToolTip(this.button2, "Nuevo Tipo Sangre");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRefrescarPresentacionCompra
            // 
            this.btnRefrescarPresentacionCompra.BackColor = System.Drawing.Color.Transparent;
            this.btnRefrescarPresentacionCompra.FlatAppearance.BorderSize = 0;
            this.btnRefrescarPresentacionCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarPresentacionCompra.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescarPresentacionCompra.ForeColor = System.Drawing.Color.White;
            this.btnRefrescarPresentacionCompra.Image = global::SCM.Properties.Resources.Refresh24;
            this.btnRefrescarPresentacionCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescarPresentacionCompra.Location = new System.Drawing.Point(431, 48);
            this.btnRefrescarPresentacionCompra.Name = "btnRefrescarPresentacionCompra";
            this.btnRefrescarPresentacionCompra.Size = new System.Drawing.Size(31, 28);
            this.btnRefrescarPresentacionCompra.TabIndex = 129;
            this.btnRefrescarPresentacionCompra.TabStop = false;
            this.btnRefrescarPresentacionCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.btnRefrescarPresentacionCompra, "Refrescar Tipo Sangre");
            this.btnRefrescarPresentacionCompra.UseVisualStyleBackColor = false;
            this.btnRefrescarPresentacionCompra.Click += new System.EventHandler(this.btnRefrescarPresentacionCompra_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(461, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 22);
            this.button3.TabIndex = 128;
            this.button3.TabStop = false;
            this.button3.Text = "...";
            this.ttMensaje.SetToolTip(this.button3, "Nuevo Tipo Sangre");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbPaciente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaciente.Location = new System.Drawing.Point(174, 53);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(256, 21);
            this.cmbPaciente.TabIndex = 108;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(79, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 107;
            this.label10.Text = "PACIENTE:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbDoctor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoctor.Location = new System.Drawing.Point(174, 98);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(256, 21);
            this.cmbDoctor.TabIndex = 106;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(50, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 105;
            this.label8.Text = "ESPECIALISTA:";
            // 
            // cmbServicio
            // 
            this.cmbServicio.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbServicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServicio.Location = new System.Drawing.Point(174, 125);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(256, 21);
            this.cmbServicio.TabIndex = 104;
            this.cmbServicio.ValueChanged += new System.EventHandler(this.cmbServicio_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(84, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 102;
            this.label9.Text = "SERVICIO:";
            // 
            // udHora
            // 
            this.udHora.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.udHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udHora.Location = new System.Drawing.Point(174, 196);
            this.udHora.MaskInput = "{LOC}hh:mm";
            this.udHora.Name = "udHora";
            this.udHora.Size = new System.Drawing.Size(160, 38);
            this.udHora.TabIndex = 95;
            // 
            // cbAtendida
            // 
            this.cbAtendida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAtendida.BackColor = System.Drawing.Color.Transparent;
            this.cbAtendida.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbAtendida.Location = new System.Drawing.Point(461, 259);
            this.cbAtendida.Name = "cbAtendida";
            this.cbAtendida.Size = new System.Drawing.Size(20, 20);
            this.cbAtendida.TabIndex = 93;
            this.cbAtendida.TabStop = false;
            this.cbAtendida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAtendida.UseVisualStyleBackColor = false;
            this.cbAtendida.CheckedChanged += new System.EventHandler(this.cbAtendida_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(370, 263);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 16);
            this.label23.TabIndex = 94;
            this.label23.Text = "ATENDIDA:";
            // 
            // udDia
            // 
            this.udDia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.udDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udDia.Location = new System.Drawing.Point(174, 152);
            this.udDia.MaskInput = "{date}";
            this.udDia.Name = "udDia";
            this.udDia.Size = new System.Drawing.Size(160, 38);
            this.udDia.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(31, 243);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(450, 1);
            this.label7.TabIndex = 32;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.txtDescripcion.Location = new System.Drawing.Point(26, 286);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(449, 45);
            this.txtDescripcion.TabIndex = 31;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Brown;
            this.label6.Location = new System.Drawing.Point(24, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(299, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "¿Cuál es la Razón de su visita?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(107, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 29;
            this.label4.Text = "Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(115, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cita:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(25, 337);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 1);
            this.label2.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(25, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(450, 1);
            this.label5.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(105, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "AGENDAMIENTO DE CITAS";
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
            this.btnCancelar.Location = new System.Drawing.Point(375, 346);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(273, 346);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmCitaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 391);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCitaPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CITAS DE PACIENTE";
            this.Load += new System.EventHandler(this.frmCitaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip ttMensaje;
        public Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udHora;
        public System.Windows.Forms.CheckBox cbAtendida;
        private System.Windows.Forms.Label label23;
        public Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udDia;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbServicio;
        private System.Windows.Forms.Label label9;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDoctor;
        private System.Windows.Forms.Label label8;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPaciente;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnRefrescarPresentacionCompra;
        private System.Windows.Forms.Button button3;
    }
}