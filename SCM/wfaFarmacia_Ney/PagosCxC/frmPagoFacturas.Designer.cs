namespace SCM.PagosCxC
{
    partial class frmPagoFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoFacturas));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCLIENTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NOMBRES");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TELEFONO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAX", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
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
            this.btnPrintVenta = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMontoFactura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugvFacturas = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPago)).BeginInit();
            this.ugbPago.SuspendLayout();
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
            this.ugbPago.Controls.Add(this.btnPrintVenta);
            this.ugbPago.Controls.Add(this.btnEliminar);
            this.ugbPago.Controls.Add(this.label18);
            this.ugbPago.Controls.Add(this.txtSaldo);
            this.ugbPago.Controls.Add(this.txtAbono);
            this.ugbPago.Controls.Add(this.label4);
            this.ugbPago.Controls.Add(this.label5);
            this.ugbPago.Controls.Add(this.txtMontoFactura);
            this.ugbPago.Controls.Add(this.label3);
            this.ugbPago.Controls.Add(this.txtNumFactura);
            this.ugbPago.Controls.Add(this.label2);
            this.ugbPago.Controls.Add(this.txtCliente);
            this.ugbPago.Controls.Add(this.label1);
            this.ugbPago.Controls.Add(this.btnCancelar);
            this.ugbPago.Controls.Add(this.ultraGroupBox1);
            this.ugbPago.Location = new System.Drawing.Point(0, 0);
            this.ugbPago.Name = "ugbPago";
            this.ugbPago.Size = new System.Drawing.Size(761, 451);
            this.ugbPago.TabIndex = 1;
            this.ugbPago.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btnPrintVenta
            // 
            this.btnPrintVenta.BackColor = System.Drawing.Color.Green;
            this.btnPrintVenta.FlatAppearance.BorderSize = 0;
            this.btnPrintVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintVenta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintVenta.ForeColor = System.Drawing.Color.White;
            this.btnPrintVenta.Image = global::SCM.Properties.Resources.Printer;
            this.btnPrintVenta.Location = new System.Drawing.Point(507, 376);
            this.btnPrintVenta.Name = "btnPrintVenta";
            this.btnPrintVenta.Size = new System.Drawing.Size(151, 42);
            this.btnPrintVenta.TabIndex = 116;
            this.btnPrintVenta.TabStop = false;
            this.btnPrintVenta.Text = "IMPRIMIR PAGO";
            this.btnPrintVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintVenta.UseVisualStyleBackColor = false;
            this.btnPrintVenta.Click += new System.EventHandler(this.btnPrintVenta_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(9, 384);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 34);
            this.btnEliminar.TabIndex = 115;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "&ANULAR PAGO";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(12, 106);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(744, 1);
            this.label18.TabIndex = 114;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaldo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSaldo.Location = new System.Drawing.Point(509, 49);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(149, 22);
            this.txtSaldo.TabIndex = 113;
            // 
            // txtAbono
            // 
            this.txtAbono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAbono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbono.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAbono.Location = new System.Drawing.Point(509, 17);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(149, 22);
            this.txtAbono.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(455, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "ABONO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(455, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "SALDO:";
            // 
            // txtMontoFactura
            // 
            this.txtMontoFactura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoFactura.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMontoFactura.Location = new System.Drawing.Point(120, 72);
            this.txtMontoFactura.Name = "txtMontoFactura";
            this.txtMontoFactura.Size = new System.Drawing.Size(149, 22);
            this.txtMontoFactura.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(11, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "MONTO FACTURA:";
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumFactura.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumFactura.Location = new System.Drawing.Point(120, 12);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Size = new System.Drawing.Size(117, 22);
            this.txtNumFactura.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "ID FACTURA:";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCliente.Location = new System.Drawing.Point(120, 40);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(281, 22);
            this.txtCliente.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "CLIENTE:";
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
            this.btnCancelar.Location = new System.Drawing.Point(669, 376);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 42);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&SALIR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.ugvFacturas);
            this.ultraGroupBox1.Location = new System.Drawing.Point(6, 130);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(755, 224);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "Pagos a factura:";
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ugvFacturas
            // 
            this.ugvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.ugvFacturas.Location = new System.Drawing.Point(3, 19);
            this.ugvFacturas.Name = "ugvFacturas";
            this.ugvFacturas.Size = new System.Drawing.Size(752, 199);
            this.ugvFacturas.TabIndex = 24;
            this.ugvFacturas.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugvFacturas_InitializeLayout);
            // 
            // frmPagoFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.ugbPago);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPagoFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos de Facturas";
            this.Load += new System.EventHandler(this.frmPagoFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugbPago)).EndInit();
            this.ugbPago.ResumeLayout(false);
            this.ugbPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ugbPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        internal Infragistics.Win.UltraWinGrid.UltraGrid ugvFacturas;
        public System.Windows.Forms.TextBox txtCliente;
        public System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSaldo;
        public System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMontoFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Button btnPrintVenta;
    }
}