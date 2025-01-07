namespace SCM
{
    partial class frmVentasMensual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasMensual));
            this.Ventas_MensualesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDatos = new SCM.dsDatos();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.Ventas_MensualesTableAdapter = new SCM.dsDatosTableAdapters.Ventas_MensualesTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Ventas_MensualesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ventas_MensualesBindingSource
            // 
            this.Ventas_MensualesBindingSource.DataMember = "Ventas_Mensuales";
            this.Ventas_MensualesBindingSource.DataSource = this.dsDatos;
            // 
            // dsDatos
            // 
            this.dsDatos.DataSetName = "dsDatos";
            this.dsDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESDE EL:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(87, 21);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(106, 22);
            this.dtpDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(282, 21);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(106, 22);
            this.dtpHasta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "HASTA EL:";
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(397, 15);
            this.btnVer.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(58, 34);
            this.btnVer.TabIndex = 27;
            this.btnVer.TabStop = false;
            this.btnVer.Text = "&VER";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // Ventas_MensualesTableAdapter
            // 
            this.Ventas_MensualesTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.crReporte);
            this.panel1.Location = new System.Drawing.Point(2, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 298);
            this.panel1.TabIndex = 28;
            // 
            // crReporte
            // 
            this.crReporte.ActiveViewIndex = -1;
            this.crReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.crReporte.Location = new System.Drawing.Point(3, 3);
            this.crReporte.Name = "crReporte";
            this.crReporte.Size = new System.Drawing.Size(568, 292);
            this.crReporte.TabIndex = 4;
            this.crReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmVentasMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVentasMensual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENTAS MENSUALES";
            this.Load += new System.EventHandler(this.frmVentasMensual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ventas_MensualesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.BindingSource Ventas_MensualesBindingSource;
        private dsDatos dsDatos;
        private dsDatosTableAdapters.Ventas_MensualesTableAdapter Ventas_MensualesTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crReporte;
    }
}