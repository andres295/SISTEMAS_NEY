namespace SCM
{
    partial class frmCotizaciones_Imprimir
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotizaciones_Imprimir));
            this.r_Cotizaciones_ProdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDatos = new SCM.dsDatos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.r_Cotizaciones_ProdTableAdapter = new SCM.dsDatosTableAdapters.r_Cotizaciones_ProdTableAdapter();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.r_Cotizaciones_ProdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // r_Cotizaciones_ProdBindingSource
            // 
            this.r_Cotizaciones_ProdBindingSource.DataMember = "r_Cotizaciones_Prod";
            this.r_Cotizaciones_ProdBindingSource.DataSource = this.dsDatos;
            // 
            // dsDatos
            // 
            this.dsDatos.DataSetName = "dsDatos";
            this.dsDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.r_Cotizaciones_ProdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SCM.ReportViewer.rptCotizaciones_Prod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(741, 318);
            this.reportViewer1.TabIndex = 0;
            // 
            // r_Cotizaciones_ProdTableAdapter
            // 
            this.r_Cotizaciones_ProdTableAdapter.ClearBeforeFill = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrar.Location = new System.Drawing.Point(666, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(72, 24);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmCotizaciones_Imprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(741, 318);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCotizaciones_Imprimir";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRIMIR COTIZACIÓN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCotizaciones_Imprimir_FormClosing);
            this.Load += new System.EventHandler(this.frmCotizaciones_Imprimir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.r_Cotizaciones_ProdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource r_Cotizaciones_ProdBindingSource;
        private dsDatos dsDatos;
        private dsDatosTableAdapters.r_Cotizaciones_ProdTableAdapter r_Cotizaciones_ProdTableAdapter;
        private System.Windows.Forms.Button btnCerrar;
    }
}