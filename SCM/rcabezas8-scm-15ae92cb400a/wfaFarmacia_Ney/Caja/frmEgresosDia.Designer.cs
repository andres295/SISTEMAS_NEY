namespace SCM.Caja
{
    partial class frmEgresosDia
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCLIENTE", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn UltraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NOMBRES");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEgresosDia));
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lkAperturarCaja = new System.Windows.Forms.LinkLabel();
            this.lblAperturaCaja = new System.Windows.Forms.Label();
            this.uGridEgresos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.nvEgresos = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bsEgresos = new System.Windows.Forms.BindingSource(this.components);
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEgreso = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvEgresos)).BeginInit();
            this.nvEgresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEgreso)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.lkAperturarCaja);
            this.ultraGroupBox2.Controls.Add(this.lblAperturaCaja);
            this.ultraGroupBox2.Controls.Add(this.uGridEgresos);
            this.ultraGroupBox2.Controls.Add(this.nvEgresos);
            this.ultraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 97);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(565, 281);
            this.ultraGroupBox2.TabIndex = 74;
            this.ultraGroupBox2.Text = "GASTOS:";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lkAperturarCaja
            // 
            this.lkAperturarCaja.AutoSize = true;
            this.lkAperturarCaja.Enabled = false;
            this.lkAperturarCaja.Location = new System.Drawing.Point(130, 200);
            this.lkAperturarCaja.Name = "lkAperturarCaja";
            this.lkAperturarCaja.Size = new System.Drawing.Size(100, 14);
            this.lkAperturarCaja.TabIndex = 75;
            this.lkAperturarCaja.TabStop = true;
            this.lkAperturarCaja.Text = "Aperturar caja!";
            this.lkAperturarCaja.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkAperturarCaja_LinkClicked);
            // 
            // lblAperturaCaja
            // 
            this.lblAperturaCaja.AutoSize = true;
            this.lblAperturaCaja.Enabled = false;
            this.lblAperturaCaja.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaCaja.ForeColor = System.Drawing.Color.Red;
            this.lblAperturaCaja.Location = new System.Drawing.Point(127, 178);
            this.lblAperturaCaja.Name = "lblAperturaCaja";
            this.lblAperturaCaja.Size = new System.Drawing.Size(55, 18);
            this.lblAperturaCaja.TabIndex = 74;
            this.lblAperturaCaja.Text = "label1";
            // 
            // uGridEgresos
            // 
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.BackColor2 = System.Drawing.Color.White;
            appearance14.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.uGridEgresos.DisplayLayout.Appearance = appearance14;
            this.uGridEgresos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
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
            this.uGridEgresos.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridEgresos.DisplayLayout.InterBandSpacing = 10;
            this.uGridEgresos.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uGridEgresos.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.uGridEgresos.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.LightYellow;
            appearance16.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridEgresos.DisplayLayout.Override.CellAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.LimeGreen;
            appearance17.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.FontData.SizeInPoints = 10F;
            appearance17.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridEgresos.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.uGridEgresos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.ForeColor = System.Drawing.Color.DarkGreen;
            this.uGridEgresos.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.uGridEgresos.DisplayLayout.Override.RowSelectorWidth = 10;
            this.uGridEgresos.DisplayLayout.Override.RowSpacingAfter = 3;
            this.uGridEgresos.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance19.BackColor = System.Drawing.Color.DarkGreen;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance19.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uGridEgresos.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.uGridEgresos.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uGridEgresos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.uGridEgresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridEgresos.Location = new System.Drawing.Point(3, 48);
            this.uGridEgresos.Name = "uGridEgresos";
            this.uGridEgresos.Size = new System.Drawing.Size(559, 230);
            this.uGridEgresos.TabIndex = 73;
            this.uGridEgresos.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGridEgresos_InitializeLayout);
            // 
            // nvEgresos
            // 
            this.nvEgresos.AddNewItem = null;
            this.nvEgresos.CountItem = this.bindingNavigatorCountItem;
            this.nvEgresos.DeleteItem = null;
            this.nvEgresos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4});
            this.nvEgresos.Location = new System.Drawing.Point(3, 23);
            this.nvEgresos.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nvEgresos.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nvEgresos.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nvEgresos.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nvEgresos.Name = "nvEgresos";
            this.nvEgresos.PositionItem = this.bindingNavigatorPositionItem;
            this.nvEgresos.Size = new System.Drawing.Size(559, 25);
            this.nvEgresos.TabIndex = 72;
            this.nvEgresos.Text = "bindingNavigator1";
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SCM.Properties.Resources.Save_2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Gurdar Egreso";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SCM.Properties.Resources.Symbol_Delete_2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Eliminar Egreso";
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
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudMonto.Location = new System.Drawing.Point(83, 40);
            this.nudMonto.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(99, 22);
            this.nudMonto.TabIndex = 108;
            this.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 110;
            this.label2.Text = "MONTO$:";
            // 
            // cmbEgreso
            // 
            this.cmbEgreso.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbEgreso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbEgreso.Location = new System.Drawing.Point(83, 11);
            this.cmbEgreso.Name = "cmbEgreso";
            this.cmbEgreso.Size = new System.Drawing.Size(470, 21);
            this.cmbEgreso.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 109;
            this.label1.Text = "GASTO:";
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
            this.btnPagar.Location = new System.Drawing.Point(461, 57);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(93, 34);
            this.btnPagar.TabIndex = 111;
            this.btnPagar.TabStop = false;
            this.btnPagar.Text = "&AGREGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(83, 68);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(104, 22);
            this.dtpHasta.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 113;
            this.label3.Text = "FECHA:";
            // 
            // frmEgresosDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 377);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEgreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEgresosDia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GASTOS DEL DIA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoAjuste_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmAperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvEgresos)).EndInit();
            this.nvEgresos.ResumeLayout(false);
            this.nvEgresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEgreso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttMensaje;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGridEgresos;
        private System.Windows.Forms.BindingNavigator nvEgresos;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.BindingSource bsEgresos;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label lblAperturaCaja;
        private System.Windows.Forms.LinkLabel lkAperturarCaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label label2;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbEgreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
    }
}