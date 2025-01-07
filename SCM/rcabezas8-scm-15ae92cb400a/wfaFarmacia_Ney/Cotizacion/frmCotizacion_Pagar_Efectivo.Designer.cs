namespace SCM.Cotizacion
{
    partial class frmCotizacion_Pagar_Efectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotizacion_Pagar_Efectivo));
            this.pEfectivo = new System.Windows.Forms.Panel();
            this.nudEfectivo = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tMostrarImagen = new System.Windows.Forms.Timer(this.components);
            this.tSumar = new System.Windows.Forms.Timer(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEfectivo = new System.Windows.Forms.CheckBox();
            this.pEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEfectivo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pEfectivo
            // 
            this.pEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pEfectivo.Controls.Add(this.nudEfectivo);
            this.pEfectivo.Controls.Add(this.label9);
            this.pEfectivo.Controls.Add(this.label8);
            this.pEfectivo.Enabled = false;
            this.pEfectivo.Location = new System.Drawing.Point(12, 42);
            this.pEfectivo.Name = "pEfectivo";
            this.pEfectivo.Size = new System.Drawing.Size(519, 71);
            this.pEfectivo.TabIndex = 57;
            // 
            // nudEfectivo
            // 
            this.nudEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudEfectivo.DecimalPlaces = 2;
            this.nudEfectivo.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudEfectivo.Location = new System.Drawing.Point(179, 11);
            this.nudEfectivo.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudEfectivo.Name = "nudEfectivo";
            this.nudEfectivo.Size = new System.Drawing.Size(313, 50);
            this.nudEfectivo.TabIndex = 0;
            this.nudEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudEfectivo.ValueChanged += new System.EventHandler(this.nudEfectivo_ValueChanged);
            this.nudEfectivo.Enter += new System.EventHandler(this.nudEfectivo_Enter);
            this.nudEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudEfectivo_KeyDown);
            this.nudEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudEfectivo_KeyPress);
            this.nudEfectivo.Leave += new System.EventHandler(this.nudEfectivo_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(495, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 14);
            this.label9.TabIndex = 59;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 42);
            this.label8.TabIndex = 58;
            this.label8.Text = "MONTO:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagar.BackColor = System.Drawing.Color.Green;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(326, 308);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(93, 34);
            this.btnPagar.TabIndex = 68;
            this.btnPagar.TabStop = false;
            this.btnPagar.Text = "&PAGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(434, 308);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Location = new System.Drawing.Point(12, 221);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(519, 1);
            this.label10.TabIndex = 66;
            // 
            // tMostrarImagen
            // 
            this.tMostrarImagen.Interval = 1000;
            // 
            // tSumar
            // 
            this.tSumar.Enabled = true;
            this.tSumar.Interval = 10;
            this.tSumar.Tick += new System.EventHandler(this.tSumar_Tick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(15, 125);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(498, 1);
            this.label11.TabIndex = 74;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDiferencia);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.lblIngresado);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lblTotalPagar);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(12, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 145);
            this.panel1.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(172, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 40);
            this.label5.TabIndex = 87;
            this.label5.Text = "$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(199, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 40);
            this.label4.TabIndex = 86;
            this.label4.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(307, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 40);
            this.label3.TabIndex = 85;
            this.label3.Text = "$";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(498, 1);
            this.label2.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 1);
            this.label1.TabIndex = 77;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.ForeColor = System.Drawing.Color.Blue;
            this.lblDiferencia.Location = new System.Drawing.Point(307, 96);
            this.lblDiferencia.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(203, 46);
            this.lblDiferencia.TabIndex = 76;
            this.lblDiferencia.Text = "0.00";
            this.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(3, 101);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(170, 39);
            this.label21.TabIndex = 75;
            this.label21.Text = "CAMBIO:";
            // 
            // lblIngresado
            // 
            this.lblIngresado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIngresado.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresado.ForeColor = System.Drawing.Color.Red;
            this.lblIngresado.Location = new System.Drawing.Point(300, 48);
            this.lblIngresado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(210, 46);
            this.lblIngresado.TabIndex = 74;
            this.lblIngresado.Text = "0.00";
            this.lblIngresado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 52);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(202, 39);
            this.label19.TabIndex = 73;
            this.label19.Text = "ENTREGA:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Location = new System.Drawing.Point(317, -5);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(193, 46);
            this.lblTotalPagar.TabIndex = 72;
            this.lblTotalPagar.Text = "0.00";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, -2);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(314, 39);
            this.label12.TabIndex = 71;
            this.label12.Text = "TOTAL A PAGAR:";
            // 
            // cbEfectivo
            // 
            this.cbEfectivo.AutoSize = true;
            this.cbEfectivo.Enabled = false;
            this.cbEfectivo.ForeColor = System.Drawing.Color.Blue;
            this.cbEfectivo.Location = new System.Drawing.Point(18, 18);
            this.cbEfectivo.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.cbEfectivo.Name = "cbEfectivo";
            this.cbEfectivo.Size = new System.Drawing.Size(83, 18);
            this.cbEfectivo.TabIndex = 58;
            this.cbEfectivo.TabStop = false;
            this.cbEfectivo.Text = "EFECTIVO";
            this.cbEfectivo.UseVisualStyleBackColor = true;
            this.cbEfectivo.CheckedChanged += new System.EventHandler(this.cbEfectivo_CheckedChanged);
            // 
            // frmCotizacion_Pagar_Efectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(543, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbEfectivo);
            this.Controls.Add(this.pEfectivo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCotizacion_Pagar_Efectivo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAGAR COTIZACIÓN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVentas_Pagar_FormClosing);
            this.Load += new System.EventHandler(this.frmVentas_Pagar_Efectivo_Load);
            this.pEfectivo.ResumeLayout(false);
            this.pEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEfectivo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pEfectivo;
        public System.Windows.Forms.NumericUpDown nudEfectivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tMostrarImagen;
        private System.Windows.Forms.Timer tSumar;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox cbEfectivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}