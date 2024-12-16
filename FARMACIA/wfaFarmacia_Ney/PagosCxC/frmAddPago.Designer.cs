namespace wfaFarmacia_Ney.PagosCxC
{
    partial class frmAddPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPago));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCLIENTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NOMBRES", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TELEFONO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CELULAR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DIRECCION");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTACTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PORCT_COMISION");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RUC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CEDULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO_ESTADO_CTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SECTOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LIMITE_CREDITO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PAIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO_CC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TIPO_CANAL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_INGRESO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CLIENTE_SAP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.ugbPago = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnRefrescarCliente = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumReferencia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoPago = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.txtComentario = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nudMontoPago = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugvFacturas = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPago)).BeginInit();
            this.ugbPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // ugbPago
            // 
            this.ugbPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ugbPago.Controls.Add(this.lblTipoCambio);
            this.ugbPago.Controls.Add(this.label3);
            this.ugbPago.Controls.Add(this.cbMoneda);
            this.ugbPago.Controls.Add(this.cmbCliente);
            this.ugbPago.Controls.Add(this.label2);
            this.ugbPago.Controls.Add(this.label1);
            this.ugbPago.Controls.Add(this.ultraGroupBox2);
            this.ugbPago.Controls.Add(this.ultraGroupBox1);
            this.ugbPago.Location = new System.Drawing.Point(-5, -3);
            this.ugbPago.Name = "ugbPago";
            this.ugbPago.Size = new System.Drawing.Size(727, 596);
            this.ugbPago.TabIndex = 0;
            this.ugbPago.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTipoCambio.Location = new System.Drawing.Point(615, 12);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(32, 16);
            this.lblTipoCambio.TabIndex = 111;
            this.lblTipoCambio.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(557, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "TC:";
            // 
            // cbMoneda
            // 
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Items.AddRange(new object[] {
            "DOLARES",
            "CORDOBAS"});
            this.cbMoneda.Location = new System.Drawing.Point(615, 31);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(106, 21);
            this.cbMoneda.TabIndex = 109;
            this.cbMoneda.SelectedIndexChanged += new System.EventHandler(this.cbMoneda_SelectedIndexChanged);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbCliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.Location = new System.Drawing.Point(97, 26);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(364, 22);
            this.cmbCliente.TabIndex = 100;
            this.cmbCliente.ValueChanged += new System.EventHandler(this.cmbCliente_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(557, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "MONEDA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "CLIENTE:";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox2.Controls.Add(this.btnRefrescarCliente);
            this.ultraGroupBox2.Controls.Add(this.btnCliente);
            this.ultraGroupBox2.Controls.Add(this.label18);
            this.ultraGroupBox2.Controls.Add(this.btnCancelar);
            this.ultraGroupBox2.Controls.Add(this.btnGuardar);
            this.ultraGroupBox2.Controls.Add(this.label12);
            this.ultraGroupBox2.Controls.Add(this.txtNumReferencia);
            this.ultraGroupBox2.Controls.Add(this.label11);
            this.ultraGroupBox2.Controls.Add(this.label10);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.cmbTipoPago);
            this.ultraGroupBox2.Controls.Add(this.label8);
            this.ultraGroupBox2.Controls.Add(this.label7);
            this.ultraGroupBox2.Controls.Add(this.dtpFechaPago);
            this.ultraGroupBox2.Controls.Add(this.txtComentario);
            this.ultraGroupBox2.Controls.Add(this.label13);
            this.ultraGroupBox2.Controls.Add(this.nudMontoPago);
            this.ultraGroupBox2.Controls.Add(this.label6);
            this.ultraGroupBox2.Location = new System.Drawing.Point(3, 249);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(724, 323);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "Detalle Pago";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.ultraGroupBox2.Click += new System.EventHandler(this.ultraGroupBox2_Click);
            // 
            // btnRefrescarCliente
            // 
            this.btnRefrescarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnRefrescarCliente.FlatAppearance.BorderSize = 0;
            this.btnRefrescarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarCliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescarCliente.ForeColor = System.Drawing.Color.Transparent;
            this.btnRefrescarCliente.Image = global::wfaFarmacia_Ney.Properties.Resources.Refresh24;
            this.btnRefrescarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescarCliente.Location = new System.Drawing.Point(598, 93);
            this.btnRefrescarCliente.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnRefrescarCliente.Name = "btnRefrescarCliente";
            this.btnRefrescarCliente.Size = new System.Drawing.Size(32, 25);
            this.btnRefrescarCliente.TabIndex = 106;
            this.btnRefrescarCliente.TabStop = false;
            this.btnRefrescarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescarCliente.UseVisualStyleBackColor = false;
            this.btnRefrescarCliente.Click += new System.EventHandler(this.btnRefrescarCliente_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCliente.Location = new System.Drawing.Point(564, 97);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(33, 22);
            this.btnCliente.TabIndex = 105;
            this.btnCliente.TabStop = false;
            this.btnCliente.Text = "...";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(27, 261);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(677, 1);
            this.label18.TabIndex = 104;
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
            this.btnCancelar.Location = new System.Drawing.Point(597, 271);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
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
            this.btnGuardar.Location = new System.Drawing.Point(497, 271);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 103;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(28, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 15);
            this.label12.TabIndex = 101;
            this.label12.Text = "NUM REFERENCIA:";
            // 
            // txtNumReferencia
            // 
            this.txtNumReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumReferencia.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumReferencia.Location = new System.Drawing.Point(167, 125);
            this.txtNumReferencia.Name = "txtNumReferencia";
            this.txtNumReferencia.Size = new System.Drawing.Size(391, 22);
            this.txtNumReferencia.TabIndex = 4;
            this.txtNumReferencia.TextChanged += new System.EventHandler(this.txtNumReferencia_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(151, 99);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 15);
            this.label11.TabIndex = 99;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(151, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 15);
            this.label10.TabIndex = 98;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(151, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 97;
            this.label9.Text = "*";
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoPago.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbTipoPago.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPago.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbTipoPago.Location = new System.Drawing.Point(167, 97);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(391, 22);
            this.cmbTipoPago.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(28, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 95;
            this.label8.Text = "TIPO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(28, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 94;
            this.label7.Text = "FECHA:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(167, 32);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(126, 22);
            this.dtpFechaPago.TabIndex = 1;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtComentario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtComentario.Location = new System.Drawing.Point(30, 172);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(664, 82);
            this.txtComentario.TabIndex = 5;
            this.txtComentario.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(27, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 15);
            this.label13.TabIndex = 91;
            this.label13.Text = "COMENTARIO:";
            // 
            // nudMontoPago
            // 
            this.nudMontoPago.DecimalPlaces = 2;
            this.nudMontoPago.Enabled = false;
            this.nudMontoPago.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.nudMontoPago.Location = new System.Drawing.Point(167, 64);
            this.nudMontoPago.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMontoPago.Name = "nudMontoPago";
            this.nudMontoPago.Size = new System.Drawing.Size(128, 27);
            this.nudMontoPago.TabIndex = 2;
            this.nudMontoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMontoPago.ValueChanged += new System.EventHandler(this.nudMontoPago_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(28, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 53;
            this.label6.Text = "MONTO $:";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.ugvFacturas);
            this.ultraGroupBox1.Location = new System.Drawing.Point(6, 69);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(721, 174);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "Detalle Factura Pendiente:";
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.ultraGroupBox1.Click += new System.EventHandler(this.ultraGroupBox1_Click);
            // 
            // ugvFacturas
            // 
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.BackColor2 = System.Drawing.Color.White;
            appearance14.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.ugvFacturas.DisplayLayout.Appearance = appearance14;
            this.ugvFacturas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            UltraGridColumn1.Header.Caption = "CodCliente";
            UltraGridColumn1.Header.VisiblePosition = 0;
            UltraGridColumn2.Header.Caption = "Nombre";
            UltraGridColumn2.Header.VisiblePosition = 2;
            UltraGridColumn3.Header.Caption = "Teléfono";
            UltraGridColumn3.Header.VisiblePosition = 3;
            UltraGridColumn4.Header.Caption = "Fax";
            UltraGridColumn4.Header.VisiblePosition = 4;
            UltraGridColumn5.Header.Caption = "Celular";
            UltraGridColumn5.Header.VisiblePosition = 5;
            UltraGridColumn6.Header.Caption = "Dirección";
            UltraGridColumn6.Header.VisiblePosition = 6;
            UltraGridColumn7.Header.Caption = "Correo";
            UltraGridColumn7.Header.VisiblePosition = 7;
            UltraGridColumn8.Header.Caption = "Estado";
            UltraGridColumn8.Header.VisiblePosition = 8;
            UltraGridColumn9.Header.Caption = "Contacto";
            UltraGridColumn9.Header.VisiblePosition = 9;
            UltraGridColumn10.Header.Caption = "Porc.Comisión";
            UltraGridColumn10.Header.VisiblePosition = 10;
            UltraGridColumn11.Header.Caption = "Ruc";
            UltraGridColumn11.Header.VisiblePosition = 11;
            UltraGridColumn12.Header.Caption = "Cédula";
            UltraGridColumn12.Header.VisiblePosition = 12;
            UltraGridColumn13.Header.Caption = "Correo.EstadoCuenta";
            UltraGridColumn13.Header.VisiblePosition = 13;
            UltraGridColumn14.Header.Caption = "Sección";
            UltraGridColumn14.Header.VisiblePosition = 14;
            UltraGridColumn15.Header.Caption = "LimiteCrédito";
            UltraGridColumn15.Header.VisiblePosition = 15;
            UltraGridColumn16.Header.Caption = "Pais";
            UltraGridColumn16.Header.VisiblePosition = 16;
            UltraGridColumn17.Header.Caption = "CorreoCC";
            UltraGridColumn17.Header.VisiblePosition = 17;
            UltraGridColumn18.Header.Caption = "TipoCanal";
            UltraGridColumn18.Header.VisiblePosition = 18;
            UltraGridColumn19.Header.Caption = "FechaIngreso";
            UltraGridColumn19.Header.VisiblePosition = 19;
            UltraGridColumn20.Header.Caption = "ClienteSap";
            UltraGridColumn20.Header.VisiblePosition = 1;
            UltraGridColumn21.Header.VisiblePosition = 20;
            ultraGridBand1.Columns.AddRange(new object[] {
            UltraGridColumn1,
            UltraGridColumn2,
            UltraGridColumn3,
            UltraGridColumn4,
            UltraGridColumn5,
            UltraGridColumn6,
            UltraGridColumn7,
            UltraGridColumn8,
            UltraGridColumn9,
            UltraGridColumn10,
            UltraGridColumn11,
            UltraGridColumn12,
            UltraGridColumn13,
            UltraGridColumn14,
            UltraGridColumn15,
            UltraGridColumn16,
            UltraGridColumn17,
            UltraGridColumn18,
            UltraGridColumn19,
            UltraGridColumn20,
            UltraGridColumn21});
            this.ugvFacturas.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugvFacturas.DisplayLayout.InterBandSpacing = 10;
            this.ugvFacturas.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ugvFacturas.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.ugvFacturas.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.LightYellow;
            appearance16.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ugvFacturas.DisplayLayout.Override.CellAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.LimeGreen;
            appearance17.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ugvFacturas.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.ugvFacturas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.ForeColor = System.Drawing.Color.DarkGreen;
            this.ugvFacturas.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.ugvFacturas.DisplayLayout.Override.RowSelectorWidth = 10;
            this.ugvFacturas.DisplayLayout.Override.RowSpacingAfter = 3;
            this.ugvFacturas.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance19.BackColor = System.Drawing.Color.DarkGreen;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance19.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ugvFacturas.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.ugvFacturas.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ugvFacturas.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ugvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugvFacturas.Location = new System.Drawing.Point(3, 16);
            this.ugvFacturas.Name = "ugvFacturas";
            this.ugvFacturas.Size = new System.Drawing.Size(715, 155);
            this.ugvFacturas.TabIndex = 24;
            this.ugvFacturas.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugvFacturas_AfterCellUpdate);
            this.ugvFacturas.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugvFacturas_InitializeLayout);
            // 
            // frmAddPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 568);
            this.Controls.Add(this.ugbPago);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago a Facturas";
            this.Load += new System.EventHandler(this.frmAddPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPago)).EndInit();
            this.ugbPago.ResumeLayout(false);
            this.ugbPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ugbPago;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudMontoPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtNumReferencia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbTipoPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtpFechaPago;
        public System.Windows.Forms.RichTextBox txtComentario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        internal Infragistics.Win.UltraWinGrid.UltraGrid ugvFacturas;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCliente;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Button btnRefrescarCliente;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.Label label3;
    }
}