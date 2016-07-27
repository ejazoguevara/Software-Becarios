using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using Datos;
using Entidades;

namespace Negocio
{
    public class modelo
    {
        /*
        conexion conector = new conexion("localhost", "becarios", "root", "");
        funciones funcion = new funciones();

        MySqlDataReader leer;
        MySqlDataReader leer2;
        MySqlDataReader leer3;
        MySqlDataReader reader;
        public bool login(Session log)
        {
            bool encontrado = false;
            string sql = string.Format("SELECT * FROM medicos WHERE usuario = '{0}' AND password = '{1}'", log.Usuario, log.Pass);
            leer = conector.executeReader(sql);
            if (leer.Read())
            {
                encontrado = true;
            }
            conector.close();
            conector.abrirConexion();
            if (encontrado == true)
            {
                sql = string.Format("UPDATE medicos SET activo = 1 WHERE usuario = '{0}' AND password = '{1}'", log.Usuario, log.Pass);
                conector.executeSQL(sql);
            }
            leer.Close();
            return encontrado;
        }
         * */
    }
}
