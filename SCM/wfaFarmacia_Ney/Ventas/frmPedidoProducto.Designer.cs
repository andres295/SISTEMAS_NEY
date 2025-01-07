namespace SCM.Ventas
{
    partial class frmPedidoProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoProducto));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCLIENTE", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NOMBRES");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TELEFONO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAX");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CELULAR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DIRECCION");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTACTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PORCT_COMISION");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RUC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CEDULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO_ESTADO_CTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SECTOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LIMITE_CREDITO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PAIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CORREO_CC");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TIPO_CANAL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_INGRESO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CLIENTE_SAP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.utfrmSolicitud = new Infragistics.Win.UltraWinTabControl.UltraTabStripControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProducto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.uGridSolicitud = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.nvSolicitud = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bsSolicitud = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utfrmSolicitud)).BeginInit();
            this.utfrmSolicitud.SuspendLayout();
            this.ultraTabSharedControlsPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvSolicitud)).BeginInit();
            this.nvSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSolicitud)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.utfrmSolicitud);
            this.ultraGroupBox2.Controls.Add(this.uGridSolicitud);
            this.ultraGroupBox2.Controls.Add(this.nvSolicitud);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(746, 330);
            this.ultraGroupBox2.TabIndex = 74;
            this.ultraGroupBox2.Text = "PRODUCTOS:";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // utfrmSolicitud
            // 
            this.utfrmSolicitud.Controls.Add(this.ultraTabSharedControlsPage2);
            this.utfrmSolicitud.Location = new System.Drawing.Point(99, 39);
            this.utfrmSolicitud.Name = "utfrmSolicitud";
            this.utfrmSolicitud.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.label3,
            this.nudCantidad,
            this.label5,
            this.label18,
            this.label4,
            this.nudMonto,
            this.label2,
            this.cmbProducto,
            this.label1,
            this.btnGuardar,
            this.btnCancelar});
            this.utfrmSolicitud.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.utfrmSolicitud.Size = new System.Drawing.Size(584, 252);
            this.utfrmSolicitud.TabIndex = 79;
            this.utfrmSolicitud.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            this.utfrmSolicitud.Visible = false;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Controls.Add(this.label3);
            this.ultraTabSharedControlsPage2.Controls.Add(this.nudCantidad);
            this.ultraTabSharedControlsPage2.Controls.Add(this.label5);
            this.ultraTabSharedControlsPage2.Controls.Add(this.label18);
            this.ultraTabSharedControlsPage2.Controls.Add(this.label4);
            this.ultraTabSharedControlsPage2.Controls.Add(this.nudMonto);
            this.ultraTabSharedControlsPage2.Controls.Add(this.label2);
            this.ultraTabSharedControlsPage2.Controls.Add(this.cmbProducto);
            this.ultraTabSharedControlsPage2.Controls.Add(this.label1);
            this.ultraTabSharedControlsPage2.Controls.Add(this.btnGuardar);
            this.ultraTabSharedControlsPage2.Controls.Add(this.btnCancelar);
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(582, 231);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 114;
            this.label3.Text = "CANTIDAD:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad.Location = new System.Drawing.Point(108, 91);
            this.nudCantidad.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 22);
            this.nudCantidad.TabIndex = 2;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(8, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(574, 1);
            this.label5.TabIndex = 112;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(3, 33);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(574, 1);
            this.label18.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(105, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 14);
            this.label4.TabIndex = 110;
            this.label4.Text = "SOLICITUD DE PRODUCTOS";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudMonto.Location = new System.Drawing.Point(108, 128);
            this.nudMonto.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(90, 22);
            this.nudMonto.TabIndex = 3;
            this.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(20, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 106;
            this.label2.Text = "DEPOSITO$:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbProducto.Location = new System.Drawing.Point(108, 60);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(469, 21);
            this.cmbProducto.TabIndex = 1;
            this.cmbProducto.ValueChanged += new System.EventHandler(this.cmbProducto_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "PRODUCTO:";
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
            this.btnGuardar.Location = new System.Drawing.Point(169, 192);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 91;
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
            this.btnCancelar.Location = new System.Drawing.Point(282, 192);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 34);
            this.btnCancelar.TabIndex = 92;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&SALIR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // uGridSolicitud
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.uGridSolicitud.DisplayLayout.Appearance = appearance1;
            this.uGridSolicitud.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Caption = "CodCliente";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "Nombre";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.Caption = "Teléfono";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.Header.Caption = "Fax";
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.Header.Caption = "Celular";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.Header.Caption = "Dirección";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn7.Header.Caption = "Correo";
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.Header.Caption = "Estado";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.Caption = "Contacto";
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn10.Header.Caption = "Porc.Comisión";
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.Header.Caption = "Ruc";
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.Header.Caption = "Cédula";
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.Header.Caption = "Correo.EstadoCuenta";
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.Header.Caption = "Sección";
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.Header.Caption = "LimiteCrédito";
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn16.Header.Caption = "Pais";
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn17.Header.Caption = "CorreoCC";
            ultraGridColumn17.Header.VisiblePosition = 17;
            ultraGridColumn18.Header.Caption = "TipoCanal";
            ultraGridColumn18.Header.VisiblePosition = 18;
            ultraGridColumn19.Header.Caption = "FechaIngreso";
            ultraGridColumn19.Header.VisiblePosition = 19;
            ultraGridColumn20.Header.Caption = "ClienteSap";
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21});
            this.uGridSolicitud.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridSolicitud.DisplayLayout.InterBandSpacing = 10;
            this.uGridSolicitud.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uGridSolicitud.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGridSolicitud.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.LightYellow;
            appearance3.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridSolicitud.DisplayLayout.Override.CellAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.LimeGreen;
            appearance4.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridSolicitud.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.uGridSolicitud.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.DarkGreen;
            this.uGridSolicitud.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.uGridSolicitud.DisplayLayout.Override.RowSelectorWidth = 10;
            this.uGridSolicitud.DisplayLayout.Override.RowSpacingAfter = 3;
            this.uGridSolicitud.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance6.BackColor = System.Drawing.Color.DarkGreen;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uGridSolicitud.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.uGridSolicitud.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uGridSolicitud.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.uGridSolicitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridSolicitud.Location = new System.Drawing.Point(3, 48);
            this.uGridSolicitud.Name = "uGridSolicitud";
            this.uGridSolicitud.Size = new System.Drawing.Size(740, 279);
            this.uGridSolicitud.TabIndex = 78;
            this.uGridSolicitud.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGridSolicitud_InitializeLayout);
            // 
            // nvSolicitud
            // 
            this.nvSolicitud.AddNewItem = this.bindingNavigatorAddNewItem;
            this.nvSolicitud.CountItem = this.bindingNavigatorCountItem;
            this.nvSolicitud.DeleteItem = null;
            this.nvSolicitud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4});
            this.nvSolicitud.Location = new System.Drawing.Point(3, 23);
            this.nvSolicitud.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nvSolicitud.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nvSolicitud.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nvSolicitud.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nvSolicitud.Name = "nvSolicitud";
            this.nvSolicitud.PositionItem = this.bindingNavigatorPositionItem;
            this.nvSolicitud.Size = new System.Drawing.Size(740, 25);
            this.nvSolicitud.TabIndex = 72;
            this.nvSolicitud.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Nueva sugerencia de producto";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SCM.Properties.Resources.Symbol_Delete_2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Eliminar sugerencia de producto";
            this.toolStripButton2.ToolTipText = "Eliminar sugerencia de producto";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::SCM.Properties.Resources.Refresh24;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Refrescar sugerencia de producto";
            this.toolStripButton3.ToolTipText = "Refrescar sugerencia de producto";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // frmPedidoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 330);
            this.Controls.Add(this.ultraGroupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidoProducto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOLICITUD DE PRODUCTOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoAjuste_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmAperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utfrmSolicitud)).EndInit();
            this.utfrmSolicitud.ResumeLayout(false);
            this.ultraTabSharedControlsPage2.ResumeLayout(false);
            this.ultraTabSharedControlsPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvSolicitud)).EndInit();
            this.nvSolicitud.ResumeLayout(false);
            this.nvSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSolicitud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttMensaje;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.BindingNavigator nvSolicitud;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bsSolicitud;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGridSolicitud;
        private Infragistics.Win.UltraWinTabControl.UltraTabStripControl utfrmSolicitud;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label label2;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}