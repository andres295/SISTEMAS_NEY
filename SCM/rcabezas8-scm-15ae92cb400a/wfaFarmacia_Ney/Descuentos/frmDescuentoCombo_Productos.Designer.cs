namespace SCM.Descuentos
{
    partial class frmDescuentoCombo_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescuentoCombo_Productos));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pPaginacion = new System.Windows.Forms.Panel();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.brnAnterior = new System.Windows.Forms.Button();
            this.btnPrimera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pPaginacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(78, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(671, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            this.txtBuscar.MouseLeave += new System.EventHandler(this.txtBuscar_MouseLeave);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(11, 19);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 35;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(14, 49);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(735, 468);
            this.dgvProductos.TabIndex = 34;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.DoubleClick += new System.EventHandler(this.dgvProductos_DoubleClick);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
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
            this.pPaginacion.Location = new System.Drawing.Point(0, 523);
            this.pPaginacion.Name = "pPaginacion";
            this.pPaginacion.Size = new System.Drawing.Size(759, 45);
            this.pPaginacion.TabIndex = 37;
            this.pPaginacion.Visible = false;
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaginas.Location = new System.Drawing.Point(285, 12);
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
            this.btnUltima.Location = new System.Drawing.Point(505, 3);
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
            this.btnSiguiente.Location = new System.Drawing.Point(467, 3);
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
            this.brnAnterior.Location = new System.Drawing.Point(247, 3);
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
            this.btnPrimera.Location = new System.Drawing.Point(209, 3);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(32, 32);
            this.btnPrimera.TabIndex = 0;
            this.btnPrimera.TabStop = false;
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // frmDescuentoCombo_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 568);
            this.Controls.Add(this.pPaginacion);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDescuentoCombo_Productos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR PRODUCTOS A COMBO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDescuentoCombo_Productos_FormClosing);
            this.Load += new System.EventHandler(this.frmDescuentoCombo_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pPaginacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Panel pPaginacion;
        private System.Windows.Forms.Label lblTotalPaginas;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button brnAnterior;
        private System.Windows.Forms.Button btnPrimera;
    }
}