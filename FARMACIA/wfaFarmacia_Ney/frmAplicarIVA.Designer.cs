namespace wfaFarmacia_Ney
{
    partial class frmAplicarIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAplicarIVA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gbDescuento = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnSel = new System.Windows.Forms.RadioButton();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.tCargarProd = new System.Windows.Forms.Timer(this.components);
            this.gbIva = new System.Windows.Forms.GroupBox();
            this.rbtnTodosPVP = new System.Windows.Forms.RadioButton();
            this.rbtnSelPVP = new System.Windows.Forms.RadioButton();
            this.btnQuitarIvaPVP = new System.Windows.Forms.Button();
            this.btnGuardarIvaPVP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.gbIva.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
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
            this.btnQuitar.Location = new System.Drawing.Point(79, 65);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(79, 34);
            this.btnQuitar.TabIndex = 31;
            this.btnQuitar.TabStop = false;
            this.btnQuitar.Text = "&QUITAR";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(13, 351);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.Size = new System.Drawing.Size(1118, 238);
            this.dgvProductos.TabIndex = 17;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.dgvProductos.Click += new System.EventHandler(this.dgvProductos_Click);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(77, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(714, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(10, 15);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 16;
            this.lblBuscar.Text = "BUSCAR:";
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
            this.btnGuardar.Location = new System.Drawing.Point(164, 65);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(87, 34);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&APLICAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(11, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(310, 1);
            this.label9.TabIndex = 24;
            // 
            // gbDescuento
            // 
            this.gbDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescuento.Controls.Add(this.rbtnTodos);
            this.gbDescuento.Controls.Add(this.rbtnSel);
            this.gbDescuento.Controls.Add(this.btnQuitar);
            this.gbDescuento.Controls.Add(this.btnGuardar);
            this.gbDescuento.Controls.Add(this.label9);
            this.gbDescuento.Enabled = false;
            this.gbDescuento.ForeColor = System.Drawing.Color.Black;
            this.gbDescuento.Location = new System.Drawing.Point(797, 12);
            this.gbDescuento.Name = "gbDescuento";
            this.gbDescuento.Size = new System.Drawing.Size(333, 112);
            this.gbDescuento.TabIndex = 18;
            this.gbDescuento.TabStop = false;
            this.gbDescuento.Text = "IVA";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ForeColor = System.Drawing.Color.Blue;
            this.rbtnTodos.Location = new System.Drawing.Point(146, 21);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(178, 18);
            this.rbtnTodos.TabIndex = 33;
            this.rbtnTodos.Text = "TODOS LOS PRODUCTOS.";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            // 
            // rbtnSel
            // 
            this.rbtnSel.AutoSize = true;
            this.rbtnSel.Checked = true;
            this.rbtnSel.ForeColor = System.Drawing.Color.Blue;
            this.rbtnSel.Location = new System.Drawing.Point(14, 21);
            this.rbtnSel.Name = "rbtnSel";
            this.rbtnSel.Size = new System.Drawing.Size(126, 18);
            this.rbtnSel.TabIndex = 32;
            this.rbtnSel.TabStop = true;
            this.rbtnSel.Text = "POR PRODUCTO.";
            this.rbtnSel.UseVisualStyleBackColor = true;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(13, 40);
            this.dgvProveedores.Name = "dgvProveedores";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProveedores.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProveedores.Size = new System.Drawing.Size(778, 263);
            this.dgvProveedores.TabIndex = 15;
            this.dgvProveedores.TabStop = false;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            this.dgvProveedores.Enter += new System.EventHandler(this.dgvProveedores_Enter);
            this.dgvProveedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProveedores_KeyDown);
            // 
            // btnGeneral
            // 
            this.btnGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneral.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGeneral.FlatAppearance.BorderSize = 0;
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGeneral.ForeColor = System.Drawing.Color.White;
            this.btnGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneral.Image")));
            this.btnGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneral.Location = new System.Drawing.Point(925, 269);
            this.btnGeneral.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(91, 34);
            this.btnGeneral.TabIndex = 36;
            this.btnGeneral.TabStop = false;
            this.btnGeneral.Text = "&GENERAL";
            this.btnGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneral.UseVisualStyleBackColor = false;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // tCargarProd
            // 
            this.tCargarProd.Interval = 500;
            this.tCargarProd.Tick += new System.EventHandler(this.tCargarProd_Tick);
            // 
            // gbIva
            // 
            this.gbIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIva.Controls.Add(this.rbtnTodosPVP);
            this.gbIva.Controls.Add(this.rbtnSelPVP);
            this.gbIva.Controls.Add(this.btnQuitarIvaPVP);
            this.gbIva.Controls.Add(this.btnGuardarIvaPVP);
            this.gbIva.Controls.Add(this.label1);
            this.gbIva.Enabled = false;
            this.gbIva.ForeColor = System.Drawing.Color.Black;
            this.gbIva.Location = new System.Drawing.Point(798, 139);
            this.gbIva.Name = "gbIva";
            this.gbIva.Size = new System.Drawing.Size(333, 112);
            this.gbIva.TabIndex = 37;
            this.gbIva.TabStop = false;
            this.gbIva.Text = "PVP INCLUYE IVA";
            // 
            // rbtnTodosPVP
            // 
            this.rbtnTodosPVP.AutoSize = true;
            this.rbtnTodosPVP.ForeColor = System.Drawing.Color.Blue;
            this.rbtnTodosPVP.Location = new System.Drawing.Point(146, 21);
            this.rbtnTodosPVP.Name = "rbtnTodosPVP";
            this.rbtnTodosPVP.Size = new System.Drawing.Size(178, 18);
            this.rbtnTodosPVP.TabIndex = 33;
            this.rbtnTodosPVP.Text = "TODOS LOS PRODUCTOS.";
            this.rbtnTodosPVP.UseVisualStyleBackColor = true;
            // 
            // rbtnSelPVP
            // 
            this.rbtnSelPVP.AutoSize = true;
            this.rbtnSelPVP.Checked = true;
            this.rbtnSelPVP.ForeColor = System.Drawing.Color.Blue;
            this.rbtnSelPVP.Location = new System.Drawing.Point(14, 21);
            this.rbtnSelPVP.Name = "rbtnSelPVP";
            this.rbtnSelPVP.Size = new System.Drawing.Size(126, 18);
            this.rbtnSelPVP.TabIndex = 32;
            this.rbtnSelPVP.TabStop = true;
            this.rbtnSelPVP.Text = "POR PRODUCTO.";
            this.rbtnSelPVP.UseVisualStyleBackColor = true;
            // 
            // btnQuitarIvaPVP
            // 
            this.btnQuitarIvaPVP.BackColor = System.Drawing.Color.Red;
            this.btnQuitarIvaPVP.Enabled = false;
            this.btnQuitarIvaPVP.FlatAppearance.BorderSize = 0;
            this.btnQuitarIvaPVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarIvaPVP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarIvaPVP.ForeColor = System.Drawing.Color.White;
            this.btnQuitarIvaPVP.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarIvaPVP.Image")));
            this.btnQuitarIvaPVP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarIvaPVP.Location = new System.Drawing.Point(79, 65);
            this.btnQuitarIvaPVP.Name = "btnQuitarIvaPVP";
            this.btnQuitarIvaPVP.Size = new System.Drawing.Size(79, 34);
            this.btnQuitarIvaPVP.TabIndex = 31;
            this.btnQuitarIvaPVP.TabStop = false;
            this.btnQuitarIvaPVP.Text = "&QUITAR";
            this.btnQuitarIvaPVP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarIvaPVP.UseVisualStyleBackColor = false;
            this.btnQuitarIvaPVP.Click += new System.EventHandler(this.btnQuitarIvaPVP_Click);
            // 
            // btnGuardarIvaPVP
            // 
            this.btnGuardarIvaPVP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardarIvaPVP.FlatAppearance.BorderSize = 0;
            this.btnGuardarIvaPVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarIvaPVP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarIvaPVP.ForeColor = System.Drawing.Color.White;
            this.btnGuardarIvaPVP.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarIvaPVP.Image")));
            this.btnGuardarIvaPVP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarIvaPVP.Location = new System.Drawing.Point(164, 65);
            this.btnGuardarIvaPVP.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardarIvaPVP.Name = "btnGuardarIvaPVP";
            this.btnGuardarIvaPVP.Size = new System.Drawing.Size(87, 34);
            this.btnGuardarIvaPVP.TabIndex = 26;
            this.btnGuardarIvaPVP.TabStop = false;
            this.btnGuardarIvaPVP.Text = "&APLICAR";
            this.btnGuardarIvaPVP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarIvaPVP.UseVisualStyleBackColor = false;
            this.btnGuardarIvaPVP.Click += new System.EventHandler(this.btnGuardarIvaPVP_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 1);
            this.label1.TabIndex = 24;
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscarProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarProducto.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscarProducto.Location = new System.Drawing.Point(77, 323);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(714, 22);
            this.txtBuscarProducto.TabIndex = 38;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            this.txtBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProducto_KeyDown);
            this.txtBuscarProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProducto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 326);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "BUSCAR:";
            // 
            // frmAplicarIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbIva);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gbDescuento);
            this.Controls.Add(this.dgvProveedores);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAplicarIVA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APLICAR/QUITAR EL IVA A LOS PRODUCTOS";
            this.Load += new System.EventHandler(this.frmAplicarIVA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbDescuento.ResumeLayout(false);
            this.gbDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.gbIva.ResumeLayout(false);
            this.gbIva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.Button btnQuitar;
        public System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbDescuento;
        public System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnSel;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Timer tCargarProd;
        private System.Windows.Forms.GroupBox gbIva;
        private System.Windows.Forms.RadioButton rbtnTodosPVP;
        private System.Windows.Forms.RadioButton rbtnSelPVP;
        private System.Windows.Forms.Button btnQuitarIvaPVP;
        private System.Windows.Forms.Button btnGuardarIvaPVP;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label4;
    }
}