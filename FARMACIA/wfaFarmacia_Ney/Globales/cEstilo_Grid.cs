using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace wfaFarmacia_Ney.Globales
{
    public class cEstilo_Grid
    {
        public void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, control, new object[] { true });
        }

        public void grid_selfull_con_alter(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.FromArgb(128, 128, 128); //196, 196, 196
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 124, 209);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(247, 247, 247);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.RowsDefaultCellStyle.BackColor = Color.White; 
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);

            dgv.StandardTab = false;
            dgv.TabStop = false;

            DataGridViewCellStyle estilos = dgv.ColumnHeadersDefaultCellStyle;
            estilos.BackColor = Color.FromArgb(0, 122, 204);
            estilos.ForeColor = Color.White;
            estilos.Font = new Font(dgv.Font, FontStyle.Bold);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ReadOnly = true;
            dgv.ColumnHeadersHeight = 30;
            dgv.RowsDefaultCellStyle.Padding = new Padding(2);
        }

        public void grid_selfree_con_alter(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.FromArgb(128, 128, 128); //196, 196, 196
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 124, 209);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(247, 247, 247);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            dgv.GridColor = Color.FromArgb(221, 221, 221); 
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.StandardTab = false;
            dgv.TabStop = false;

            DataGridViewCellStyle estilos = dgv.ColumnHeadersDefaultCellStyle;
            estilos.BackColor = Color.FromArgb(0, 122, 204);
            estilos.ForeColor = Color.White;
            estilos.Font = new Font(dgv.Font, FontStyle.Bold);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ReadOnly = true;
            dgv.ColumnHeadersHeight = 30;
            dgv.RowsDefaultCellStyle.Padding = new Padding(2);
        }

        public void grid_ventas_full_sin_alter(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.FromArgb(128, 128, 128); //196, 196, 196
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 124, 209);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(247, 247, 247);
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.StandardTab = false;
            dgv.TabStop = false;

            DataGridViewCellStyle estilos = dgv.ColumnHeadersDefaultCellStyle;
            estilos.BackColor = Color.FromArgb(0, 122, 204);
            estilos.ForeColor = Color.White;
            estilos.Font = new Font(dgv.Font, FontStyle.Bold);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ReadOnly = true;
            dgv.ColumnHeadersHeight = 30;
            dgv.RowsDefaultCellStyle.Padding = new Padding(2);
        }

        public void grid_ventas_free_sin_alter(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.FromArgb(128, 128, 128); //196, 196, 196
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 124, 209);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(247, 247, 247);
            dgv.GridColor = Color.FromArgb(221, 221, 221);
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.StandardTab = false;
            dgv.TabStop = false;

            DataGridViewCellStyle estilos = dgv.ColumnHeadersDefaultCellStyle;
            estilos.BackColor = Color.FromArgb(0, 122, 204);
            estilos.ForeColor = Color.White;
            estilos.Font = new Font(dgv.Font, FontStyle.Bold);

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ReadOnly = true;
            dgv.ColumnHeadersHeight = 30;
            dgv.RowsDefaultCellStyle.Padding = new Padding(2);
        }
    }
}
