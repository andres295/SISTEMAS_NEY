namespace SCM.CxC
{
    partial class frmCuentasPorCobrar_NC_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentasPorCobrar_NC_Productos));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tBuscar = new System.Windows.Forms.Timer(this.components);
            this.pCantidades = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(76, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(443, 22);
            this.txtBuscar.TabIndex = 33;
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
            this.lblBuscar.Location = new System.Drawing.Point(9, 19);
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
            this.dgvProductos.Location = new System.Drawing.Point(12, 49);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(860, 300);
            this.dgvProductos.TabIndex = 34;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
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
            this.pCantidades.Controls.Add(this.label1);
            this.pCantidades.Controls.Add(this.label3);
            this.pCantidades.Controls.Add(this.label2);
            this.pCantidades.Controls.Add(this.nudCantidad);
            this.pCantidades.Enabled = false;
            this.pCantidades.Location = new System.Drawing.Point(525, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(347, 28);
            this.pCantidades.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 28);
            this.label1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(87, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 34;
            this.label2.Text = "CANTIDAD:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad.Location = new System.Drawing.Point(108, 4);
            this.nudCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(61, 22);
            this.nudCantidad.TabIndex = 32;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad.Enter += new System.EventHandler(this.nudCantidad_Enter);
            this.nudCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad_KeyDown);
            this.nudCantidad.Leave += new System.EventHandler(this.nudCantidad_Leave);
            // 
            // frmCuentasPorCobrar_NC_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.pCantidades);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCuentasPorCobrar_NC_Productos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR PRODUCTOS";
            this.Load += new System.EventHandler(this.frmCuentasPorCobrar_NC_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ToolTip ttMensaje;
    }
}