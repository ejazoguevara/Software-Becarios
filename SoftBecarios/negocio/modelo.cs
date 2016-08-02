using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Datos;
using Entidades;

namespace Negocio
{
    public class modelo
    {
        
        conexion conector = new conexion("localhost", "becarios", "root", "");
        funciones funcion = new funciones();

        MySqlDataReader leer;
        

        public bool login(Session log)
        {
            bool encontrado = false;
            string sql = string.Format("SELECT * FROM medicos WHERE usuario = '{0}' AND password = '{1}'", log.Usuario, log.Password);
            leer = conector.executeReader(sql);
            if (leer.Read())
            {
                encontrado = true;
            }
            conector.close();
            conector.abrirConexion();
            if (encontrado == true)
            {
                sql = string.Format("UPDATE medicos SET activo = 1 WHERE usuario = '{0}' AND password = '{1}'", log.Usuario, log.Password);
                conector.executeSQL(sql);
            }
            leer.Close();
            return encontrado;
        }


        #region Escuelas

        public void cargarDataGridEscuela(System.Windows.Forms.DataGridView datagrid)
        {
            string sql = "SELECT escuela as 'Nombre de la Escuela' FROM escuelas";
            funcion.LlenarDataGrid(datagrid, sql);
        }

        #endregion

        #region Expedientes

        public void comboTipoAlumno(System.Windows.Forms.ComboBox combobox)
        {
            string sql = "SELECT id, tipo FROM tipo_alumnos";
            funcion.llenarCombos(combobox, sql, "id", "tipo");
        }

        public void comboEscuelas(System.Windows.Forms.ComboBox combobox)
        {
            string sql = "SELECT id, escuela FROM escuelas ORDER BY escuela";
            funcion.llenarCombos(combobox, sql, "id", "escuela");
        }

        public void comboReligion(System.Windows.Forms.ComboBox combobox)
        {
            string sql = "SELECT id, religion FROM creencias";
            funcion.llenarCombos(combobox, sql, "id", "religion");
        }

        public void comboServicios(System.Windows.Forms.ComboBox combobox, int id)
        {
            string sql = "SELECT id, especialidad FROM especialidades WHERE tipo_alumnos_id = " + id + " ORDER BY especialidad";
            funcion.llenarCombos(combobox, sql, "id", "especialidad");
        }

        public int contadorExp()
        {
            int valor = 0;
            string sql = "SELECT COUNT(*) as Contador FROM alumnos";
            MySqlDataReader dato = conector.executeReader(sql);
            while (dato.Read())
            {
                valor = Convert.ToInt16(dato["Contador"]);
            }
            if(valor == 0)
            {
                valor = 1;
            }
            else
            {
                sql = "SELECT numero FROM alumnos";
                dato = conector.executeReader(sql);
                while(dato.Read())
                {
                    valor = Convert.ToInt16(dato["numero"]) + 1;
                }
            }
            return valor;
        }
        #endregion
    }
}
