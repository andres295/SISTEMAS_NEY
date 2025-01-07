namespace SCM.CxC
{
    partial class frmComprobanteRetencionCliente
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CLIENTES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestoRetener");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorImpuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcRetencion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorRetenido");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Id");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImpuestoRetener");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ValorImpuesto");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("PorcRetencion");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("BaseImponible");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("ValorRetenido");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprobanteRetencionCliente));
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtFechaEmisionDocumento = new System.Windows.Forms.DateTimePicker();
            this.cmbCliente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.dtPeriodoFiscal = new System.Windows.Forms.DateTimePicker();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudBaseImponible = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddRetencion = new System.Windows.Forms.Button();
            this.nudValorRetenido = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nudPorcRetencion = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbValorImpuesto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbImpuestoRetener = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uGridDetalleRetencion = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource7 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.nvRetenciones = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lbldFactura = new System.Windows.Forms.Label();
            this.bsRetenciones = new System.Windows.Forms.BindingSource(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseImponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorRetenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcRetencion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValorImpuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbImpuestoRetener)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridDetalleRetencion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvRetenciones)).BeginInit();
            this.nvRetenciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetenciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(13, 544);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(579, 1);
            this.label12.TabIndex = 118;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtFechaEmisionDocumento);
            this.groupBox2.Controls.Add(this.cmbCliente);
            this.groupBox2.Controls.Add(this.dtPeriodoFiscal);
            this.groupBox2.Controls.Add(this.cbTipoDocumento);
            this.groupBox2.Controls.Add(this.dtFecha);
            this.groupBox2.Controls.Add(this.txtNumDocumento);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(0, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 117);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Generales de Retención";
            // 
            // dtFechaEmisionDocumento
            // 
            this.dtFechaEmisionDocumento.Enabled = false;
            this.dtFechaEmisionDocumento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEmisionDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEmisionDocumento.Location = new System.Drawing.Point(101, 81);
            this.dtFechaEmisionDocumento.Name = "dtFechaEmisionDocumento";
            this.dtFechaEmisionDocumento.Size = new System.Drawing.Size(90, 22);
            this.dtFechaEmisionDocumento.TabIndex = 146;
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCliente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbCliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCliente.Location = new System.Drawing.Point(101, 50);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(220, 19);
            this.cmbCliente.TabIndex = 2;
            // 
            // dtPeriodoFiscal
            // 
            this.dtPeriodoFiscal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriodoFiscal.Location = new System.Drawing.Point(444, 78);
            this.dtPeriodoFiscal.Name = "dtPeriodoFiscal";
            this.dtPeriodoFiscal.Size = new System.Drawing.Size(90, 22);
            this.dtPeriodoFiscal.TabIndex = 5;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.AutoCompleteCustomSource.AddRange(new string[] {
            "FACTURA",
            "NOTA DE DÉBITO",
            "LIQUIDACIÓN DE COMPRA",
            "OTROS"});
            this.cbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Items.AddRange(new object[] {
            "VENTA",
            "NOTA DE DÉBITO",
            "LIQUIDACIÓN DE COMPRA",
            "OTROS",
            "FACTURA"});
            this.cbTipoDocumento.Location = new System.Drawing.Point(443, 26);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(152, 21);
            this.cbTipoDocumento.TabIndex = 4;
            // 
            // dtFecha
            // 
            this.dtFecha.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(101, 22);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(90, 22);
            this.dtFecha.TabIndex = 1;
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumDocumento.Enabled = false;
            this.txtNumDocumento.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumDocumento.ForeColor = System.Drawing.Color.Maroon;
            this.txtNumDocumento.Location = new System.Drawing.Point(444, 53);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(152, 22);
            this.txtNumDocumento.TabIndex = 88;
            this.txtNumDocumento.Text = "XXXXX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(327, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 14);
            this.label9.TabIndex = 84;
            this.label9.Text = "Nro. Documento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(326, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 14);
            this.label8.TabIndex = 83;
            this.label8.Text = "Periodo Fiscal:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(6, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 14);
            this.label7.TabIndex = 82;
            this.label7.Text = "Fecha Emisión:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 81;
            this.label6.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(326, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 80;
            this.label5.Text = "Tipo Documento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 78;
            this.label1.Text = "Fecha:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudBaseImponible);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.btnAddRetencion);
            this.groupBox3.Controls.Add(this.nudValorRetenido);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.nudPorcRetencion);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cmbValorImpuesto);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbImpuestoRetener);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(0, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 176);
            this.groupBox3.TabIndex = 121;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle de Retención";
            // 
            // nudBaseImponible
            // 
            this.nudBaseImponible.DecimalPlaces = 2;
            this.nudBaseImponible.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBaseImponible.ForeColor = System.Drawing.Color.Navy;
            this.nudBaseImponible.Location = new System.Drawing.Point(161, 19);
            this.nudBaseImponible.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.nudBaseImponible.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudBaseImponible.Name = "nudBaseImponible";
            this.nudBaseImponible.Size = new System.Drawing.Size(99, 23);
            this.nudBaseImponible.TabIndex = 6;
            this.nudBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBaseImponible.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudBaseImponible_KeyDown);
            this.nudBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudBaseImponible_KeyPress);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Location = new System.Drawing.Point(16, 131);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(579, 1);
            this.label18.TabIndex = 119;
            // 
            // btnAddRetencion
            // 
            this.btnAddRetencion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRetencion.BackColor = System.Drawing.Color.Green;
            this.btnAddRetencion.FlatAppearance.BorderSize = 0;
            this.btnAddRetencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRetencion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddRetencion.ForeColor = System.Drawing.Color.White;
            this.btnAddRetencion.Image = global::SCM.Properties.Resources.Symbol_Check_2;
            this.btnAddRetencion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRetencion.Location = new System.Drawing.Point(498, 137);
            this.btnAddRetencion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnAddRetencion.Name = "btnAddRetencion";
            this.btnAddRetencion.Size = new System.Drawing.Size(94, 34);
            this.btnAddRetencion.TabIndex = 6;
            this.btnAddRetencion.TabStop = false;
            this.btnAddRetencion.Text = "AÑADIR";
            this.btnAddRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRetencion.UseVisualStyleBackColor = false;
            this.btnAddRetencion.Click += new System.EventHandler(this.btnAddRetencion_Click);
            // 
            // nudValorRetenido
            // 
            this.nudValorRetenido.DecimalPlaces = 2;
            this.nudValorRetenido.Enabled = false;
            this.nudValorRetenido.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValorRetenido.Location = new System.Drawing.Point(463, 99);
            this.nudValorRetenido.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudValorRetenido.Name = "nudValorRetenido";
            this.nudValorRetenido.Size = new System.Drawing.Size(132, 26);
            this.nudValorRetenido.TabIndex = 10;
            this.nudValorRetenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(449, 108);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 13);
            this.label17.TabIndex = 108;
            this.label17.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(302, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 18);
            this.label16.TabIndex = 106;
            this.label16.Text = "VALOR RETENIDO:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(15, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 104;
            this.label14.Text = "PROC. RETENCIÓN:";
            // 
            // nudPorcRetencion
            // 
            this.nudPorcRetencion.DecimalPlaces = 2;
            this.nudPorcRetencion.Enabled = false;
            this.nudPorcRetencion.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudPorcRetencion.Location = new System.Drawing.Point(161, 100);
            this.nudPorcRetencion.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudPorcRetencion.Name = "nudPorcRetencion";
            this.nudPorcRetencion.Size = new System.Drawing.Size(99, 22);
            this.nudPorcRetencion.TabIndex = 9;
            this.nudPorcRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(147, 107);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 105;
            this.label15.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(15, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "BASE IMPONIBLE:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(147, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 101;
            this.label13.Text = "*";
            // 
            // cmbValorImpuesto
            // 
            this.cmbValorImpuesto.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbValorImpuesto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbValorImpuesto.Location = new System.Drawing.Point(161, 73);
            this.cmbValorImpuesto.Name = "cmbValorImpuesto";
            this.cmbValorImpuesto.Size = new System.Drawing.Size(434, 19);
            this.cmbValorImpuesto.TabIndex = 8;
            this.cmbValorImpuesto.ValueChanged += new System.EventHandler(this.cmbValorImpuesto_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "VALOR IMPUESTO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(147, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "*";
            // 
            // cmbImpuestoRetener
            // 
            this.cmbImpuestoRetener.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbImpuestoRetener.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbImpuestoRetener.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "RENTA";
            valueListItem2.DataValue = "2";
            valueListItem2.DisplayText = "IVA";
            valueListItem3.DataValue = "3";
            valueListItem3.DisplayText = "ISD";
            this.cmbImpuestoRetener.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cmbImpuestoRetener.Location = new System.Drawing.Point(161, 48);
            this.cmbImpuestoRetener.Name = "cmbImpuestoRetener";
            this.cmbImpuestoRetener.Size = new System.Drawing.Size(99, 19);
            this.cmbImpuestoRetener.TabIndex = 7;
            this.cmbImpuestoRetener.ValueChanged += new System.EventHandler(this.cmbImpuestoRetener_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "IMPUESTO A RETENER:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(147, 51);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 95;
            this.label10.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uGridDetalleRetencion);
            this.groupBox1.Controls.Add(this.nvRetenciones);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 220);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Retención";
            // 
            // uGridDetalleRetencion
            // 
            this.uGridDetalleRetencion.DataSource = this.ultraDataSource7;
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackHatchStyle = Infragistics.Win.BackHatchStyle.LightHorizontal;
            this.uGridDetalleRetencion.DisplayLayout.Appearance = appearance1;
            this.uGridDetalleRetencion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 50;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.uGridDetalleRetencion.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridDetalleRetencion.DisplayLayout.InterBandSpacing = 10;
            this.uGridDetalleRetencion.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uGridDetalleRetencion.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGridDetalleRetencion.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.LightYellow;
            appearance3.BackColor2 = System.Drawing.Color.PaleGoldenrod;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGridDetalleRetencion.DisplayLayout.Override.CellAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.LimeGreen;
            appearance4.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGridDetalleRetencion.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.uGridDetalleRetencion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.DarkGreen;
            this.uGridDetalleRetencion.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.uGridDetalleRetencion.DisplayLayout.Override.RowSelectorWidth = 10;
            this.uGridDetalleRetencion.DisplayLayout.Override.RowSpacingAfter = 3;
            this.uGridDetalleRetencion.DisplayLayout.Override.RowSpacingBefore = 3;
            appearance6.BackColor = System.Drawing.Color.DarkGreen;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance6.BackHatchStyle = Infragistics.Win.BackHatchStyle.None;
            appearance6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.uGridDetalleRetencion.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.uGridDetalleRetencion.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uGridDetalleRetencion.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.uGridDetalleRetencion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridDetalleRetencion.Location = new System.Drawing.Point(3, 41);
            this.uGridDetalleRetencion.Name = "uGridDetalleRetencion";
            this.uGridDetalleRetencion.Size = new System.Drawing.Size(604, 176);
            this.uGridDetalleRetencion.TabIndex = 75;
            this.uGridDetalleRetencion.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGridDetalleRetencion_InitializeLayout);
            // 
            // ultraDataSource7
            // 
            this.ultraDataSource7.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6});
            this.ultraDataSource7.Band.Key = "CLIENTES";
            // 
            // nvRetenciones
            // 
            this.nvRetenciones.AddNewItem = null;
            this.nvRetenciones.CountItem = this.bindingNavigatorCountItem;
            this.nvRetenciones.DeleteItem = null;
            this.nvRetenciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.Eliminar,
            this.toolStripSeparator4});
            this.nvRetenciones.Location = new System.Drawing.Point(3, 16);
            this.nvRetenciones.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nvRetenciones.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nvRetenciones.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nvRetenciones.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nvRetenciones.Name = "nvRetenciones";
            this.nvRetenciones.PositionItem = this.bindingNavigatorPositionItem;
            this.nvRetenciones.Size = new System.Drawing.Size(604, 25);
            this.nvRetenciones.TabIndex = 74;
            this.nvRetenciones.Text = "bindingNavigator1";
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
            // Eliminar
            // 
            this.Eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eliminar.Image = global::SCM.Properties.Resources.Symbol_Delete_2;
            this.Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(23, 22);
            this.Eliminar.Text = "Eliminar Retención";
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            this.btnCancelar.Location = new System.Drawing.Point(495, 553);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 109;
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
            this.btnGuardar.Location = new System.Drawing.Point(395, 553);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(380, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 123;
            this.label19.Text = "No. Factura:";
            // 
            // lbldFactura
            // 
            this.lbldFactura.AutoSize = true;
            this.lbldFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldFactura.ForeColor = System.Drawing.Color.Maroon;
            this.lbldFactura.Location = new System.Drawing.Point(457, 5);
            this.lbldFactura.Name = "lbldFactura";
            this.lbldFactura.Size = new System.Drawing.Size(14, 13);
            this.lbldFactura.TabIndex = 140;
            this.lbldFactura.Text = "1";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(228, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 142;
            this.label20.Text = "F.Emision:";
            // 
            // frmComprobanteRetencionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 594);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lbldFactura);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmComprobanteRetencionCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMPROBANTE DE RETENCIÓN - AÑADIR COMPROBANTE DE RETENCIÓN";
            this.Load += new System.EventHandler(this.frmComprobanteRetencionCliente_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseImponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorRetenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcRetencion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValorImpuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbImpuestoRetener)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridDetalleRetencion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nvRetenciones)).EndInit();
            this.nvRetenciones.ResumeLayout(false);
            this.nvRetenciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetenciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNumDocumento;
        public System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbImpuestoRetener;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbValorImpuesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown nudValorRetenido;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.NumericUpDown nudPorcRetencion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddRetencion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        internal Infragistics.Win.UltraWinGrid.UltraGrid uGridDetalleRetencion;
        private System.Windows.Forms.BindingNavigator nvRetenciones;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton Eliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.DateTimePicker dtPeriodoFiscal;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbCliente;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lbldFactura;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource7;
        private System.Windows.Forms.BindingSource bsRetenciones;
        public System.Windows.Forms.NumericUpDown nudBaseImponible;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.DateTimePicker dtFechaEmisionDocumento;
    }
}