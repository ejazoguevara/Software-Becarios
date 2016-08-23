using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Datos;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Negocio
{
    public class funciones
    {

        conexion conector = new conexion("192.168.0.9", "becarios", "efrainjazo", "guevara82");
        public BindingSource BindingSource1 = new BindingSource();
        public MySqlDataAdapter da;
        public DataTable dt;

        //Llenar combobox
        public void llenarCombos(System.Windows.Forms.ComboBox combo, string sql, string value, string display)
        {
            conector.cm = conector.cnn.CreateCommand();
            conector.da = new MySqlDataAdapter();
            conector.dt = new DataTable();
            conector.cm.Connection = conector.cnn;
            conector.cm.CommandText = sql;
            conector.da.SelectCommand = conector.cm;
            conector.da.Fill(conector.dt);
            combo.DataSource = conector.dt;
            combo.ValueMember = value;
            combo.DisplayMember = display;
            conector.da = null;
            conector.cm = null;
        }

        //Llenar datagrid
        public DataGridView LlenarDataGrid(System.Windows.Forms.DataGridView grid, string sql)
        {
            BindingSource1 = new BindingSource();
            try
            {

                conector.da = new MySqlDataAdapter(sql, conector.cnn);
                conector.dt = new DataTable();
                conector.dt.Clear();
                conector.da.Fill(conector.dt);
                BindingSource1.DataSource = conector.dt;
                grid.DataSource = BindingSource1;
                //grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Cyan;
                //grid.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
                //grid.DefaultCellStyle.SelectionForeColor = Color.White;
                //grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                //DTinsumos.AlternatingRowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
                //grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception)
            {
                return null;
            }
            return grid;
        }

        public BindingSource LlenarBinding(string sql)
        {
            try
            {
                da = new MySqlDataAdapter(sql, conector.cnn);
                dt = new DataTable();
                dt.Clear();
                da.Fill(conector.dt);
                BindingSource1.DataSource = dt;
            }
            catch (Exception)
            {

            }
            return BindingSource1;
        }

        //Aplica el filtro
        public void gridFiltro(string filtro)
        {
            try
            {
                BindingSource1.Filter = filtro;
            }
            catch (Exception)
            {

            }

        }
         
    }
}
