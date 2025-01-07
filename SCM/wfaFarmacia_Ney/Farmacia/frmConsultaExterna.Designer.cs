namespace SCM.Farmacia
{
    partial class frmConsultaExterna
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaExterna));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.dgvClientes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFiltroCedula = new System.Windows.Forms.CheckBox();
            this.btnVerFormulario = new System.Windows.Forms.Button();
            this.btnExportarCtaProveedor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCliente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.btnCancelar);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1012, 443);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox2.Controls.Add(this.dgvClientes);
            this.ultraGroupBox2.Controls.Add(this.panel1);
            this.ultraGroupBox2.Location = new System.Drawing.Point(6, 3);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1000, 377);
            this.ultraGroupBox2.TabIndex = 27;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // dgvClientes
            // 
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.DataSource = this.ultraDataSource1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.dgvClientes.DisplayLayout.Appearance = appearance2;
            this.dgvClientes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.dgvClientes.DisplayLayout.InterBandSpacing = 10;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.dgvClientes.DisplayLayout.Override.CardAreaAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Left";
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.dgvClientes.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.dgvClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.dgvClientes.DisplayLayout.Override.RowAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.dgvClientes.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.dgvClientes.DisplayLayout.Override.RowSelectorWidth = 12;
            this.dgvClientes.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(169)))), ((int)(((byte)(226)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.dgvClientes.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.dgvClientes.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.dgvClientes.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.dgvClientes.Location = new System.Drawing.Point(7, 58);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(987, 313);
            this.dgvClientes.TabIndex = 33;
            this.dgvClientes.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgvClientes_InitializeLayout);
            this.dgvClientes.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.dgvClientes_ClickCell);
            this.dgvClientes.DoubleClick += new System.EventHandler(this.dgvClientes_DoubleClick);
            this.dgvClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvClientes_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbFiltroCedula);
            this.panel1.Controls.Add(this.btnVerFormulario);
            this.panel1.Controls.Add(this.btnExportarCtaProveedor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbCliente);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 53);
            this.panel1.TabIndex = 32;
            // 
            // cbFiltroCedula
            // 
            this.cbFiltroCedula.AutoSize = true;
            this.cbFiltroCedula.BackColor = System.Drawing.Color.Transparent;
            this.cbFiltroCedula.Location = new System.Drawing.Point(80, 5);
            this.cbFiltroCedula.Name = "cbFiltroCedula";
            this.cbFiltroCedula.Size = new System.Drawing.Size(107, 17);
            this.cbFiltroCedula.TabIndex = 132;
            this.cbFiltroCedula.Text = "Bucar por cédula";
            this.cbFiltroCedula.UseVisualStyleBackColor = false;
            this.cbFiltroCedula.CheckedChanged += new System.EventHandler(this.cbFiltroCedula_CheckedChanged);
            // 
            // btnVerFormulario
            // 
            this.btnVerFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVerFormulario.FlatAppearance.BorderSize = 0;
            this.btnVerFormulario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerFormulario.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerFormulario.ForeColor = System.Drawing.Color.White;
            this.btnVerFormulario.Image = ((System.Drawing.Image)(resources.GetObject("btnVerFormulario.Image")));
            this.btnVerFormulario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerFormulario.Location = new System.Drawing.Point(751, 10);
            this.btnVerFormulario.Margin = new System.Windows.Forms.Padding(9, 3, 3, 6);
            this.btnVerFormulario.Name = "btnVerFormulario";
            this.btnVerFormulario.Size = new System.Drawing.Size(147, 37);
            this.btnVerFormulario.TabIndex = 102;
            this.btnVerFormulario.TabStop = false;
            this.btnVerFormulario.Text = "&VER FORMULARIO";
            this.btnVerFormulario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerFormulario.UseVisualStyleBackColor = false;
            this.btnVerFormulario.Click += new System.EventHandler(this.btnVerFormulario_Click);
            // 
            // btnExportarCtaProveedor
            // 
            this.btnExportarCtaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCtaProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCtaProveedor.Image")));
            this.btnExportarCtaProveedor.Location = new System.Drawing.Point(902, 10);
            this.btnExportarCtaProveedor.Name = "btnExportarCtaProveedor";
            this.btnExportarCtaProveedor.Size = new System.Drawing.Size(83, 37);
            this.btnExportarCtaProveedor.TabIndex = 33;
            this.btnExportarCtaProveedor.Text = "Exportar";
            this.btnExportarCtaProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarCtaProveedor.UseVisualStyleBackColor = true;
            this.btnExportarCtaProveedor.Click += new System.EventHandler(this.btnExportarCtaProveedor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(14, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 101;
            this.label7.Text = "PACIENTE:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbCliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCliente.Location = new System.Drawing.Point(80, 25);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(223, 19);
            this.cmbCliente.TabIndex = 100;
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
            this.btnBuscar.Location = new System.Drawing.Point(660, 10);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(9, 3, 3, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 37);
            this.btnBuscar.TabIndex = 86;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&BUSCAR";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(564, 21);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(88, 22);
            this.dtpHasta.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(484, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CITA HASTA:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(390, 22);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(87, 22);
            this.dtpDesde.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(310, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "CITA DESDE:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(10, 379);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(995, 1);
            this.label2.TabIndex = 26;
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
            this.btnCancelar.Location = new System.Drawing.Point(883, 393);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&SALIR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl1.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(196, 77);
            // 
            // frmConsultaExterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 443);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConsultaExterna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTORIAL DE FORMULARIOS DE CONSULTAS EXTERNAS Y ANAMNESISEN";
            this.Load += new System.EventHandler(this.frmAgendarCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportarCtaProveedor;
        private System.Windows.Forms.Button btnVerFormulario;
        internal Infragistics.Win.UltraWinGrid.UltraGrid dgvClientes;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.CheckBox cbFiltroCedula;
    }
}