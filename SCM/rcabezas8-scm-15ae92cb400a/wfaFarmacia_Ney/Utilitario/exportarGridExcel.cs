using System;
using System.Windows.Forms;
using System.Reflection;

namespace SCM
{
    public class exportarGridExcel
    {
        public int cont;

        /*función para exportar un grid a excel*/
        public void hojaexcel(DataGridView dtgv)
        {
            int n, c;
            decimal is_decimal = 0;
            Microsoft.Office.Interop.Excel._Application oXL;

            //Excel.Application oXL;

            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;

            //Start Excel and get Application object.
            oXL = new Microsoft.Office.Interop.Excel.Application();

            //Get a new workbook.
            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
            cont = dtgv.RowCount;
            c = dtgv.ColumnCount;
           

            int k = 0;
            for (n = 0; n < dtgv.ColumnCount; n++)
            {
                if (dtgv.Columns[n].Visible == true)
                {
                    oSheet.Cells[1, k + 1] = dtgv.Columns[n].HeaderText;
                    oSheet.Rows.CurrentRegion.Font.Bold = true;
                    k++;
                }

            }
            int h = 0;
            for (int i = 0; i < cont; i++)
            {
                h = 0;
                for (int j = 0; j < c; j++)
                {
                    if (dtgv.Columns[j].Visible == true)
                    {
                        try
                        {
                            is_decimal = Convert.ToDecimal(dtgv[j, i].Value.ToString());
                        }
                        catch (Exception)
                        {
                            is_decimal = 0;
                        }
                        if (is_decimal>0)
                        {
                            try { oSheet.Cells[i + 2, h + 1] = string.Format("{0:N" + Globales.cGeneral.decimales + "}", Convert.ToDecimal(dtgv[j, i].Value.ToString())); }
                            catch { }
                        }
                        else
                        {
                            try { oSheet.Cells[i + 2, h + 1] = dtgv[j, i].Value.ToString(); }
                            catch { }
                        }
                        h++;
                    }
                }
            }
            oXL.Visible = true;
        }


        /*función para reordenar los botones visibles dentro de un groupbox*/
        public void mover(Control panel)
        {
            int valX = 0; Control[] orden;
            orden = new Control[panel.Controls.Count];
            foreach (Control botones in panel.Controls)
            {
                if (botones.Visible)
                {
                    int val = botones.TabIndex;
                    orden[val] = botones;
                }
            }

            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (orden[i] != null)
                {
                    System.Drawing.Point a = new System.Drawing.Point(valX + 20, orden[i].Location.Y);
                    orden[i].Location = a;
                    valX += orden[i].Size.Width;
                }
            }
        }

    }
}
