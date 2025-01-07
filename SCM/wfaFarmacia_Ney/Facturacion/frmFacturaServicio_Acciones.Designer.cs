namespace SCM.Facturacion
{
    partial class frmFacturaServicio_Acciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturaServicio_Acciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvServiciosFacturar = new System.Windows.Forms.DataGridView();
            this.gbModificar = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.nudDescuentoEditar = new System.Windows.Forms.NumericUpDown();
            this.btnSalirEditar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnGuardarEditar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.nudCantidadEditar = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbServicioEditar = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminarServicio = new System.Windows.Forms.Button();
            this.btnAgregarServicio = new System.Windows.Forms.Button();
            this.btnModificarServicio = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDoctor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnRefrescarDoctor = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintVenta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVentas_Temp = new System.Windows.Forms.Button();
            this.txtRegistros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblF11Title = new System.Windows.Forms.Label();
            this.lblF11 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.tCargarServicios = new System.Windows.Forms.Timer(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosFacturar)).BeginInit();
            this.gbModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuentoEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServicioEditar)).BeginInit();
            this.gbAcciones.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoctor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvServiciosFacturar);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(5, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1125, 176);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servicios agregados para facturar:";
            // 
            // dgvServiciosFacturar
            // 
            this.dgvServiciosFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiciosFacturar.Location = new System.Drawing.Point(3, 17);
            this.dgvServiciosFacturar.Name = "dgvServiciosFacturar";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosFacturar.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosFacturar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvServiciosFacturar.Size = new System.Drawing.Size(1117, 153);
            this.dgvServiciosFacturar.TabIndex = 9;
            this.dgvServiciosFacturar.TabStop = false;
            this.dgvServiciosFacturar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvServicios_CellFormatting);
            this.dgvServiciosFacturar.SelectionChanged += new System.EventHandler(this.dgvServiciosFacturar_SelectionChanged);
            this.dgvServiciosFacturar.Enter += new System.EventHandler(this.dgvServiciosFacturar_Enter);
            this.dgvServiciosFacturar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServiciosFacturar_KeyDown);
            // 
            // gbModificar
            // 
            this.gbModificar.BackColor = System.Drawing.Color.Transparent;
            this.gbModificar.BackgroundImage = global::SCM.Properties.Resources.fondo1;
            this.gbModificar.Controls.Add(this.label37);
            this.gbModificar.Controls.Add(this.nudDescuentoEditar);
            this.gbModificar.Controls.Add(this.btnSalirEditar);
            this.gbModificar.Controls.Add(this.label19);
            this.gbModificar.Controls.Add(this.btnGuardarEditar);
            this.gbModificar.Controls.Add(this.label18);
            this.gbModificar.Controls.Add(this.nudCantidadEditar);
            this.gbModificar.Controls.Add(this.label13);
            this.gbModificar.Controls.Add(this.cmbServicioEditar);
            this.gbModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbModificar.ForeColor = System.Drawing.Color.White;
            this.gbModificar.Location = new System.Drawing.Point(386, 181);
            this.gbModificar.Name = "gbModificar";
            this.gbModificar.Size = new System.Drawing.Size(400, 244);
            this.gbModificar.TabIndex = 95;
            this.gbModificar.TabStop = false;
            this.gbModificar.Text = "............................Datos a modificar:.........................";
            this.gbModificar.Visible = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(9, 82);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(218, 33);
            this.label37.TabIndex = 133;
            this.label37.Text = "DESCUENTO $:";
            // 
            // nudDescuentoEditar
            // 
            this.nudDescuentoEditar.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuentoEditar.Location = new System.Drawing.Point(227, 78);
            this.nudDescuentoEditar.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudDescuentoEditar.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDescuentoEditar.Name = "nudDescuentoEditar";
            this.nudDescuentoEditar.Size = new System.Drawing.Size(150, 40);
            this.nudDescuentoEditar.TabIndex = 132;
            this.nudDescuentoEditar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDescuentoEditar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudDescuentoEditar_KeyDown);
            // 
            // btnSalirEditar
            // 
            this.btnSalirEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalirEditar.Location = new System.Drawing.Point(89, 195);
            this.btnSalirEditar.Name = "btnSalirEditar";
            this.btnSalirEditar.Size = new System.Drawing.Size(111, 35);
            this.btnSalirEditar.TabIndex = 131;
            this.btnSalirEditar.Text = "Cancelar";
            this.btnSalirEditar.UseVisualStyleBackColor = false;
            this.btnSalirEditar.Click += new System.EventHandler(this.btnSalirEditar_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label19.Location = new System.Drawing.Point(6, 183);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(389, 1);
            this.label19.TabIndex = 130;
            // 
            // btnGuardarEditar
            // 
            this.btnGuardarEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarEditar.BackColor = System.Drawing.Color.Green;
            this.btnGuardarEditar.FlatAppearance.BorderSize = 0;
            this.btnGuardarEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEditar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarEditar.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarEditar.Image")));
            this.btnGuardarEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarEditar.Location = new System.Drawing.Point(216, 195);
            this.btnGuardarEditar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardarEditar.Name = "btnGuardarEditar";
            this.btnGuardarEditar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardarEditar.TabIndex = 129;
            this.btnGuardarEditar.TabStop = false;
            this.btnGuardarEditar.Text = "&GUARDAR";
            this.btnGuardarEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarEditar.UseVisualStyleBackColor = false;
            this.btnGuardarEditar.Click += new System.EventHandler(this.btnGuardarEditar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(9, 126);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 33);
            this.label18.TabIndex = 127;
            this.label18.Text = "CANTIDAD:";
            // 
            // nudCantidadEditar
            // 
            this.nudCantidadEditar.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidadEditar.Location = new System.Drawing.Point(227, 124);
            this.nudCantidadEditar.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidadEditar.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidadEditar.Name = "nudCantidadEditar";
            this.nudCantidadEditar.Size = new System.Drawing.Size(150, 40);
            this.nudCantidadEditar.TabIndex = 126;
            this.nudCantidadEditar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidadEditar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidadEditar_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Lavender;
            this.label13.Location = new System.Drawing.Point(17, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 125;
            this.label13.Text = "SERVICIO:";
            // 
            // cmbServicioEditar
            // 
            this.cmbServicioEditar.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbServicioEditar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbServicioEditar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServicioEditar.Location = new System.Drawing.Point(20, 45);
            this.cmbServicioEditar.Name = "cmbServicioEditar";
            this.cmbServicioEditar.Size = new System.Drawing.Size(357, 20);
            this.cmbServicioEditar.TabIndex = 124;
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.BackColor = System.Drawing.Color.LemonChiffon;
            this.gbAcciones.Controls.Add(this.btnGuardar);
            this.gbAcciones.Controls.Add(this.btnEliminarServicio);
            this.gbAcciones.Controls.Add(this.btnAgregarServicio);
            this.gbAcciones.Controls.Add(this.btnModificarServicio);
            this.gbAcciones.Location = new System.Drawing.Point(1062, 51);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(67, 242);
            this.gbAcciones.TabIndex = 94;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acción";
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
            this.btnGuardar.Location = new System.Drawing.Point(9, 184);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(47, 47);
            this.btnGuardar.TabIndex = 96;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminarServicio
            // 
            this.btnEliminarServicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarServicio.BackColor = System.Drawing.Color.Red;
            this.btnEliminarServicio.Enabled = false;
            this.btnEliminarServicio.FlatAppearance.BorderSize = 0;
            this.btnEliminarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarServicio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarServicio.ForeColor = System.Drawing.Color.White;
            this.btnEliminarServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarServicio.Image")));
            this.btnEliminarServicio.Location = new System.Drawing.Point(9, 130);
            this.btnEliminarServicio.Name = "btnEliminarServicio";
            this.btnEliminarServicio.Size = new System.Drawing.Size(47, 47);
            this.btnEliminarServicio.TabIndex = 96;
            this.btnEliminarServicio.TabStop = false;
            this.btnEliminarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarServicio.UseVisualStyleBackColor = false;
            this.btnEliminarServicio.Click += new System.EventHandler(this.btnEliminarServicio_Click_1);
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarServicio.Enabled = false;
            this.btnAgregarServicio.FlatAppearance.BorderSize = 0;
            this.btnAgregarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarServicio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarServicio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarServicio.Image")));
            this.btnAgregarServicio.Location = new System.Drawing.Point(9, 22);
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.Size = new System.Drawing.Size(47, 47);
            this.btnAgregarServicio.TabIndex = 94;
            this.btnAgregarServicio.TabStop = false;
            this.btnAgregarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click_1);
            // 
            // btnModificarServicio
            // 
            this.btnModificarServicio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificarServicio.Enabled = false;
            this.btnModificarServicio.FlatAppearance.BorderSize = 0;
            this.btnModificarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarServicio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarServicio.ForeColor = System.Drawing.Color.White;
            this.btnModificarServicio.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarServicio.Image")));
            this.btnModificarServicio.Location = new System.Drawing.Point(9, 76);
            this.btnModificarServicio.Name = "btnModificarServicio";
            this.btnModificarServicio.Size = new System.Drawing.Size(47, 47);
            this.btnModificarServicio.TabIndex = 95;
            this.btnModificarServicio.TabStop = false;
            this.btnModificarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarServicio.UseVisualStyleBackColor = false;
            this.btnModificarServicio.Click += new System.EventHandler(this.btnModificarServicio_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lblTotalPagar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblSubtotal);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(5, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1130, 55);
            this.groupBox4.TabIndex = 100;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TOTALES:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.Crimson;
            this.lblDescuento.Location = new System.Drawing.Point(537, 11);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(142, 33);
            this.lblDescuento.TabIndex = 138;
            this.lblDescuento.Text = "99999.99";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(765, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1, 42);
            this.label16.TabIndex = 137;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label14.Location = new System.Drawing.Point(333, 10);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1, 42);
            this.label14.TabIndex = 136;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Location = new System.Drawing.Point(977, 10);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(142, 33);
            this.lblTotalPagar.TabIndex = 29;
            this.lblTotalPagar.Text = "99999.99";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(812, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "TOTAL A PAGAR:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(367, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "DESCUENTO:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblSubtotal.Location = new System.Drawing.Point(149, 13);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(142, 33);
            this.lblSubtotal.TabIndex = 23;
            this.lblSubtotal.Text = "99999.99";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "SUBTOTAL:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbDoctor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbDoctor.Location = new System.Drawing.Point(73, 65);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(469, 21);
            this.cmbDoctor.TabIndex = 2;
            // 
            // btnRefrescarDoctor
            // 
            this.btnRefrescarDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescarDoctor.BackColor = System.Drawing.Color.Transparent;
            this.btnRefrescarDoctor.FlatAppearance.BorderSize = 0;
            this.btnRefrescarDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarDoctor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescarDoctor.ForeColor = System.Drawing.Color.Transparent;
            this.btnRefrescarDoctor.Image = global::SCM.Properties.Resources.Refresh24;
            this.btnRefrescarDoctor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescarDoctor.Location = new System.Drawing.Point(572, 60);
            this.btnRefrescarDoctor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnRefrescarDoctor.Name = "btnRefrescarDoctor";
            this.btnRefrescarDoctor.Size = new System.Drawing.Size(36, 29);
            this.btnRefrescarDoctor.TabIndex = 126;
            this.btnRefrescarDoctor.TabStop = false;
            this.btnRefrescarDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescarDoctor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescarDoctor.UseVisualStyleBackColor = false;
            this.btnRefrescarDoctor.Click += new System.EventHandler(this.btnRefrescarDoctor_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDoctor.ForeColor = System.Drawing.Color.White;
            this.btnDoctor.Location = new System.Drawing.Point(548, 65);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(24, 22);
            this.btnDoctor.TabIndex = 124;
            this.btnDoctor.TabStop = false;
            this.btnDoctor.Text = "...";
            this.btnDoctor.UseVisualStyleBackColor = false;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(5, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 14);
            this.label15.TabIndex = 122;
            this.label15.Text = "DOCTOR:";
            // 
            // txtNumVenta
            // 
            this.txtNumVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNumVenta.Enabled = false;
            this.txtNumVenta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumVenta.ForeColor = System.Drawing.Color.Navy;
            this.txtNumVenta.Location = new System.Drawing.Point(1046, 15);
            this.txtNumVenta.Name = "txtNumVenta";
            this.txtNumVenta.Size = new System.Drawing.Size(83, 22);
            this.txtNumVenta.TabIndex = 145;
            this.txtNumVenta.TabStop = false;
            this.txtNumVenta.Text = "0";
            this.txtNumVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1062, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 144;
            this.label1.Text = "No.Vta:";
            // 
            // btnPrintVenta
            // 
            this.btnPrintVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPrintVenta.Enabled = false;
            this.btnPrintVenta.FlatAppearance.BorderSize = 0;
            this.btnPrintVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintVenta.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintVenta.ForeColor = System.Drawing.Color.White;
            this.btnPrintVenta.Image = global::SCM.Properties.Resources.Printer;
            this.btnPrintVenta.Location = new System.Drawing.Point(361, 9);
            this.btnPrintVenta.Name = "btnPrintVenta";
            this.btnPrintVenta.Size = new System.Drawing.Size(33, 34);
            this.btnPrintVenta.TabIndex = 143;
            this.btnPrintVenta.TabStop = false;
            this.btnPrintVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintVenta.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(904, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 142;
            this.label7.Text = "REGISTROS:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(308, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 34);
            this.label4.TabIndex = 136;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::SCM.Properties.Resources.Symbol_Delete_2;
            this.btnCancelar.Location = new System.Drawing.Point(315, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(33, 34);
            this.btnCancelar.TabIndex = 137;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVentas_Temp
            // 
            this.btnVentas_Temp.BackColor = System.Drawing.Color.DarkOrange;
            this.btnVentas_Temp.FlatAppearance.BorderSize = 0;
            this.btnVentas_Temp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas_Temp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnVentas_Temp.ForeColor = System.Drawing.Color.White;
            this.btnVentas_Temp.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas_Temp.Image")));
            this.btnVentas_Temp.Location = new System.Drawing.Point(406, 9);
            this.btnVentas_Temp.Name = "btnVentas_Temp";
            this.btnVentas_Temp.Size = new System.Drawing.Size(33, 34);
            this.btnVentas_Temp.TabIndex = 134;
            this.btnVentas_Temp.TabStop = false;
            this.btnVentas_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas_Temp.UseVisualStyleBackColor = false;
            this.btnVentas_Temp.Visible = false;
            // 
            // txtRegistros
            // 
            this.txtRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRegistros.Enabled = false;
            this.txtRegistros.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRegistros.Location = new System.Drawing.Point(988, 15);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(52, 22);
            this.txtRegistros.TabIndex = 141;
            this.txtRegistros.TabStop = false;
            this.txtRegistros.Text = "0";
            this.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(903, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 22);
            this.label2.TabIndex = 140;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(511, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(386, 22);
            this.txtBuscar.TabIndex = 131;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            this.txtBuscar.MouseLeave += new System.EventHandler(this.txtBuscar_MouseLeave);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(445, 19);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 139;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(443, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 34);
            this.label6.TabIndex = 135;
            this.label6.Visible = false;
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.BackColor = System.Drawing.Color.Red;
            this.btnEliminarFactura.Enabled = false;
            this.btnEliminarFactura.FlatAppearance.BorderSize = 0;
            this.btnEliminarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFactura.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarFactura.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarFactura.Image")));
            this.btnEliminarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFactura.Location = new System.Drawing.Point(210, 9);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(93, 34);
            this.btnEliminarFactura.TabIndex = 138;
            this.btnEliminarFactura.TabStop = false;
            this.btnEliminarFactura.Text = "&ELIMINAR";
            this.btnEliminarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarFactura.UseVisualStyleBackColor = false;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificarCliente.Enabled = false;
            this.btnModificarCliente.FlatAppearance.BorderSize = 0;
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarCliente.ForeColor = System.Drawing.Color.White;
            this.btnModificarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarCliente.Image")));
            this.btnModificarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarCliente.Location = new System.Drawing.Point(102, 9);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(102, 34);
            this.btnModificarCliente.TabIndex = 133;
            this.btnModificarCliente.TabStop = false;
            this.btnModificarCliente.Text = "&MODIFICAR";
            this.btnModificarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarCliente.UseVisualStyleBackColor = false;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarCliente.FlatAppearance.BorderSize = 0;
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCliente.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.Image")));
            this.btnAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Location = new System.Drawing.Point(5, 9);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(91, 34);
            this.btnAgregarCliente.TabIndex = 132;
            this.btnAgregarCliente.TabStop = false;
            this.btnAgregarCliente.Text = "&AGREGAR";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblF11Title);
            this.groupBox1.Controls.Add(this.lblF11);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Location = new System.Drawing.Point(5, 553);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1124, 52);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones:";
            // 
            // lblF11Title
            // 
            this.lblF11Title.AutoSize = true;
            this.lblF11Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblF11Title.Location = new System.Drawing.Point(412, 25);
            this.lblF11Title.Name = "lblF11Title";
            this.lblF11Title.Size = new System.Drawing.Size(125, 14);
            this.lblF11Title.TabIndex = 40;
            this.lblF11Title.Text = "Imprimir Cotización";
            // 
            // lblF11
            // 
            this.lblF11.AutoSize = true;
            this.lblF11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblF11.Location = new System.Drawing.Point(380, 25);
            this.lblF11.Name = "lblF11";
            this.lblF11.Size = new System.Drawing.Size(33, 14);
            this.lblF11.TabIndex = 39;
            this.lblF11.Text = "F11:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label28.Location = new System.Drawing.Point(319, 25);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 14);
            this.label28.TabIndex = 38;
            this.label28.Text = "Gastos";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label29.Location = new System.Drawing.Point(288, 25);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(25, 14);
            this.label29.TabIndex = 37;
            this.label29.Text = "F8:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label26.Location = new System.Drawing.Point(178, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(94, 14);
            this.label26.TabIndex = 36;
            this.label26.Text = "Guardar venta";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label27.Location = new System.Drawing.Point(155, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 14);
            this.label27.TabIndex = 35;
            this.label27.Text = "F7:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(35, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 14);
            this.label20.TabIndex = 28;
            this.label20.Text = "Selector servicio.";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label36.Location = new System.Drawing.Point(12, 25);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(25, 14);
            this.label36.TabIndex = 23;
            this.label36.Text = "F1:";
            // 
            // dgvServicios
            // 
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(5, 96);
            this.dgvServicios.Name = "dgvServicios";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicios.Size = new System.Drawing.Size(1055, 197);
            this.dgvServicios.TabIndex = 147;
            this.dgvServicios.TabStop = false;
            this.dgvServicios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvServicios_CellFormatting_1);
            this.dgvServicios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_RowEnter);
            this.dgvServicios.DoubleClick += new System.EventHandler(this.dgvServicios_DoubleClick);
            this.dgvServicios.Enter += new System.EventHandler(this.dgvServicios_Enter);
            this.dgvServicios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServicios_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(8, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1050, 1);
            this.label9.TabIndex = 148;
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // tCargarServicios
            // 
            this.tCargarServicios.Enabled = true;
            this.tCargarServicios.Interval = 1;
            this.tCargarServicios.Tick += new System.EventHandler(this.tCargarServicios_Tick);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label17.Location = new System.Drawing.Point(354, 10);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(1, 34);
            this.label17.TabIndex = 149;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label38.Location = new System.Drawing.Point(399, 9);
            this.label38.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(1, 34);
            this.label38.TabIndex = 150;
            // 
            // frmFacturaServicio_Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 604);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gbModificar);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintVenta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVentas_Temp);
            this.Controls.Add(this.txtRegistros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.btnRefrescarDoctor);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFacturaServicio_Acciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURACIÓN DE SERVICIOS MÉDICOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturaServicio_Acciones_FormClosing);
            this.Load += new System.EventHandler(this.frmServicio_Acciones_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosFacturar)).EndInit();
            this.gbModificar.ResumeLayout(false);
            this.gbModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuentoEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServicioEditar)).EndInit();
            this.gbAcciones.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoctor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvServiciosFacturar;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label3;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDoctor;
        private System.Windows.Forms.Button btnRefrescarDoctor;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbAcciones;
        public System.Windows.Forms.Button btnEliminarServicio;
        public System.Windows.Forms.Button btnAgregarServicio;
        public System.Windows.Forms.Button btnModificarServicio;
        private System.Windows.Forms.GroupBox gbModificar;
        public System.Windows.Forms.Button btnGuardarEditar;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.NumericUpDown nudCantidadEditar;
        private System.Windows.Forms.Label label13;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbServicioEditar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSalirEditar;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox txtNumVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintVenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVentas_Temp;
        public System.Windows.Forms.TextBox txtRegistros;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnEliminarFactura;
        public System.Windows.Forms.Button btnModificarCliente;
        public System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label36;
        public System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Label label37;
        public System.Windows.Forms.NumericUpDown nudDescuentoEditar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer tBuscar;
        public System.Windows.Forms.Timer tEnfoque;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer tCargarServicios;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label38;
        public System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblF11Title;
        private System.Windows.Forms.Label lblF11;
    }
}