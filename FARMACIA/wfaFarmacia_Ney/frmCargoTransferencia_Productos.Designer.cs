namespace wfaFarmacia_Ney
{
    partial class frmCargoTransferencia_Productos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoTransferencia_Productos));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.pCantidades = new System.Windows.Forms.Panel();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCantidad2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudFracciones = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidad1 = new System.Windows.Forms.Label();
            this.nudCantidad1 = new System.Windows.Forms.NumericUpDown();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pPaginacion = new System.Windows.Forms.Panel();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.brnAnterior = new System.Windows.Forms.Button();
            this.btnPrimera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).BeginInit();
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
            this.txtBuscar.Size = new System.Drawing.Size(272, 22);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Size = new System.Drawing.Size(1118, 501);
            this.dgvProductos.TabIndex = 34;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_RowEnter);
            this.dgvProductos.Enter += new System.EventHandler(this.dgvProductos_Enter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // tBuscar
            // 
            this.tBuscar.Interval = 800;
            this.tBuscar.Tick += new System.EventHandler(this.tBuscar_Tick);
            // 
            // pCantidades
            // 
            this.pCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pCantidades.Controls.Add(this.txtLote);
            this.pCantidades.Controls.Add(this.label2);
            this.pCantidades.Controls.Add(this.label8);
            this.pCantidades.Controls.Add(this.dtpVencimiento);
            this.pCantidades.Controls.Add(this.label6);
            this.pCantidades.Controls.Add(this.label5);
            this.pCantidades.Controls.Add(this.nudCantidad2);
            this.pCantidades.Controls.Add(this.label1);
            this.pCantidades.Controls.Add(this.nudFracciones);
            this.pCantidades.Controls.Add(this.lblCantidad2);
            this.pCantidades.Controls.Add(this.label3);
            this.pCantidades.Controls.Add(this.lblCantidad1);
            this.pCantidades.Controls.Add(this.nudCantidad1);
            this.pCantidades.Enabled = false;
            this.pCantidades.Location = new System.Drawing.Point(356, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(776, 28);
            this.pCantidades.TabIndex = 36;
            // 
            // txtLote
            // 
            this.txtLote.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLote.Location = new System.Drawing.Point(662, 5);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(102, 21);
            this.txtLote.TabIndex = 56;
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLote_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(610, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "LOTE #:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(408, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 14);
            this.label8.TabIndex = 57;
            this.label8.Text = "VENCIMIENTO:";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(505, 5);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(99, 21);
            this.dtpVencimiento.TabIndex = 55;
            this.dtpVencimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpVencimiento_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(242, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 14);
            this.label6.TabIndex = 40;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(321, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 14);
            this.label5.TabIndex = 39;
            this.label5.Text = "F";
            // 
            // nudCantidad2
            // 
            this.nudCantidad2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad2.Location = new System.Drawing.Point(257, 3);
            this.nudCantidad2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidad2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad2.Name = "nudCantidad2";
            this.nudCantidad2.Size = new System.Drawing.Size(61, 22);
            this.nudCantidad2.TabIndex = 2;
            this.nudCantidad2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad2.Enter += new System.EventHandler(this.nudCantidad2_Enter);
            this.nudCantidad2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad2_KeyDown);
            this.nudCantidad2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad2_KeyPress);
            this.nudCantidad2.Leave += new System.EventHandler(this.nudCantidad2_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(160, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 28);
            this.label1.TabIndex = 37;
            // 
            // nudFracciones
            // 
            this.nudFracciones.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudFracciones.Location = new System.Drawing.Point(337, 3);
            this.nudFracciones.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudFracciones.Name = "nudFracciones";
            this.nudFracciones.Size = new System.Drawing.Size(61, 22);
            this.nudFracciones.TabIndex = 3;
            this.nudFracciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFracciones.Enter += new System.EventHandler(this.nudFracciones_Enter);
            this.nudFracciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudFracciones_KeyDown);
            this.nudFracciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudFracciones_KeyPress);
            this.nudFracciones.Leave += new System.EventHandler(this.nudFracciones_Leave);
            // 
            // lblCantidad2
            // 
            this.lblCantidad2.AutoSize = true;
            this.lblCantidad2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad2.Location = new System.Drawing.Point(167, 6);
            this.lblCantidad2.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad2.Name = "lblCantidad2";
            this.lblCantidad2.Size = new System.Drawing.Size(75, 14);
            this.lblCantidad2.TabIndex = 36;
            this.lblCantidad2.Text = "CANTIDAD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(81, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "*";
            // 
            // lblCantidad1
            // 
            this.lblCantidad1.AutoSize = true;
            this.lblCantidad1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad1.Location = new System.Drawing.Point(6, 5);
            this.lblCantidad1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad1.Name = "lblCantidad1";
            this.lblCantidad1.Size = new System.Drawing.Size(75, 14);
            this.lblCantidad1.TabIndex = 34;
            this.lblCantidad1.Text = "CANTIDAD:";
            // 
            // nudCantidad1
            // 
            this.nudCantidad1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad1.Location = new System.Drawing.Point(96, 3);
            this.nudCantidad1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidad1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad1.Name = "nudCantidad1";
            this.nudCantidad1.Size = new System.Drawing.Size(61, 22);
            this.nudCantidad1.TabIndex = 1;
            this.nudCantidad1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad1.Enter += new System.EventHandler(this.nudCantidad1_Enter);
            this.nudCantidad1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad1_KeyDown);
            this.nudCantidad1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad1_KeyPress);
            this.nudCantidad1.Leave += new System.EventHandler(this.nudCantidad1_Leave);
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
            this.pPaginacion.TabIndex = 37;
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
            // frmCargoTransferencia_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.pPaginacion);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.pCantidades);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargoTransferencia_Productos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR PRODUCTOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoTransferencia_Productos_FormClosing);
            this.Load += new System.EventHandler(this.frmCargoTransferencia_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).EndInit();
            this.pPaginacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Timer tBuscar;
        private System.Windows.Forms.Panel pCantidades;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudFracciones;
        private System.Windows.Forms.Label lblCantidad2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidad1;
        public System.Windows.Forms.NumericUpDown nudCantidad1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nudCantidad2;
        private System.Windows.Forms.Panel pPaginacion;
        private System.Windows.Forms.Label lblTotalPaginas;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button brnAnterior;
        private System.Windows.Forms.Button btnPrimera;
        private System.Windows.Forms.TextBox txtLote;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
    }
}