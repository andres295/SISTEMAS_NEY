namespace SCM.Descuentos
{
    partial class frmDescuentosCategoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescuentosCategoria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.gbDescuento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCantidadMax = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad1 = new System.Windows.Forms.Label();
            this.nudCantidadMin = new System.Windows.Forms.NumericUpDown();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnAgregar = new System.Windows.Forms.RadioButton();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.nudDesc = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tCargarProd = new System.Windows.Forms.Timer(this.components);
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDescuentoCategoria = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentoCategoria)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(12, 40);
            this.dgvProveedores.Name = "dgvProveedores";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProveedores.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProveedores.Size = new System.Drawing.Size(774, 252);
            this.dgvProveedores.TabIndex = 9;
            this.dgvProveedores.TabStop = false;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            this.dgvProveedores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProveedores_CellFormatting);
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            this.dgvProveedores.Enter += new System.EventHandler(this.dgvProveedores_Enter);
            this.dgvProveedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProveedores_KeyDown);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(9, 15);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 10;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(76, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(691, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 341);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Size = new System.Drawing.Size(774, 248);
            this.dgvProductos.TabIndex = 12;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // gbDescuento
            // 
            this.gbDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescuento.Controls.Add(this.label3);
            this.gbDescuento.Controls.Add(this.label7);
            this.gbDescuento.Controls.Add(this.label6);
            this.gbDescuento.Controls.Add(this.label5);
            this.gbDescuento.Controls.Add(this.nudCantidadMax);
            this.gbDescuento.Controls.Add(this.lblCantidad1);
            this.gbDescuento.Controls.Add(this.nudCantidadMin);
            this.gbDescuento.Controls.Add(this.rbtnTodos);
            this.gbDescuento.Controls.Add(this.rbtnAgregar);
            this.gbDescuento.Controls.Add(this.btnQuitar);
            this.gbDescuento.Controls.Add(this.dtpHasta);
            this.gbDescuento.Controls.Add(this.dtpDesde);
            this.gbDescuento.Controls.Add(this.label2);
            this.gbDescuento.Controls.Add(this.btnGuardar);
            this.gbDescuento.Controls.Add(this.label11);
            this.gbDescuento.Controls.Add(this.nudDesc);
            this.gbDescuento.Controls.Add(this.label1);
            this.gbDescuento.Enabled = false;
            this.gbDescuento.ForeColor = System.Drawing.Color.Blue;
            this.gbDescuento.Location = new System.Drawing.Point(792, 12);
            this.gbDescuento.Name = "gbDescuento";
            this.gbDescuento.Size = new System.Drawing.Size(342, 280);
            this.gbDescuento.TabIndex = 13;
            this.gbDescuento.TabStop = false;
            this.gbDescuento.Text = "DETALLE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(191, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "%";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(30, 225);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 1);
            this.label7.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(30, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 1);
            this.label6.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 14);
            this.label5.TabIndex = 39;
            this.label5.Text = "CANTIDAD MÁXIMA:";
            // 
            // nudCantidadMax
            // 
            this.nudCantidadMax.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidadMax.Location = new System.Drawing.Point(170, 89);
            this.nudCantidadMax.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidadMax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidadMax.Name = "nudCantidadMax";
            this.nudCantidadMax.Size = new System.Drawing.Size(61, 22);
            this.nudCantidadMax.TabIndex = 38;
            this.nudCantidadMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantidad1
            // 
            this.lblCantidad1.AutoSize = true;
            this.lblCantidad1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad1.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad1.Location = new System.Drawing.Point(25, 64);
            this.lblCantidad1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad1.Name = "lblCantidad1";
            this.lblCantidad1.Size = new System.Drawing.Size(128, 14);
            this.lblCantidad1.TabIndex = 37;
            this.lblCantidad1.Text = "CANTIDAD MÍNIMA:";
            // 
            // nudCantidadMin
            // 
            this.nudCantidadMin.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidadMin.Location = new System.Drawing.Point(170, 58);
            this.nudCantidadMin.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidadMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidadMin.Name = "nudCantidadMin";
            this.nudCantidadMin.Size = new System.Drawing.Size(61, 22);
            this.nudCantidadMin.TabIndex = 36;
            this.nudCantidadMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ForeColor = System.Drawing.Color.Red;
            this.rbtnTodos.Location = new System.Drawing.Point(167, 28);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(96, 18);
            this.rbtnTodos.TabIndex = 35;
            this.rbtnTodos.Text = "MODIFICAR";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            // 
            // rbtnAgregar
            // 
            this.rbtnAgregar.AutoSize = true;
            this.rbtnAgregar.Checked = true;
            this.rbtnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnAgregar.Location = new System.Drawing.Point(28, 28);
            this.rbtnAgregar.Name = "rbtnAgregar";
            this.rbtnAgregar.Size = new System.Drawing.Size(84, 18);
            this.rbtnAgregar.TabIndex = 34;
            this.rbtnAgregar.TabStop = true;
            this.rbtnAgregar.Text = "AGREGAR";
            this.rbtnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Red;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(81, 238);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(79, 34);
            this.btnQuitar.TabIndex = 31;
            this.btnQuitar.TabStop = false;
            this.btnQuitar.Text = "&QUITAR";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(195, 178);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(96, 22);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            this.dtpHasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpHasta_KeyDown);
            this.dtpHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpHasta_KeyPress);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(94, 178);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(93, 22);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            this.dtpDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDesde_KeyDown);
            this.dtpDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDesde_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "VALIDEZ:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(170, 238);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(79, 149);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 14);
            this.label11.TabIndex = 23;
            this.label11.Text = "*";
            // 
            // nudDesc
            // 
            this.nudDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nudDesc.DecimalPlaces = 4;
            this.nudDesc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudDesc.Location = new System.Drawing.Point(94, 147);
            this.nudDesc.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.nudDesc.Name = "nudDesc";
            this.nudDesc.Size = new System.Drawing.Size(93, 22);
            this.nudDesc.TabIndex = 3;
            this.nudDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDesc.Enter += new System.EventHandler(this.nudDesc_Enter);
            this.nudDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudDesc_KeyDown);
            this.nudDesc.Leave += new System.EventHandler(this.nudDesc_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESC. :";
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
            // 
            // tCargarProd
            // 
            this.tCargarProd.Interval = 250;
            this.tCargarProd.Tick += new System.EventHandler(this.tCargarProd_Tick);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscarProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarProducto.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscarProducto.Location = new System.Drawing.Point(76, 313);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(710, 22);
            this.txtBuscarProducto.TabIndex = 14;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            this.txtBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProducto_KeyDown);
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 316);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "BUSCAR:";
            // 
            // dgvDescuentoCategoria
            // 
            this.dgvDescuentoCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDescuentoCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentoCategoria.Location = new System.Drawing.Point(792, 341);
            this.dgvDescuentoCategoria.Name = "dgvDescuentoCategoria";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDescuentoCategoria.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDescuentoCategoria.Size = new System.Drawing.Size(342, 248);
            this.dgvDescuentoCategoria.TabIndex = 16;
            this.dgvDescuentoCategoria.TabStop = false;
            this.dgvDescuentoCategoria.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDescuentoCategoria_CellFormatting);
            this.dgvDescuentoCategoria.SelectionChanged += new System.EventHandler(this.dgvDescuentoCategoria_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(792, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 22);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(72, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 14);
            this.label8.TabIndex = 39;
            this.label8.Text = "DESCUENTOS POR CATEGORIA";
            // 
            // frmDescuentosCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDescuentoCategoria);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbDescuento);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvProveedores);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDescuentosCategoria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DESCUENTOS POR CATEGORIA";
            this.Load += new System.EventHandler(this.frmDescuentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbDescuento.ResumeLayout(false);
            this.gbDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentoCategoria)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Label lblBuscar;
        public System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox gbDescuento;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudDesc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpHasta;
        public System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Timer tCargarProd;
        public System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nudCantidadMax;
        public System.Windows.Forms.Label lblCantidad1;
        public System.Windows.Forms.NumericUpDown nudCantidadMin;
        public System.Windows.Forms.DataGridView dgvDescuentoCategoria;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label8;
    }
}