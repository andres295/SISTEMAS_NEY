namespace SCM
{
    partial class frmVentas_Cantidad_Scanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas_Cantidad_Scanner));
            this.pCantidades = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidad1 = new System.Windows.Forms.Label();
            this.nudCantidad1 = new System.Windows.Forms.NumericUpDown();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).BeginInit();
            this.SuspendLayout();
            // 
            // pCantidades
            // 
            this.pCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCantidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pCantidades.Controls.Add(this.label3);
            this.pCantidades.Controls.Add(this.lblCantidad1);
            this.pCantidades.Controls.Add(this.nudCantidad1);
            this.pCantidades.Location = new System.Drawing.Point(15, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(392, 170);
            this.pCantidades.TabIndex = 18;
            this.pCantidades.TabStop = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(313, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 35;
            this.label3.Text = "*";
            // 
            // lblCantidad1
            // 
            this.lblCantidad1.AutoSize = true;
            this.lblCantidad1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad1.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad1.Location = new System.Drawing.Point(76, 22);
            this.lblCantidad1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad1.Name = "lblCantidad1";
            this.lblCantidad1.Size = new System.Drawing.Size(234, 45);
            this.lblCantidad1.TabIndex = 34;
            this.lblCantidad1.Text = "CANTIDAD:";
            // 
            // nudCantidad1
            // 
            this.nudCantidad1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad1.ForeColor = System.Drawing.Color.Navy;
            this.nudCantidad1.Location = new System.Drawing.Point(75, 82);
            this.nudCantidad1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidad1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad1.Name = "nudCantidad1";
            this.nudCantidad1.Size = new System.Drawing.Size(235, 65);
            this.nudCantidad1.TabIndex = 0;
            this.nudCantidad1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad1.ValueChanged += new System.EventHandler(this.nudCantidad1_ValueChanged);
            this.nudCantidad1.Enter += new System.EventHandler(this.nudCantidad1_Enter);
            this.nudCantidad1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad1_KeyDown);
            this.nudCantidad1.Leave += new System.EventHandler(this.nudCantidad1_Leave);
            // 
            // frmVentas_Cantidad_Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(421, 194);
            this.Controls.Add(this.pCantidades);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVentas_Cantidad_Scanner";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFICAR CANTIDAD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVentas_Cantidad_FormClosing);
            this.Load += new System.EventHandler(this.frmVentas_Cantidad_Load);
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCantidades;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCantidad1;
        public System.Windows.Forms.NumericUpDown nudCantidad1;
        private System.Windows.Forms.ToolTip ttMensaje;
    }
}