namespace SCM
{
    partial class frmProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRegistros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tEnfoque = new System.Windows.Forms.Timer(this.components);
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pPaginacion = new System.Windows.Forms.Panel();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.brnAnterior = new System.Windows.Forms.Button();
            this.btnPrimera = new System.Windows.Forms.Button();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cbEliminados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pPaginacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRegistros
            // 
            this.txtRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRegistros.Enabled = false;
            this.txtRegistros.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRegistros.Location = new System.Drawing.Point(1047, 18);
            this.txtRegistros.Name = "txtRegistros";
            this.txtRegistros.Size = new System.Drawing.Size(84, 22);
            this.txtRegistros.TabIndex = 16;
            this.txtRegistros.TabStop = false;
            this.txtRegistros.Text = "0";
            this.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(1037, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 22);
            this.label3.TabIndex = 15;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(394, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(531, 22);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            this.txtBuscar.MouseLeave += new System.EventHandler(this.txtBuscar_MouseLeave);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Location = new System.Drawing.Point(327, 22);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 14;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(319, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 34);
            this.label1.TabIndex = 12;
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
            this.btnEliminar.TabIndex = 13;
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
            this.btnModificar.TabIndex = 11;
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
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "&AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAgregar_KeyDown);
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 52);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(1119, 498);
            this.dgvProductos.TabIndex = 17;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // tEnfoque
            // 
            this.tEnfoque.Enabled = true;
            this.tEnfoque.Tick += new System.EventHandler(this.tEnfoque_Tick);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 500;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
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
            this.pPaginacion.Location = new System.Drawing.Point(0, 556);
            this.pPaginacion.Name = "pPaginacion";
            this.pPaginacion.Size = new System.Drawing.Size(1142, 45);
            this.pPaginacion.TabIndex = 18;
            this.pPaginacion.Visible = false;
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaginas.Location = new System.Drawing.Point(477, 12);
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
            this.btnUltima.Location = new System.Drawing.Point(697, 3);
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
            this.btnSiguiente.Location = new System.Drawing.Point(659, 3);
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
            this.brnAnterior.Location = new System.Drawing.Point(439, 3);
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
            this.btnPrimera.Location = new System.Drawing.Point(401, 3);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(32, 32);
            this.btnPrimera.TabIndex = 0;
            this.btnPrimera.TabStop = false;
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.cbEliminados);
            this.ultraGroupBox1.Controls.Add(this.btnAgregar);
            this.ultraGroupBox1.Controls.Add(this.btnModificar);
            this.ultraGroupBox1.Controls.Add(this.dgvProductos);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtRegistros);
            this.ultraGroupBox1.Controls.Add(this.btnEliminar);
            this.ultraGroupBox1.Controls.Add(this.lblBuscar);
            this.ultraGroupBox1.Controls.Add(this.txtBuscar);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1142, 556);
            this.ultraGroupBox1.TabIndex = 19;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // cbEliminados
            // 
            this.cbEliminados.AutoSize = true;
            this.cbEliminados.ForeColor = System.Drawing.Color.Navy;
            this.cbEliminados.Location = new System.Drawing.Point(928, 22);
            this.cbEliminados.Name = "cbEliminados";
            this.cbEliminados.Size = new System.Drawing.Size(115, 18);
            this.cbEliminados.TabIndex = 18;
            this.cbEliminados.Text = "Los Eliminados";
            this.cbEliminados.UseVisualStyleBackColor = true;
            this.cbEliminados.CheckedChanged += new System.EventHandler(this.cbEliminados_CheckedChanged);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.pPaginacion);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCTOS";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pPaginacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtRegistros;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.Timer tEnfoque;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Panel pPaginacion;
        private System.Windows.Forms.Label lblTotalPaginas;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button brnAnterior;
        private System.Windows.Forms.Button btnPrimera;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.CheckBox cbEliminados;
    }
}