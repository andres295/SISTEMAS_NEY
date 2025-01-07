namespace SCM.Facturacion
{
    partial class frmFacturas
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCLIENTE", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturas));
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegistros = new System.Windows.Forms.TextBox();
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAnuladas = new System.Windows.Forms.CheckBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgvServicios = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrintTickets = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnPrintVenta = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(176, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 34);
            this.label1.TabIndex = 3;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(180, 23);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "BUSCAR:";
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(247, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(194, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            this.txtBuscar.MouseLeave += new System.EventHandler(this.txtBuscar_MouseLeave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(1040, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 22);
            this.label3.TabIndex = 6;
            // 
            // txtRegistros
            // 
            this.txtRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRegistros.Enabled = false;
            this.txtRegistros.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRegistros.Location = new System.Drawing.Point(1050, 19);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(84, 22);
            this.txtRegistros.TabIndex = 7;
            this.txtRegistros.TabStop = false;
            this.txtRegistros.Text = "0";
            this.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(887, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "HASTA:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(740, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "DESDE:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(941, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 22);
            this.dtpHasta.TabIndex = 43;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(792, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 22);
            this.dtpDesde.TabIndex = 42;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(628, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 34);
            this.label2.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(571, 283);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 34);
            this.label6.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(441, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1, 34);
            this.label7.TabIndex = 96;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(534, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1, 34);
            this.label8.TabIndex = 97;
            // 
            // cbAnuladas
            // 
            this.cbAnuladas.AutoSize = true;
            this.cbAnuladas.ForeColor = System.Drawing.Color.Navy;
            this.cbAnuladas.Location = new System.Drawing.Point(447, 22);
            this.cbAnuladas.Name = "cbAnuladas";
            this.cbAnuladas.Size = new System.Drawing.Size(82, 18);
            this.cbAnuladas.TabIndex = 98;
            this.cbAnuladas.Text = "Anuladas";
            this.cbAnuladas.UseVisualStyleBackColor = true;
            this.cbAnuladas.CheckedChanged += new System.EventHandler(this.cbAnuladas_CheckedChanged);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.dgvServicios);
            this.ultraGroupBox1.Location = new System.Drawing.Point(3, 53);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1138, 547);
            this.ultraGroupBox1.TabIndex = 100;
            this.ultraGroupBox1.Text = "Movimientos de Producto:";
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // dgvServicios
            // 
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.dgvServicios.DisplayLayout.Appearance = appearance1;
            this.dgvServicios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn2.Header.Caption = "CodCliente";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn2});
            this.dgvServicios.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgvServicios.DisplayLayout.InterBandSpacing = 10;
            this.dgvServicios.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.dgvServicios.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.dgvServicios.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.LightYellow;
            appearance3.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.dgvServicios.DisplayLayout.Override.CellAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.LimeGreen;
            appearance4.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.dgvServicios.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.dgvServicios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.DarkGreen;
            this.dgvServicios.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.dgvServicios.DisplayLayout.Override.RowSelectorWidth = 10;
            this.dgvServicios.DisplayLayout.Override.RowSpacingAfter = 3;
            this.dgvServicios.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance6.BackColor = System.Drawing.Color.DarkGreen;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.dgvServicios.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvServicios.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.dgvServicios.Location = new System.Drawing.Point(0, 21);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.Size = new System.Drawing.Size(1118, 529);
            this.dgvServicios.TabIndex = 24;
            this.dgvServicios.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgvServicios_InitializeLayout);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(736, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1, 34);
            this.label9.TabIndex = 102;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(583, 13);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1, 34);
            this.label10.TabIndex = 104;
            // 
            // btnPrintTickets
            // 
            this.btnPrintTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPrintTickets.FlatAppearance.BorderSize = 0;
            this.btnPrintTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintTickets.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintTickets.ForeColor = System.Drawing.Color.White;
            this.btnPrintTickets.Image = global::SCM.Properties.Resources._49628_tickets_tix_icon1;
            this.btnPrintTickets.Location = new System.Drawing.Point(544, 14);
            this.btnPrintTickets.Name = "btnPrintTickets";
            this.btnPrintTickets.Size = new System.Drawing.Size(33, 34);
            this.btnPrintTickets.TabIndex = 103;
            this.btnPrintTickets.TabStop = false;
            this.btnPrintTickets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.btnPrintTickets, "Imprimir Tickets");
            this.btnPrintTickets.UseVisualStyleBackColor = false;
            this.btnPrintTickets.Click += new System.EventHandler(this.btnPrintTickets_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(634, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 101;
            this.button1.Text = "Exportar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(15, 12);
            this.btnVer.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(64, 34);
            this.btnVer.TabIndex = 99;
            this.btnVer.TabStop = false;
            this.btnVer.Text = "&VER";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnPrintVenta
            // 
            this.btnPrintVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPrintVenta.FlatAppearance.BorderSize = 0;
            this.btnPrintVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintVenta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintVenta.ForeColor = System.Drawing.Color.White;
            this.btnPrintVenta.Image = global::SCM.Properties.Resources.Printer;
            this.btnPrintVenta.Location = new System.Drawing.Point(588, 13);
            this.btnPrintVenta.Name = "btnPrintVenta";
            this.btnPrintVenta.Size = new System.Drawing.Size(33, 34);
            this.btnPrintVenta.TabIndex = 93;
            this.btnPrintVenta.TabStop = false;
            this.btnPrintVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttMensaje.SetToolTip(this.btnPrintVenta, "Imprimir Recibio");
            this.btnPrintVenta.UseVisualStyleBackColor = false;
            this.btnPrintVenta.Click += new System.EventHandler(this.btnPrintVenta_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(85, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(82, 34);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "&ANULAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrintTickets);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.cbAnuladas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrintVenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.txtRegistros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFacturas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTA DE FACTURAS DE SERVICIOS";
            this.Load += new System.EventHandler(this.frmServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtRegistros;
        public System.Windows.Forms.Timer tEnfoque;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpHasta;
        public System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnPrintVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbAnuladas;
        private System.Windows.Forms.Button btnVer;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        internal Infragistics.Win.UltraWinGrid.UltraGrid dgvServicios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Button btnPrintTickets;
        private System.Windows.Forms.Label label10;
    }
}