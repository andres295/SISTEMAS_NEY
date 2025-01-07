namespace SCM.CxC
{
    partial class frmHistCKCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistNCCliente));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uGridFactura = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.btnExportarCtaProveedorProducto = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.cmbCliente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(616, 13);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(9, 3, 3, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 39);
            this.btnBuscar.TabIndex = 66;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&BUSCAR";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 14);
            this.label13.TabIndex = 69;
            this.label13.Text = "DESDE EL:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(26, 35);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 22);
            this.dtpDesde.TabIndex = 68;
            this.dtpDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDesde_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 70;
            this.label1.Text = "HASTA EL:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(134, 32);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 22);
            this.dtpHasta.TabIndex = 71;
            this.dtpHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpHasta_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uGridFactura);
            this.panel1.Location = new System.Drawing.Point(1, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 531);
            this.panel1.TabIndex = 72;
            // 
            // uGridFactura
            // 
            this.uGridFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uGridFactura.DataSource = this.ultraDataSource1;
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.uGridFactura.DisplayLayout.Appearance = appearance1;
            this.uGridFactura.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.uGridFactura.DisplayLayout.InterBandSpacing = 10;
            this.uGridFactura.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uGridFactura.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.uGridFactura.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.LightYellow;
            appearance9.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridFactura.DisplayLayout.Override.CellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LimeGreen;
            appearance10.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.FontData.SizeInPoints = 10F;
            appearance10.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridFactura.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.uGridFactura.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.ForeColor = System.Drawing.Color.DarkGreen;
            this.uGridFactura.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            this.uGridFactura.DisplayLayout.Override.RowSelectorWidth = 10;
            this.uGridFactura.DisplayLayout.Override.RowSpacingAfter = 3;
            this.uGridFactura.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance12.BackColor = System.Drawing.Color.DarkGreen;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance12.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uGridFactura.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.uGridFactura.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uGridFactura.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.uGridFactura.Location = new System.Drawing.Point(0, 0);
            this.uGridFactura.Name = "uGridFactura";
            this.uGridFactura.Size = new System.Drawing.Size(1140, 531);
            this.uGridFactura.TabIndex = 24;
            this.uGridFactura.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGridFactura_InitializeLayout);
            // 
            // btnExportarCtaProveedorProducto
            // 
            this.btnExportarCtaProveedorProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCtaProveedorProducto.Image = global::SCM.Properties.Resources.Printer;
            this.btnExportarCtaProveedorProducto.Location = new System.Drawing.Point(838, 13);
            this.btnExportarCtaProveedorProducto.Name = "btnExportarCtaProveedorProducto";
            this.btnExportarCtaProveedorProducto.Size = new System.Drawing.Size(99, 36);
            this.btnExportarCtaProveedorProducto.TabIndex = 73;
            this.btnExportarCtaProveedorProducto.Text = "Imprimir";
            this.btnExportarCtaProveedorProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarCtaProveedorProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarCtaProveedorProducto.UseVisualStyleBackColor = true;
            this.btnExportarCtaProveedorProducto.Visible = false;
            this.btnExportarCtaProveedorProducto.Click += new System.EventHandler(this.btnExportarCtaProveedorProducto_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Location = new System.Drawing.Point(723, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(99, 34);
            this.btnExportar.TabIndex = 74;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbCliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCliente.Location = new System.Drawing.Point(244, 32);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(360, 21);
            this.cmbCliente.TabIndex = 97;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Location = new System.Drawing.Point(241, 13);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(60, 14);
            this.lblBuscar.TabIndex = 96;
            this.lblBuscar.Text = "CLIENTE:";
            // 
            // frmHistNCCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnExportarCtaProveedorProducto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnBuscar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rmHistCKCliente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTORIAL DE CHEQUES DE CLIENTES";
            this.Load += new System.EventHandler(this.frmHistCKCliente_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Panel panel1;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGridFactura;
        private System.Windows.Forms.Button btnExportarCtaProveedorProducto;
        private System.Windows.Forms.Button btnExportar;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCliente;
        private System.Windows.Forms.Label lblBuscar;
    }
}