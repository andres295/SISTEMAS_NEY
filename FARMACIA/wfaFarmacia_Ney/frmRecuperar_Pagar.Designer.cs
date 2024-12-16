namespace wfaFarmacia_Ney
{
    partial class frmRecuperar_Pagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecuperar_Pagar));
            this.pEfectivo = new System.Windows.Forms.Panel();
            this.nudEfectivo = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEfectivo = new System.Windows.Forms.CheckBox();
            this.cbCheque = new System.Windows.Forms.CheckBox();
            this.pCheque = new System.Windows.Forms.Panel();
            this.pbVerCheque = new System.Windows.Forms.PictureBox();
            this.pbEliminarCheque = new System.Windows.Forms.PictureBox();
            this.pbImagenCheque = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFechaCobro = new System.Windows.Forms.DateTimePicker();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMontoCheque = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTransf = new System.Windows.Forms.CheckBox();
            this.pTransf = new System.Windows.Forms.Panel();
            this.pbVerTransf = new System.Windows.Forms.PictureBox();
            this.pbEliminarTransf = new System.Windows.Forms.PictureBox();
            this.pbImagenTransf = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumTransf = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.nudMontoTransf = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tMostrarImagen = new System.Windows.Forms.Timer(this.components);
            this.tSumar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pContenedorFoto = new System.Windows.Forms.Panel();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.pEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEfectivo)).BeginInit();
            this.pCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCheque)).BeginInit();
            this.pTransf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerTransf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarTransf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenTransf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTransf)).BeginInit();
            this.panel1.SuspendLayout();
            this.pContenedorFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pEfectivo
            // 
            this.pEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pEfectivo.Controls.Add(this.nudEfectivo);
            this.pEfectivo.Controls.Add(this.label9);
            this.pEfectivo.Controls.Add(this.label8);
            this.pEfectivo.Enabled = false;
            this.pEfectivo.Location = new System.Drawing.Point(33, 42);
            this.pEfectivo.Name = "pEfectivo";
            this.pEfectivo.Size = new System.Drawing.Size(546, 28);
            this.pEfectivo.TabIndex = 57;
            // 
            // nudEfectivo
            // 
            this.nudEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudEfectivo.DecimalPlaces = 4;
            this.nudEfectivo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudEfectivo.Location = new System.Drawing.Point(144, 3);
            this.nudEfectivo.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudEfectivo.Name = "nudEfectivo";
            this.nudEfectivo.Size = new System.Drawing.Size(112, 22);
            this.nudEfectivo.TabIndex = 0;
            this.nudEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEfectivo.Enter += new System.EventHandler(this.nudEfectivo_Enter);
            this.nudEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudEfectivo_KeyDown);
            this.nudEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudEfectivo_KeyPress);
            this.nudEfectivo.Leave += new System.EventHandler(this.nudEfectivo_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(126, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 14);
            this.label9.TabIndex = 59;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(0, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 58;
            this.label8.Text = "MONTO:";
            // 
            // cbEfectivo
            // 
            this.cbEfectivo.AutoSize = true;
            this.cbEfectivo.ForeColor = System.Drawing.Color.Blue;
            this.cbEfectivo.Location = new System.Drawing.Point(18, 18);
            this.cbEfectivo.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.cbEfectivo.Name = "cbEfectivo";
            this.cbEfectivo.Size = new System.Drawing.Size(83, 18);
            this.cbEfectivo.TabIndex = 58;
            this.cbEfectivo.TabStop = false;
            this.cbEfectivo.Text = "EFECTIVO";
            this.cbEfectivo.UseVisualStyleBackColor = true;
            this.cbEfectivo.CheckedChanged += new System.EventHandler(this.cbEfectivo_CheckedChanged);
            // 
            // cbCheque
            // 
            this.cbCheque.AutoSize = true;
            this.cbCheque.ForeColor = System.Drawing.Color.Blue;
            this.cbCheque.Location = new System.Drawing.Point(18, 82);
            this.cbCheque.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.cbCheque.Name = "cbCheque";
            this.cbCheque.Size = new System.Drawing.Size(74, 18);
            this.cbCheque.TabIndex = 59;
            this.cbCheque.TabStop = false;
            this.cbCheque.Text = "CHEQUE";
            this.cbCheque.UseVisualStyleBackColor = true;
            this.cbCheque.CheckedChanged += new System.EventHandler(this.cbCheque_CheckedChanged);
            // 
            // pCheque
            // 
            this.pCheque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCheque.Controls.Add(this.pbVerCheque);
            this.pCheque.Controls.Add(this.pbEliminarCheque);
            this.pCheque.Controls.Add(this.pbImagenCheque);
            this.pCheque.Controls.Add(this.label4);
            this.pCheque.Controls.Add(this.label7);
            this.pCheque.Controls.Add(this.label6);
            this.pCheque.Controls.Add(this.cmbBanco);
            this.pCheque.Controls.Add(this.label14);
            this.pCheque.Controls.Add(this.label13);
            this.pCheque.Controls.Add(this.dtpFechaCobro);
            this.pCheque.Controls.Add(this.txtCheque);
            this.pCheque.Controls.Add(this.label3);
            this.pCheque.Controls.Add(this.nudMontoCheque);
            this.pCheque.Controls.Add(this.label1);
            this.pCheque.Controls.Add(this.label2);
            this.pCheque.Enabled = false;
            this.pCheque.Location = new System.Drawing.Point(33, 106);
            this.pCheque.Name = "pCheque";
            this.pCheque.Size = new System.Drawing.Size(546, 152);
            this.pCheque.TabIndex = 60;
            // 
            // pbVerCheque
            // 
            this.pbVerCheque.Image = ((System.Drawing.Image)(resources.GetObject("pbVerCheque.Image")));
            this.pbVerCheque.Location = new System.Drawing.Point(220, 116);
            this.pbVerCheque.Name = "pbVerCheque";
            this.pbVerCheque.Size = new System.Drawing.Size(32, 32);
            this.pbVerCheque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVerCheque.TabIndex = 72;
            this.pbVerCheque.TabStop = false;
            this.pbVerCheque.Visible = false;
            this.pbVerCheque.MouseEnter += new System.EventHandler(this.pbVerCheque_MouseEnter);
            this.pbVerCheque.MouseLeave += new System.EventHandler(this.pbVerCheque_MouseLeave);
            // 
            // pbEliminarCheque
            // 
            this.pbEliminarCheque.Image = ((System.Drawing.Image)(resources.GetObject("pbEliminarCheque.Image")));
            this.pbEliminarCheque.Location = new System.Drawing.Point(182, 116);
            this.pbEliminarCheque.Name = "pbEliminarCheque";
            this.pbEliminarCheque.Size = new System.Drawing.Size(32, 32);
            this.pbEliminarCheque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEliminarCheque.TabIndex = 71;
            this.pbEliminarCheque.TabStop = false;
            this.pbEliminarCheque.Visible = false;
            this.pbEliminarCheque.Click += new System.EventHandler(this.pbEliminarCheque_Click);
            this.pbEliminarCheque.MouseEnter += new System.EventHandler(this.pbEliminarCheque_MouseEnter);
            this.pbEliminarCheque.MouseLeave += new System.EventHandler(this.pbEliminarCheque_MouseLeave);
            // 
            // pbImagenCheque
            // 
            this.pbImagenCheque.Image = ((System.Drawing.Image)(resources.GetObject("pbImagenCheque.Image")));
            this.pbImagenCheque.Location = new System.Drawing.Point(144, 116);
            this.pbImagenCheque.Name = "pbImagenCheque";
            this.pbImagenCheque.Size = new System.Drawing.Size(32, 32);
            this.pbImagenCheque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImagenCheque.TabIndex = 70;
            this.pbImagenCheque.TabStop = false;
            this.pbImagenCheque.Click += new System.EventHandler(this.pbImagenCheque_Click);
            this.pbImagenCheque.MouseEnter += new System.EventHandler(this.pbImagenCheque_MouseEnter);
            this.pbImagenCheque.MouseLeave += new System.EventHandler(this.pbImagenCheque_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 69;
            this.label4.Text = "IMAGEN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(126, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 68;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 67;
            this.label6.Text = "BANCO:";
            // 
            // cmbBanco
            // 
            this.cmbBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(144, 59);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(402, 22);
            this.cmbBanco.TabIndex = 3;
            this.cmbBanco.DropDownClosed += new System.EventHandler(this.cmbBanco_DropDownClosed);
            this.cmbBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBanco_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(126, 37);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 14);
            this.label14.TabIndex = 65;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 14);
            this.label13.TabIndex = 64;
            this.label13.Text = "FECHA DE COBRO:";
            // 
            // dtpFechaCobro
            // 
            this.dtpFechaCobro.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCobro.Location = new System.Drawing.Point(144, 31);
            this.dtpFechaCobro.Name = "dtpFechaCobro";
            this.dtpFechaCobro.Size = new System.Drawing.Size(90, 22);
            this.dtpFechaCobro.TabIndex = 2;
            this.dtpFechaCobro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaCobro_KeyPress);
            // 
            // txtCheque
            // 
            this.txtCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCheque.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCheque.Location = new System.Drawing.Point(144, 3);
            this.txtCheque.MaxLength = 12;
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(112, 22);
            this.txtCheque.TabIndex = 1;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 61;
            this.label3.Text = "CHEQUE #:";
            // 
            // nudMontoCheque
            // 
            this.nudMontoCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudMontoCheque.DecimalPlaces = 4;
            this.nudMontoCheque.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudMontoCheque.Location = new System.Drawing.Point(144, 88);
            this.nudMontoCheque.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudMontoCheque.Name = "nudMontoCheque";
            this.nudMontoCheque.Size = new System.Drawing.Size(112, 22);
            this.nudMontoCheque.TabIndex = 4;
            this.nudMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMontoCheque.Enter += new System.EventHandler(this.nudMontoCheque_Enter);
            this.nudMontoCheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudMontoCheque_KeyDown);
            this.nudMontoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMontoCheque_KeyPress);
            this.nudMontoCheque.Leave += new System.EventHandler(this.nudMontoCheque_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(126, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 59;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "MONTO:";
            // 
            // cbTransf
            // 
            this.cbTransf.AutoSize = true;
            this.cbTransf.ForeColor = System.Drawing.Color.Blue;
            this.cbTransf.Location = new System.Drawing.Point(18, 270);
            this.cbTransf.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.cbTransf.Name = "cbTransf";
            this.cbTransf.Size = new System.Drawing.Size(203, 18);
            this.cbTransf.TabIndex = 61;
            this.cbTransf.TabStop = false;
            this.cbTransf.Text = "TRANSFERENCIA / DEPÓSITO";
            this.cbTransf.UseVisualStyleBackColor = true;
            this.cbTransf.CheckedChanged += new System.EventHandler(this.cbTransf_CheckedChanged);
            // 
            // pTransf
            // 
            this.pTransf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pTransf.Controls.Add(this.pbVerTransf);
            this.pTransf.Controls.Add(this.pbEliminarTransf);
            this.pTransf.Controls.Add(this.pbImagenTransf);
            this.pTransf.Controls.Add(this.label5);
            this.pTransf.Controls.Add(this.txtNumTransf);
            this.pTransf.Controls.Add(this.label16);
            this.pTransf.Controls.Add(this.nudMontoTransf);
            this.pTransf.Controls.Add(this.label17);
            this.pTransf.Controls.Add(this.label18);
            this.pTransf.Enabled = false;
            this.pTransf.Location = new System.Drawing.Point(33, 294);
            this.pTransf.Name = "pTransf";
            this.pTransf.Size = new System.Drawing.Size(546, 94);
            this.pTransf.TabIndex = 63;
            // 
            // pbVerTransf
            // 
            this.pbVerTransf.Image = ((System.Drawing.Image)(resources.GetObject("pbVerTransf.Image")));
            this.pbVerTransf.Location = new System.Drawing.Point(220, 59);
            this.pbVerTransf.Name = "pbVerTransf";
            this.pbVerTransf.Size = new System.Drawing.Size(32, 32);
            this.pbVerTransf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVerTransf.TabIndex = 73;
            this.pbVerTransf.TabStop = false;
            this.pbVerTransf.Visible = false;
            this.pbVerTransf.MouseEnter += new System.EventHandler(this.pbVerTransf_MouseEnter);
            this.pbVerTransf.MouseLeave += new System.EventHandler(this.pbVerTransf_MouseLeave);
            // 
            // pbEliminarTransf
            // 
            this.pbEliminarTransf.Image = ((System.Drawing.Image)(resources.GetObject("pbEliminarTransf.Image")));
            this.pbEliminarTransf.Location = new System.Drawing.Point(182, 59);
            this.pbEliminarTransf.Name = "pbEliminarTransf";
            this.pbEliminarTransf.Size = new System.Drawing.Size(32, 32);
            this.pbEliminarTransf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEliminarTransf.TabIndex = 72;
            this.pbEliminarTransf.TabStop = false;
            this.pbEliminarTransf.Visible = false;
            this.pbEliminarTransf.Click += new System.EventHandler(this.pbEliminarTransf_Click);
            this.pbEliminarTransf.MouseEnter += new System.EventHandler(this.pbEliminarTransf_MouseEnter);
            this.pbEliminarTransf.MouseLeave += new System.EventHandler(this.pbEliminarTransf_MouseLeave);
            // 
            // pbImagenTransf
            // 
            this.pbImagenTransf.Image = ((System.Drawing.Image)(resources.GetObject("pbImagenTransf.Image")));
            this.pbImagenTransf.Location = new System.Drawing.Point(144, 59);
            this.pbImagenTransf.Name = "pbImagenTransf";
            this.pbImagenTransf.Size = new System.Drawing.Size(32, 32);
            this.pbImagenTransf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImagenTransf.TabIndex = 70;
            this.pbImagenTransf.TabStop = false;
            this.pbImagenTransf.Click += new System.EventHandler(this.pbImagenTransf_Click);
            this.pbImagenTransf.MouseEnter += new System.EventHandler(this.pbImagenTransf_MouseEnter);
            this.pbImagenTransf.MouseLeave += new System.EventHandler(this.pbImagenTransf_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 69;
            this.label5.Text = "IMAGEN:";
            // 
            // txtNumTransf
            // 
            this.txtNumTransf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumTransf.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumTransf.Location = new System.Drawing.Point(144, 3);
            this.txtNumTransf.MaxLength = 12;
            this.txtNumTransf.Name = "txtNumTransf";
            this.txtNumTransf.Size = new System.Drawing.Size(112, 22);
            this.txtNumTransf.TabIndex = 5;
            this.txtNumTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumTransf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumTransf_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(0, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 14);
            this.label16.TabIndex = 61;
            this.label16.Text = "# DEPÓS. / TRANSF:";
            // 
            // nudMontoTransf
            // 
            this.nudMontoTransf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudMontoTransf.DecimalPlaces = 4;
            this.nudMontoTransf.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudMontoTransf.Location = new System.Drawing.Point(144, 31);
            this.nudMontoTransf.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudMontoTransf.Name = "nudMontoTransf";
            this.nudMontoTransf.Size = new System.Drawing.Size(112, 22);
            this.nudMontoTransf.TabIndex = 6;
            this.nudMontoTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMontoTransf.Enter += new System.EventHandler(this.nudMontoTransf_Enter);
            this.nudMontoTransf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudMontoTransf_KeyDown);
            this.nudMontoTransf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMontoTransf_KeyPress);
            this.nudMontoTransf.Leave += new System.EventHandler(this.nudMontoTransf_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(129, 37);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 14);
            this.label17.TabIndex = 59;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(0, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 14);
            this.label18.TabIndex = 58;
            this.label18.Text = "MONTO:";
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.BackColor = System.Drawing.Color.Green;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(401, 409);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 34);
            this.btnPagar.TabIndex = 68;
            this.btnPagar.TabStop = false;
            this.btnPagar.Text = "&PAGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(482, 409);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(12, 399);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(567, 1);
            this.label10.TabIndex = 66;
            // 
            // tMostrarImagen
            // 
            this.tMostrarImagen.Interval = 1000;
            // 
            // tSumar
            // 
            this.tSumar.Enabled = true;
            this.tSumar.Interval = 10;
            this.tSumar.Tick += new System.EventHandler(this.tSumar_Tick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(33, 75);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(546, 1);
            this.label11.TabIndex = 74;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label15.Location = new System.Drawing.Point(30, 263);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(546, 1);
            this.label15.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblDiferencia);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.lblIngresado);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lblTotalPagar);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(295, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 189);
            this.panel1.TabIndex = 78;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferencia.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.ForeColor = System.Drawing.Color.Blue;
            this.lblDiferencia.Location = new System.Drawing.Point(131, 117);
            this.lblDiferencia.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(144, 29);
            this.lblDiferencia.TabIndex = 76;
            this.lblDiferencia.Text = "0.0000";
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(15, 126);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 16);
            this.label21.TabIndex = 75;
            this.label21.Text = "DIFERENCIA:";
            // 
            // lblIngresado
            // 
            this.lblIngresado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIngresado.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresado.ForeColor = System.Drawing.Color.Red;
            this.lblIngresado.Location = new System.Drawing.Point(131, 79);
            this.lblIngresado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(144, 29);
            this.lblIngresado.TabIndex = 74;
            this.lblIngresado.Text = "0.0000";
            this.lblIngresado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(15, 88);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 16);
            this.label19.TabIndex = 73;
            this.label19.Text = "INGRESADO:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPagar.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Location = new System.Drawing.Point(131, 41);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(144, 29);
            this.lblTotalPagar.TabIndex = 72;
            this.lblTotalPagar.Text = "0.0000";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 16);
            this.label12.TabIndex = 71;
            this.label12.Text = "TOTAL A PAGAR:";
            // 
            // pContenedorFoto
            // 
            this.pContenedorFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pContenedorFoto.BackColor = System.Drawing.Color.Silver;
            this.pContenedorFoto.Controls.Add(this.pbFoto);
            this.pContenedorFoto.Location = new System.Drawing.Point(587, 106);
            this.pContenedorFoto.Name = "pContenedorFoto";
            this.pContenedorFoto.Size = new System.Drawing.Size(283, 242);
            this.pContenedorFoto.TabIndex = 79;
            this.pContenedorFoto.Visible = false;
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(211)))), ((int)(((byte)(227)))));
            this.pbFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFoto.Location = new System.Drawing.Point(0, 0);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(283, 242);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.TabIndex = 71;
            this.pbFoto.TabStop = false;
            // 
            // frmRecuperar_Pagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(591, 455);
            this.Controls.Add(this.pContenedorFoto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pTransf);
            this.Controls.Add(this.cbTransf);
            this.Controls.Add(this.pCheque);
            this.Controls.Add(this.cbCheque);
            this.Controls.Add(this.cbEfectivo);
            this.Controls.Add(this.pEfectivo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRecuperar_Pagar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFICAR PAGO DE VENTA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVentas_Pagar_FormClosing);
            this.Load += new System.EventHandler(this.frmCuentasPorPagar_Abonar_Load);
            this.pEfectivo.ResumeLayout(false);
            this.pEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEfectivo)).EndInit();
            this.pCheque.ResumeLayout(false);
            this.pCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCheque)).EndInit();
            this.pTransf.ResumeLayout(false);
            this.pTransf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerTransf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminarTransf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenTransf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoTransf)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pContenedorFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pEfectivo;
        public System.Windows.Forms.NumericUpDown nudEfectivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pCheque;
        public System.Windows.Forms.NumericUpDown nudMontoCheque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.DateTimePicker dtpFechaCobro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbImagenCheque;
        private System.Windows.Forms.Panel pTransf;
        private System.Windows.Forms.PictureBox pbImagenTransf;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNumTransf;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.NumericUpDown nudMontoTransf;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tMostrarImagen;
        private System.Windows.Forms.Timer tSumar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pContenedorFoto;
        private System.Windows.Forms.PictureBox pbFoto;
        public System.Windows.Forms.CheckBox cbEfectivo;
        public System.Windows.Forms.CheckBox cbCheque;
        public System.Windows.Forms.CheckBox cbTransf;
        public System.Windows.Forms.PictureBox pbEliminarCheque;
        public System.Windows.Forms.PictureBox pbEliminarTransf;
        public System.Windows.Forms.PictureBox pbVerCheque;
        public System.Windows.Forms.PictureBox pbVerTransf;
    }
}