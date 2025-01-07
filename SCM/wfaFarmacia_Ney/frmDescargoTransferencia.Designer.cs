namespace SCM
{
    partial class frmDescargoTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescargoTransferencia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tCargarProd = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbOpciones = new System.Windows.Forms.PictureBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bntReImprimir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminarProd = new System.Windows.Forms.Button();
            this.btnModificarProd = new System.Windows.Forms.Button();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRegistros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iMPRIMIRENTICKETERAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tCargarProd
            // 
            this.tCargarProd.Interval = 200;
            this.tCargarProd.Tick += new System.EventHandler(this.tCargarProd_Tick);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtotal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.ForeColor = System.Drawing.Color.Blue;
            this.lblSubtotal.Location = new System.Drawing.Point(523, 10);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(140, 21);
            this.lblSubtotal.TabIndex = 9;
            this.lblSubtotal.Text = "0.0000";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "SUBTOTAL:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel6.Controls.Add(this.pbOpciones);
            this.panel6.Controls.Add(this.lblSubtotal);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1112, 40);
            this.panel6.TabIndex = 10;
            // 
            // pbOpciones
            // 
            this.pbOpciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOpciones.Image = ((System.Drawing.Image)(resources.GetObject("pbOpciones.Image")));
            this.pbOpciones.Location = new System.Drawing.Point(3, 5);
            this.pbOpciones.Name = "pbOpciones";
            this.pbOpciones.Size = new System.Drawing.Size(44, 32);
            this.pbOpciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOpciones.TabIndex = 13;
            this.pbOpciones.TabStop = false;
            this.pbOpciones.Click += new System.EventHandler(this.pbOpciones_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(1112, 223);
            this.dgvProductos.TabIndex = 32;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            this.dgvProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvProductos_KeyPress);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 223);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1112, 40);
            this.panel4.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvProductos);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 263);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 537);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bntReImprimir);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnEliminarProd);
            this.panel1.Controls.Add(this.btnModificarProd);
            this.panel1.Controls.Add(this.btnAgregarProd);
            this.panel1.Controls.Add(this.dgvFacturas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 262);
            this.panel1.TabIndex = 29;
            // 
            // bntReImprimir
            // 
            this.bntReImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntReImprimir.ForeColor = System.Drawing.Color.Navy;
            this.bntReImprimir.Image = global::SCM.Properties.Resources.Printer;
            this.bntReImprimir.Location = new System.Drawing.Point(1062, 215);
            this.bntReImprimir.Name = "bntReImprimir";
            this.bntReImprimir.Size = new System.Drawing.Size(47, 41);
            this.bntReImprimir.TabIndex = 51;
            this.bntReImprimir.UseVisualStyleBackColor = true;
            this.bntReImprimir.Click += new System.EventHandler(this.bntReImprimir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(1062, 162);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(47, 47);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminarProd
            // 
            this.btnEliminarProd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarProd.BackColor = System.Drawing.Color.Red;
            this.btnEliminarProd.Enabled = false;
            this.btnEliminarProd.FlatAppearance.BorderSize = 0;
            this.btnEliminarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarProd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarProd.ForeColor = System.Drawing.Color.White;
            this.btnEliminarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarProd.Image")));
            this.btnEliminarProd.Location = new System.Drawing.Point(1062, 109);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(47, 47);
            this.btnEliminarProd.TabIndex = 23;
            this.btnEliminarProd.TabStop = false;
            this.btnEliminarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarProd.UseVisualStyleBackColor = false;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
            // 
            // btnModificarProd
            // 
            this.btnModificarProd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificarProd.Enabled = false;
            this.btnModificarProd.FlatAppearance.BorderSize = 0;
            this.btnModificarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarProd.ForeColor = System.Drawing.Color.White;
            this.btnModificarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarProd.Image")));
            this.btnModificarProd.Location = new System.Drawing.Point(1062, 56);
            this.btnModificarProd.Name = "btnModificarProd";
            this.btnModificarProd.Size = new System.Drawing.Size(47, 47);
            this.btnModificarProd.TabIndex = 22;
            this.btnModificarProd.TabStop = false;
            this.btnModificarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarProd.UseVisualStyleBackColor = false;
            this.btnModificarProd.Click += new System.EventHandler(this.btnModificarProd_Click);
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarProd.Enabled = false;
            this.btnAgregarProd.FlatAppearance.BorderSize = 0;
            this.btnAgregarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProd.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarProd.Image")));
            this.btnAgregarProd.Location = new System.Drawing.Point(1062, 3);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(47, 47);
            this.btnAgregarProd.TabIndex = 21;
            this.btnAgregarProd.TabStop = false;
            this.btnAgregarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarProd.UseVisualStyleBackColor = false;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.Name = "dgvFacturas";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFacturas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFacturas.Size = new System.Drawing.Size(1056, 262);
            this.dgvFacturas.TabIndex = 20;
            this.dgvFacturas.TabStop = false;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            this.dgvFacturas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturas_CellFormatting);
            this.dgvFacturas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_RowEnter);
            this.dgvFacturas.Enter += new System.EventHandler(this.dgvFacturas_Enter);
            this.dgvFacturas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFacturas_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 263);
            this.panel2.TabIndex = 30;
            // 
            // txtRegistros
            // 
            this.txtRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRegistros.Enabled = false;
            this.txtRegistros.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRegistros.Location = new System.Drawing.Point(1063, 19);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(67, 22);
            this.txtRegistros.TabIndex = 36;
            this.txtRegistros.TabStop = false;
            this.txtRegistros.Text = "0";
            this.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(1053, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 22);
            this.label3.TabIndex = 35;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(418, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(252, 22);
            this.txtBuscar.TabIndex = 29;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(326, 22);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(86, 14);
            this.lblBuscar.TabIndex = 34;
            this.lblBuscar.Text = "PROVEEDOR:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(319, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 34);
            this.label1.TabIndex = 32;
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
            this.btnEliminar.Location = new System.Drawing.Point(217, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(93, 34);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "&ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(109, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 34);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.TabStop = false;
            this.btnModificar.Text = "&MODIFICAR";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(12, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 34);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "&AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAgregar_KeyDown);
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iMPRIMIRENTICKETERAToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(267, 26);
            // 
            // iMPRIMIRENTICKETERAToolStripMenuItem
            // 
            this.iMPRIMIRENTICKETERAToolStripMenuItem.Name = "iMPRIMIRENTICKETERAToolStripMenuItem";
            this.iMPRIMIRENTICKETERAToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.iMPRIMIRENTICKETERAToolStripMenuItem.Text = "IMPRIMIR EN TICKETERA (CTRL + R)";
            this.iMPRIMIRENTICKETERAToolStripMenuItem.Click += new System.EventHandler(this.iMPRIMIRENTICKETERAToolStripMenuItem_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Navy;
            this.btnImprimir.Location = new System.Drawing.Point(973, 17);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 25);
            this.btnImprimir.TabIndex = 47;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(824, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 46;
            this.label5.Text = "HASTA:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(673, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "DESDE:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(878, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 22);
            this.dtpHasta.TabIndex = 44;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(729, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 22);
            this.dtpDesde.TabIndex = 43;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // frmDescargoTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtRegistros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDescargoTransferencia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DESCARGO TRANSFERENCIA DE INVENTARIO (DT)";
            this.Load += new System.EventHandler(this.frmCargoAjuste_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tCargarProd;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnEliminarProd;
        public System.Windows.Forms.Button btnModificarProd;
        public System.Windows.Forms.Button btnAgregarProd;
        public System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtRegistros;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Timer tEnfoque;
        private System.Windows.Forms.PictureBox pbOpciones;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRENTICKETERAToolStripMenuItem;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpHasta;
        public System.Windows.Forms.DateTimePicker dtpDesde;
        public System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.Button bntReImprimir;
    }
}