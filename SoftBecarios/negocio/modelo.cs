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
        Expediente expe = new Expediente();
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

        // Muestra las escuelas en un DataGridView
        public void cargarDataGridEscuela(System.Windows.Forms.DataGridView datagrid)
        {
            string sql = "SELECT escuela as 'Nombre de la Escuela' FROM escuelas";
            funcion.LlenarDataGrid(datagrid, sql);
        }

        #endregion

        #region Expedientes

        // Llenado de los comboboxes
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
        
        public void llenarDataGridExpedientes(System.Windows.Forms.DataGridView datagrid, int id)
        {
            string sql = "SELECT alumnos.numero as '#', CONCAT(alumnos.nombre, ' ', alumnos.apellido_paterno, ' ', alumnos.apellido_materno) "
                + "as 'Nombre Completo', alumnos.guardia as Guardia, escuelas.corto as Universidad, especialidades.especialidad as Servicio FROM "
                + "especialidades INNER JOIN alumnos on alumnos.especialidades_id = especialidades.id INNER JOIN escuelas on escuelas.id = alumnos.escuelas_id WHERE alumnos.tipo_alumnos_id = " + id;
            funcion.LlenarDataGrid(datagrid, sql);
        }


        // Obtiene el número del siguiente alumno
        public int contadorExp()
        {
            int valor = 0;
            string sql = "SELECT COUNT(*) as Contador FROM alumnos";
            MySqlDataReader dato = conector.executeReader(sql);
            while (dato.Read())
            {
                valor = Convert.ToInt16(dato["Contador"]);
            }
            conector.close();
            if(valor == 0)
            {
                valor = 1;
            }
            else
            {
                conector.abrirConexion();
                sql = "SELECT numero FROM alumnos";
                MySqlDataReader num =  conector.executeReader(sql);
                while(num.Read())
                {
                    valor = Convert.ToInt16(num["numero"]) + 1;
                }
                conector.close();
            }
            return valor;
        }

        // Guarda nuevo expediente
        public Boolean guardarExpediente(Expediente expe)
        {
            conector.abrirConexion();
            Boolean flag = false;
            string sql = string.Format("INSERT INTO alumnos "
                + "(numero, nombre, apellido_paterno, apellido_materno, nacimiento, lugar, fecha_inicio, fecha_termino, genero, rfc, curp, domicilio, colonia, telefono, email, civil, t_pantalon, t_filipina, t_bata, t_zapato, "
                + "persona_referencia, tel_referencia, tipo_sangre, alergias, enf_cronica, med_cronico, guardia, turno, cedula, tipo_alumnos_id, creencias_id, escuelas_id, especialidades_id) "
                + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}')",
                expe.Numero, expe.Nombre, expe.ApellidoP, expe.ApellidoM, expe.Nacimiento, expe.Lugar, expe.Fec_Inicio, expe.Fec_Termino, expe.Genero, expe.RFC, expe.CURP, expe.Domicilio, expe.Colonia, expe.Telefono, expe.Mail, expe.Civil, 
                expe.T_Pantalon, expe.T_Filipina, expe.T_Bata, expe.T_Zapato, expe.Per_Referencia, expe.Tel_Referencia, expe.Tipo_Sangre, expe.Alergias, expe.Enf_Cronica, expe.Med_Cronico, expe.Guardia, expe.Turno, expe.Cedula, expe.Tipo, expe.Religion, expe.Escuela, expe.Servicio);
            if (conector.executeSQL(sql))
            {
                flag = true;
            }
            return flag;
        }

        public Expediente mostrarExpediente(Expediente expe)
        {
            conector.abrirConexion();
            /*
            string sql = "SELECT alumnos.id, alumnos.numero, alumnos.nombre, alumnos.apellido_paterno, alumnos.apellido_materno, alumnos.nacimiento, alumnos.lugar, alumnos.fecha_inicio, alumnos.fecha_termino, alumnos.genero, alumnos.rfc, alumnos.curp, alumnos.domicilio, alumnos.colonia, alumnos.telefono, "
                + "alumnos.email, alumnos.civil, alumnos.t_pantalon, alumnos.t_filipina, alumnos.t_bata, alumnos.t_zapato, alumnos.persona_referencia, alumnos.tel_referencia, alumnos.tipo_sangre, alumnos.alergias, alumnos.enf_cronica, alumnos.med_cronico, alumnos.vac1_inicio, alumnos.vac1_termino, alumnos.vac2_inicio, alumnos.vac2_termino, "
                + "alumnos.guardia, alumnos.cedula, alumnos.promedio, tipo_alumnos.tipo, creencias.religion, escuelas.escuela, especialidades.especialidad "
                + "FROM (especialidades INNER JOIN (tipo_alumnos INNER JOIN (creencias INNER JOIN (escuelas INNER JOIN alumnos on alumnos.escuelas_id = escuelas.id) on alumnos.creencias_id = creencias.id) on alumnos.tipo_alumnos_id = tipo_alumnos.id) on alumnos.especialidades_id = especialidades.id)";
             * */
            string sql = "SELECT * FROM alumnos WHERE numero = " + expe.Numero;
            MySqlDataReader datos = conector.executeReader(sql);
            while (datos.Read())
            {
                expe.ID = Convert.ToInt16(datos["id"]);
                expe.Numero = Convert.ToInt16(datos["numero"]);
                expe.Nombre = datos["nombre"].ToString();
                expe.ApellidoP = datos["apellido_paterno"].ToString();
                expe.ApellidoM = datos["apellido_materno"].ToString();
                expe.Nacimiento = datos["nacimiento"].ToString();
                expe.Lugar = datos["lugar"].ToString();
                expe.Fec_Inicio = datos["fecha_inicio"].ToString();
                expe.Fec_Termino = datos["fecha_termino"].ToString();
                expe.Genero = datos["genero"].ToString();
                expe.RFC = datos["rfc"].ToString();
                expe.CURP = datos["curp"].ToString();
                expe.Domicilio = datos["domicilio"].ToString();
                expe.Colonia = datos["colonia"].ToString();
                expe.Telefono = datos["telefono"].ToString();
                expe.Mail = datos["email"].ToString();
                expe.Civil = datos["civil"].ToString();
                expe.T_Pantalon = Convert.ToInt16(datos["t_pantalon"]);
                expe.T_Filipina = Convert.ToInt16(datos["t_filipina"]);
                expe.T_Bata = Convert.ToInt16(datos["t_bata"]);
                expe.T_Zapato = Convert.ToDouble(datos["t_zapato"]);
                expe.Per_Referencia = datos["persona_referencia"].ToString();
                expe.Tel_Referencia = datos["tel_referencia"].ToString();
                expe.Tipo_Sangre = datos["tipo_sangre"].ToString();
                expe.Alergias = datos["alergias"].ToString();
                expe.Enf_Cronica = datos["enf_cronica"].ToString();
                expe.Med_Cronico = datos["med_cronico"].ToString();
                expe.Vac1_Inicio = datos["vac1_inicio"].ToString();
                expe.Vac1_Termino = datos["vac1_termino"].ToString();
                expe.Vac2_Inicio = datos["vac2_inicio"].ToString();
                expe.Vac2_Termino = datos["vac2_termino"].ToString();
                expe.Guardia = datos["guardia"].ToString();
                expe.Cedula = datos["cedula"].ToString();
                expe.Turno = datos["turno"].ToString();
                expe.Tipo = Convert.ToInt16(datos["tipo_alumnos_id"]);
                expe.Religion = Convert.ToInt16(datos["creencias_id"]);
                expe.Escuela = Convert.ToInt16(datos["escuelas_id"]);
                expe.Servicio = Convert.ToInt16(datos["especialidades_id"]);
            }
            conector.close();
            return expe;
        }
        #endregion
    }
}
