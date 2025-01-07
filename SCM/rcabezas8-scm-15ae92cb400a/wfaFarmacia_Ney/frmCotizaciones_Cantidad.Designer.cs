namespace SCM
{
    partial class frmCotizaciones_Cantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotizaciones_Cantidad));
            this.pCantidades = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudFracciones = new System.Windows.Forms.NumericUpDown();
            this.nudCantidad2 = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidad1 = new System.Windows.Forms.Label();
            this.nudCantidad1 = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.pCantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).BeginInit();
            this.SuspendLayout();
            // 
            // pCantidades
            // 
            this.pCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pCantidades.Controls.Add(this.label7);
            this.pCantidades.Controls.Add(this.label1);
            this.pCantidades.Controls.Add(this.label6);
            this.pCantidades.Controls.Add(this.nudFracciones);
            this.pCantidades.Controls.Add(this.nudCantidad2);
            this.pCantidades.Controls.Add(this.lblCantidad2);
            this.pCantidades.Controls.Add(this.label3);
            this.pCantidades.Controls.Add(this.lblCantidad1);
            this.pCantidades.Controls.Add(this.nudCantidad1);
            this.pCantidades.Location = new System.Drawing.Point(15, 12);
            this.pCantidades.Name = "pCantidades";
            this.pCantidades.Size = new System.Drawing.Size(400, 33);
            this.pCantidades.TabIndex = 18;
            this.pCantidades.TabStop = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(321, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 14);
            this.label7.TabIndex = 43;
            this.label7.Text = "F";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(160, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 28);
            this.label1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(242, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 14);
            this.label6.TabIndex = 41;
            this.label6.Text = "*";
            // 
            // nudFracciones
            // 
            this.nudFracciones.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudFracciones.Location = new System.Drawing.Point(337, 5);
            this.nudFracciones.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudFracciones.Name = "nudFracciones";
            this.nudFracciones.Size = new System.Drawing.Size(61, 22);
            this.nudFracciones.TabIndex = 2;
            this.nudFracciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFracciones.Enter += new System.EventHandler(this.nudFracciones_Enter);
            this.nudFracciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudFracciones_KeyDown);
            this.nudFracciones.Leave += new System.EventHandler(this.nudFracciones_Leave);
            // 
            // nudCantidad2
            // 
            this.nudCantidad2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad2.Location = new System.Drawing.Point(257, 5);
            this.nudCantidad2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidad2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad2.Name = "nudCantidad2";
            this.nudCantidad2.Size = new System.Drawing.Size(61, 22);
            this.nudCantidad2.TabIndex = 1;
            this.nudCantidad2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad2.Enter += new System.EventHandler(this.nudCantidad2_Enter);
            this.nudCantidad2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad2_KeyDown);
            this.nudCantidad2.Leave += new System.EventHandler(this.nudCantidad2_Leave);
            // 
            // lblCantidad2
            // 
            this.lblCantidad2.AutoSize = true;
            this.lblCantidad2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad2.Location = new System.Drawing.Point(167, 8);
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
            this.label3.Location = new System.Drawing.Point(75, 10);
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
            this.lblCantidad1.Location = new System.Drawing.Point(0, 8);
            this.lblCantidad1.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad1.Name = "lblCantidad1";
            this.lblCantidad1.Size = new System.Drawing.Size(75, 14);
            this.lblCantidad1.TabIndex = 34;
            this.lblCantidad1.Text = "CANTIDAD:";
            // 
            // nudCantidad1
            // 
            this.nudCantidad1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.nudCantidad1.Location = new System.Drawing.Point(90, 6);
            this.nudCantidad1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nudCantidad1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad1.Name = "nudCantidad1";
            this.nudCantidad1.Size = new System.Drawing.Size(61, 22);
            this.nudCantidad1.TabIndex = 0;
            this.nudCantidad1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantidad1.Enter += new System.EventHandler(this.nudCantidad1_Enter);
            this.nudCantidad1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad1_KeyDown);
            this.nudCantidad1.Leave += new System.EventHandler(this.nudCantidad1_Leave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(218, 67);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(318, 67);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(405, 1);
            this.label5.TabIndex = 19;
            // 
            // frmCotizaciones_Cantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(429, 113);
            this.Controls.Add(this.pCantidades);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCotizaciones_Cantidad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFICAR CANTIDAD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCotizaciones_Cantidad_FormClosing);
            this.Load += new System.EventHandler(this.frmCotizaciones_Cantidad_Load);
            this.pCantidades.ResumeLayout(false);
            this.pCantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFracciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pCantidades;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown nudFracciones;
        public System.Windows.Forms.NumericUpDown nudCantidad2;
        public System.Windows.Forms.Label lblCantidad2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCantidad1;
        public System.Windows.Forms.NumericUpDown nudCantidad1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttMensaje;
    }
}