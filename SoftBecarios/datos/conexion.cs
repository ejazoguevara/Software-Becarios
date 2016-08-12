using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class conexion
    {
        
        public string StrConexion;
        public MySqlCommand cm;
        public MySqlDataReader reader;
        public MySqlDataAdapter da;
        public DataTable dt;
        public MySqlConnection cnn;

        string server = "";
        string bd = "";
        string user = "";
        string pass = "";

        public conexion()
        {
            abrirConexion();
        }

        public conexion(string server, string bd, string user, string pass)
        {
            this.server = server;
            this.bd = bd;
            this.user = user;
            this.pass = pass;
            abrirConexion();
        }

        //Abre conexión con la base de datos
        public bool abrirConexion()
        {
            bool _bandera = false;

            StrConexion = string.Format("server='{0}';database='{1}';user id='{2}';password='{3}'", server, bd, user, pass);
            try
            {
                cnn = new MySqlConnection(StrConexion);
                cnn.Open();
                _bandera = true;
            }
            catch (InvalidCastException)
            {
                _bandera = false;
            }
            return _bandera;
        }

        // Cierra conexión
        public void close()
        {
            cm = null;
            cnn.Close();
        }


        //Verifica si existe un registro solicitado
        public bool existe(string sql)
        {
            bool _bandera = false;
            cm = new MySqlCommand();
            cm.CommandText = sql;
            cm.Connection = cnn;
            reader = cm.ExecuteReader();
            if (reader.Read() == true)
            {
                _bandera = true;
            }
            else
            {
                _bandera = false;
            }
            reader.Close();
            cm = null;
            return _bandera;
        }

        //Ejecuta SQL
        public bool executeSQL(string sql)
        {
            bool _bandera = false;
            try
            {
                cm = new MySqlCommand();
                cm.CommandText = sql;
                cm.Connection = cnn;
                cm.ExecuteNonQuery();
                _bandera = true;
            }
            catch (Exception)
            {

                _bandera = false;

            }
            cm = null;
            return _bandera;
        }

        //Ejecuta reader
        public MySqlDataReader executeReader(string sql)
        {
            try
            {
                cm = new MySqlCommand();
                cm.CommandText = sql;
                cm.Connection = cnn;
                reader = cm.ExecuteReader();
            }
            catch (Exception)
            {
                reader = null;
            }
            cm = null;
            return reader;
        }

        //Ejecuta reader
        public IEnumerable<IDataRecord> leerDatos(string sql)
        {
            cm = cnn.CreateCommand();
            cm.CommandText = sql;
            //reader = cmd.ExecuteReader();
            using (var reader = cm.ExecuteReader())
            {
                //bool encontrado = false;
                while (reader.Read())
                {
                    yield return (IDataRecord)reader;
                    //encontrado = true;
                }

            }
        }
         
    }
}
