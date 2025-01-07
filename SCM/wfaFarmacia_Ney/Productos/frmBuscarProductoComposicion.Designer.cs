namespace SCM.Productos
{
    partial class frmBuscarProductoComposicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarProductoComposicion));
            this.pCantidades = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.cblComposicionQuimica = new System.Windows.Forms.CheckedListBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pCantidades
            // 
            this.pCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCantidades.Controls.Add(this.btnLimpiar);
            this.pCantidades.Controls.Add(this.txtBuscar);
            this.pCantidades.Controls.Add(this.lblBuscar);
            this.pCantidades.Location = new System.Drawing.Point(15, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(329, 48);
            this.pCantidades.TabIndex = 18;
            this.pCantidades.TabStop = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = global::SCM.Properties.Resources.Symbol_Delete_2;
            this.btnLimpiar.Location = new System.Drawing.Point(290, 6);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(33, 34);
            this.btnLimpiar.TabIndex = 101;
            this.btnLimpiar.TabStop = false;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(68, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(217, 22);
            this.txtBuscar.TabIndex = 99;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(9, 16);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(61, 14);
            this.lblBuscar.TabIndex = 100;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(10, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(329, 1);
            this.label5.TabIndex = 19;
            // 
            // cblComposicionQuimica
            // 
            this.cblComposicionQuimica.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblComposicionQuimica.ForeColor = System.Drawing.Color.Navy;
            this.cblComposicionQuimica.FormattingEnabled = true;
            this.cblComposicionQuimica.HorizontalScrollbar = true;
            this.cblComposicionQuimica.Location = new System.Drawing.Point(15, 82);
            this.cblComposicionQuimica.Name = "cblComposicionQuimica";
            this.cblComposicionQuimica.Size = new System.Drawing.Size(329, 260);
            this.cblComposicionQuimica.TabIndex = 97;
            this.cblComposicionQuimica.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblComposicionQuimica_ItemCheck);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(345, 28);
            this.dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Size = new System.Drawing.Size(723, 314);
            this.dgvProductos.TabIndex = 100;
            this.dgvProductos.TabStop = false;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(252, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 14);
            this.label1.TabIndex = 101;
            this.label1.Text = "PRODUCTOS POR COMPOSICIÓN:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImage = global::SCM.Properties.Resources.background;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(345, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 21);
            this.panel1.TabIndex = 102;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BackgroundImage = global::SCM.Properties.Resources.background;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 21);
            this.panel2.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(104, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "COMPOSICIÓN";
            // 
            // frmBuscarProductoComposicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 352);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.cblComposicionQuimica);
            this.Controls.Add(this.pCantidades);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBuscarProductoComposicion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR PRODUCTO POR COMPOSICIÓN QUÍMICA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVentas_Cantidad_FormClosing);
            this.Load += new System.EventHandler(this.frmVentas_Cantidad_Load);
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCantidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttMensaje;
        public System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        public System.Windows.Forms.CheckedListBox cblComposicionQuimica;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnLimpiar;
    }
}