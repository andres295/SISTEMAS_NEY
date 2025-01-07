namespace SCM
{
    partial class frmRecuperar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecuperar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.txtRegistros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblSubTotalSI = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblIVA_Texto = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblSubtotal_DP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSubtotal_CP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pbOpciones = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminarProd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pPaginacion = new System.Windows.Forms.Panel();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.brnAnterior = new System.Windows.Forms.Button();
            this.btnPrimera = new System.Windows.Forms.Button();
            this.btnModificarProd = new System.Windows.Forms.Button();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tCargarProd = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iMPRIMIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVentas_Temp = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tInicio = new System.Windows.Forms.Timer(this.components);
            this.btnPrintVenta = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpciones)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // txtRegistros
            // 
            this.txtRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRegistros.Enabled = false;
            this.txtRegistros.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRegistros.Location = new System.Drawing.Point(1046, 19);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(84, 22);
            this.txtRegistros.TabIndex = 45;
            this.txtRegistros.TabStop = false;
            this.txtRegistros.Text = "0";
            this.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(1036, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 22);
            this.label3.TabIndex = 44;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(429, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(598, 22);
            this.txtBuscar.TabIndex = 38;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            this.txtBuscar.MouseLeave += new System.EventHandler(this.txtBuscar_MouseLeave);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(363, 22);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(60, 14);
            this.lblBuscar.TabIndex = 43;
            this.lblBuscar.Text = "CLIENTE:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(355, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 34);
            this.label1.TabIndex = 41;
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
            this.btnEliminar.Location = new System.Drawing.Point(123, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(93, 34);
            this.btnEliminar.TabIndex = 42;
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
            this.btnModificar.Location = new System.Drawing.Point(15, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 34);
            this.btnModificar.TabIndex = 40;
            this.btnModificar.TabStop = false;
            this.btnModificar.Text = "&MODIFICAR";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
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
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(1112, 183);
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
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1112, 80);
            this.panel4.TabIndex = 35;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.95324F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.26978F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.10072F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1112, 80);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.lblSubTotalSI);
            this.panel6.Controls.Add(this.label35);
            this.panel6.Controls.Add(this.lblIVA);
            this.panel6.Controls.Add(this.lblIVA_Texto);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(568, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(541, 74);
            this.panel6.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.lblTotalPagar);
            this.panel9.Location = new System.Drawing.Point(365, 1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(173, 73);
            this.panel9.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(1, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "TOTAL A PAGAR:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotalPagar.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Location = new System.Drawing.Point(26, 25);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(142, 41);
            this.lblTotalPagar.TabIndex = 29;
            this.lblTotalPagar.Text = "9999.99";
            // 
            // lblSubTotalSI
            // 
            this.lblSubTotalSI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubTotalSI.AutoSize = true;
            this.lblSubTotalSI.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalSI.ForeColor = System.Drawing.Color.Teal;
            this.lblSubTotalSI.Location = new System.Drawing.Point(271, 13);
            this.lblSubTotalSI.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubTotalSI.Name = "lblSubTotalSI";
            this.lblSubTotalSI.Size = new System.Drawing.Size(88, 23);
            this.lblSubTotalSI.TabIndex = 31;
            this.lblSubTotalSI.Text = "9999.99";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(0, 11);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(276, 23);
            this.label35.TabIndex = 30;
            this.label35.Text = "SUBTOTAL SIN IMPUESTO :";
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblIVA.Location = new System.Drawing.Point(266, 40);
            this.lblIVA.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(96, 27);
            this.lblIVA.TabIndex = 27;
            this.lblIVA.Text = "9999.99";
            // 
            // lblIVA_Texto
            // 
            this.lblIVA_Texto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIVA_Texto.AutoSize = true;
            this.lblIVA_Texto.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA_Texto.Location = new System.Drawing.Point(0, 42);
            this.lblIVA_Texto.Margin = new System.Windows.Forms.Padding(0);
            this.lblIVA_Texto.Name = "lblIVA_Texto";
            this.lblIVA_Texto.Size = new System.Drawing.Size(153, 23);
            this.lblIVA_Texto.TabIndex = 22;
            this.lblIVA_Texto.Text = "IVA (00,00%):";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblSubtotal_DP);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.lblSubtotal_CP);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(287, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(275, 74);
            this.panel8.TabIndex = 1;
            // 
            // lblSubtotal_DP
            // 
            this.lblSubtotal_DP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtotal_DP.AutoSize = true;
            this.lblSubtotal_DP.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal_DP.ForeColor = System.Drawing.Color.Maroon;
            this.lblSubtotal_DP.Location = new System.Drawing.Point(177, 38);
            this.lblSubtotal_DP.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubtotal_DP.Name = "lblSubtotal_DP";
            this.lblSubtotal_DP.Size = new System.Drawing.Size(96, 27);
            this.lblSubtotal_DP.TabIndex = 29;
            this.lblSubtotal_DP.Text = "9999.99";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(274, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1, 74);
            this.label13.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(3, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "SUBTOTAL 0% :";
            // 
            // lblSubtotal_CP
            // 
            this.lblSubtotal_CP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtotal_CP.AutoSize = true;
            this.lblSubtotal_CP.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal_CP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSubtotal_CP.Location = new System.Drawing.Point(177, 11);
            this.lblSubtotal_CP.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubtotal_CP.Name = "lblSubtotal_CP";
            this.lblSubtotal_CP.Size = new System.Drawing.Size(96, 27);
            this.lblSubtotal_CP.TabIndex = 30;
            this.lblSubtotal_CP.Text = "9999.99";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 23);
            this.label10.TabIndex = 26;
            this.label10.Text = "SUBTOTAL 12% :";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblSubtotal);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.lblDescuento);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(54, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(227, 74);
            this.panel7.TabIndex = 0;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblSubtotal.Location = new System.Drawing.Point(131, 11);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(96, 27);
            this.lblSubtotal.TabIndex = 26;
            this.lblSubtotal.Text = "9999.99";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 74);
            this.label6.TabIndex = 25;
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.Red;
            this.lblDescuento.Location = new System.Drawing.Point(131, 39);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(96, 27);
            this.lblDescuento.TabIndex = 28;
            this.lblDescuento.Text = "9999.99";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(226, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 74);
            this.label5.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(-2, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "DESCUENTO:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "SUBTOTAL:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pbOpciones);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(45, 74);
            this.panel5.TabIndex = 2;
            // 
            // pbOpciones
            // 
            this.pbOpciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOpciones.Image = ((System.Drawing.Image)(resources.GetObject("pbOpciones.Image")));
            this.pbOpciones.Location = new System.Drawing.Point(0, 21);
            this.pbOpciones.Name = "pbOpciones";
            this.pbOpciones.Size = new System.Drawing.Size(44, 32);
            this.pbOpciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOpciones.TabIndex = 11;
            this.pbOpciones.TabStop = false;
            this.pbOpciones.Click += new System.EventHandler(this.pbOpciones_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(1062, 163);
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
            this.btnEliminarProd.Location = new System.Drawing.Point(1062, 110);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(47, 47);
            this.btnEliminarProd.TabIndex = 23;
            this.btnEliminarProd.TabStop = false;
            this.btnEliminarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarProd.UseVisualStyleBackColor = false;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
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
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pPaginacion);
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
            // pPaginacion
            // 
            this.pPaginacion.Controls.Add(this.lblTotalPaginas);
            this.pPaginacion.Controls.Add(this.btnUltima);
            this.pPaginacion.Controls.Add(this.btnSiguiente);
            this.pPaginacion.Controls.Add(this.brnAnterior);
            this.pPaginacion.Controls.Add(this.btnPrimera);
            this.pPaginacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pPaginacion.Enabled = false;
            this.pPaginacion.Location = new System.Drawing.Point(0, 217);
            this.pPaginacion.Name = "pPaginacion";
            this.pPaginacion.Size = new System.Drawing.Size(1112, 45);
            this.pPaginacion.TabIndex = 26;
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaginas.Location = new System.Drawing.Point(462, 12);
            this.lblTotalPaginas.Name = "lblTotalPaginas";
            this.lblTotalPaginas.Size = new System.Drawing.Size(176, 14);
            this.lblTotalPaginas.TabIndex = 20;
            this.lblTotalPaginas.Text = "PAGINA 0 DE 0";
            this.lblTotalPaginas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUltima
            // 
            this.btnUltima.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUltima.FlatAppearance.BorderSize = 0;
            this.btnUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltima.Image = ((System.Drawing.Image)(resources.GetObject("btnUltima.Image")));
            this.btnUltima.Location = new System.Drawing.Point(682, 3);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(32, 32);
            this.btnUltima.TabIndex = 3;
            this.btnUltima.TabStop = false;
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.Location = new System.Drawing.Point(644, 3);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(32, 32);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.TabStop = false;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // brnAnterior
            // 
            this.brnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.brnAnterior.Enabled = false;
            this.brnAnterior.FlatAppearance.BorderSize = 0;
            this.brnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("brnAnterior.Image")));
            this.brnAnterior.Location = new System.Drawing.Point(424, 3);
            this.brnAnterior.Name = "brnAnterior";
            this.brnAnterior.Size = new System.Drawing.Size(32, 32);
            this.brnAnterior.TabIndex = 1;
            this.brnAnterior.TabStop = false;
            this.brnAnterior.UseVisualStyleBackColor = true;
            this.brnAnterior.Click += new System.EventHandler(this.brnAnterior_Click);
            // 
            // btnPrimera
            // 
            this.btnPrimera.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrimera.Enabled = false;
            this.btnPrimera.FlatAppearance.BorderSize = 0;
            this.btnPrimera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimera.Image = ((System.Drawing.Image)(resources.GetObject("btnPrimera.Image")));
            this.btnPrimera.Location = new System.Drawing.Point(386, 3);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(32, 32);
            this.btnPrimera.TabIndex = 0;
            this.btnPrimera.TabStop = false;
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
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
            this.btnModificarProd.Location = new System.Drawing.Point(1062, 57);
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
            this.btnAgregarProd.Location = new System.Drawing.Point(1062, 4);
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
            this.dgvFacturas.Size = new System.Drawing.Size(1056, 214);
            this.dgvFacturas.TabIndex = 20;
            this.dgvFacturas.TabStop = false;
            this.dgvFacturas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFacturas_CellFormatting);
            this.dgvFacturas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_RowEnter);
            this.dgvFacturas.Enter += new System.EventHandler(this.dgvFacturas_Enter);
            this.dgvFacturas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFacturas_KeyDown);
            this.dgvFacturas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFacturas_KeyPress);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
            // 
            // tCargarProd
            // 
            this.tCargarProd.Interval = 200;
            this.tCargarProd.Tick += new System.EventHandler(this.tCargarProd_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iMPRIMIRToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 26);
            // 
            // iMPRIMIRToolStripMenuItem
            // 
            this.iMPRIMIRToolStripMenuItem.Name = "iMPRIMIRToolStripMenuItem";
            this.iMPRIMIRToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.iMPRIMIRToolStripMenuItem.Text = "REPORTE (CTRL + R)";
            this.iMPRIMIRToolStripMenuItem.Click += new System.EventHandler(this.iMPRIMIRToolStripMenuItem_Click);
            // 
            // btnVentas_Temp
            // 
            this.btnVentas_Temp.BackColor = System.Drawing.Color.DarkOrange;
            this.btnVentas_Temp.FlatAppearance.BorderSize = 0;
            this.btnVentas_Temp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas_Temp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnVentas_Temp.ForeColor = System.Drawing.Color.White;
            this.btnVentas_Temp.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas_Temp.Image")));
            this.btnVentas_Temp.Location = new System.Drawing.Point(274, 12);
            this.btnVentas_Temp.Name = "btnVentas_Temp";
            this.btnVentas_Temp.Size = new System.Drawing.Size(33, 34);
            this.btnVentas_Temp.TabIndex = 41;
            this.btnVentas_Temp.TabStop = false;
            this.btnVentas_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas_Temp.UseVisualStyleBackColor = false;
            this.btnVentas_Temp.Click += new System.EventHandler(this.btnVentas_Temp_Click);
            this.btnVentas_Temp.MouseEnter += new System.EventHandler(this.btnVentas_Temp_MouseEnter);
            this.btnVentas_Temp.MouseLeave += new System.EventHandler(this.btnVentas_Temp_MouseLeave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(235, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(33, 34);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(225, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 34);
            this.label4.TabIndex = 42;
            // 
            // tInicio
            // 
            this.tInicio.Enabled = true;
            this.tInicio.Tick += new System.EventHandler(this.tInicio_Tick);
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
            this.btnPrintVenta.Location = new System.Drawing.Point(313, 12);
            this.btnPrintVenta.Name = "btnPrintVenta";
            this.btnPrintVenta.Size = new System.Drawing.Size(33, 34);
            this.btnPrintVenta.TabIndex = 93;
            this.btnPrintVenta.TabStop = false;
            this.btnPrintVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintVenta.UseVisualStyleBackColor = false;
            this.btnPrintVenta.Click += new System.EventHandler(this.btnPrintVenta_Click);
            // 
            // frmRecuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.btnPrintVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVentas_Temp);
            this.Controls.Add(this.txtRegistros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecuperar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECUPERAR LOS PRODUCTOS DE UNA VENTA";
            this.Load += new System.EventHandler(this.frmRecuperar_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpciones)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pPaginacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer tEnfoque;
        public System.Windows.Forms.TextBox txtRegistros;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnEliminarProd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnModificarProd;
        public System.Windows.Forms.Button btnAgregarProd;
        public System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.Timer tCargarProd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pbOpciones;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRToolStripMenuItem;
        private System.Windows.Forms.Button btnVentas_Temp;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblIVA;
        public System.Windows.Forms.Label lblSubtotal;
        public System.Windows.Forms.Label lblTotalPagar;
        public System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Panel pPaginacion;
        private System.Windows.Forms.Label lblTotalPaginas;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button brnAnterior;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.Timer tInicio;
        public System.Windows.Forms.Label lblIVA_Texto;
        private System.Windows.Forms.Button btnPrintVenta;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Label lblSubtotal_DP;

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblSubtotal_CP;
        public System.Windows.Forms.Label lblSubTotalSI;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Panel panel9;
    }
}