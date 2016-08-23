using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Datos;
using Entidades;
using System.Collections;

namespace Negocio
{
    public class modelo
    {
        
        conexion conector = new conexion("192.168.0.9", "becarios", "efrainjazo", "guevara82");
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

        public void comboTipoAlumnoCalif(System.Windows.Forms.ComboBox combobox)
        {
            string sql = "SELECT id, tipo FROM tipo_alumnos LIMIT 2";
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
            string sql = "SELECT alumnos.id as ID, alumnos.numero as '#', CONCAT(alumnos.nombre, ' ', alumnos.apellido_paterno, ' ', alumnos.apellido_materno) "
                + "as 'Nombre Completo', alumnos.guardia as Guardia, escuelas.corto as Universidad, especialidades.especialidad as Servicio FROM "
                + "especialidades INNER JOIN alumnos on alumnos.especialidades_id = especialidades.id INNER JOIN escuelas on escuelas.id = alumnos.escuelas_id WHERE alumnos.tipo_alumnos_id = " + id;
            funcion.LlenarDataGrid(datagrid, sql);
        }

        public void llenarDataGridVacaciones(System.Windows.Forms.DataGridView datagrid, int id)
        {
            string sql = "SELECT numero as '#', CONCAT(nombre, ' ', apellido_paterno, ' ', apellido_materno) "
                + "as 'Nombre Completo', vac1_inicio as 'Vac1_Inicio', vac1_termino as 'Vac1_Termino', vac2_inicio as 'Vac2_Inicio', vac2_termino as 'Vac2_Termino' FROM alumnos WHERE alumnos.tipo_alumnos_id = " + id;
            funcion.LlenarDataGrid(datagrid, sql);
        }


        // Obtiene el número del siguiente alumno
        public int contadorExp(int id)
        {
            conector.abrirConexion();
            int valor = 0;
            string sql = "SELECT COUNT(*) as Contador FROM alumnos WHERE tipo_alumnos_id = " + id;
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
                sql = "SELECT numero FROM alumnos WHERE tipo_alumnos_id = " + id + " ORDER BY numero";
                MySqlDataReader num =  conector.executeReader(sql);
                while(num.Read())
                {
                    valor = Convert.ToInt16(num["numero"]) + 1;
                }
                conector.close();
            }
            return valor;
        }

        // Obtiene las ID de los Alumnos para guardarlos en un ArrayList
        public ArrayList obtieneIDalumnos(ArrayList list, int id)
        {
            conector.abrirConexion();
            string sql ="SELECT id FROM alumnos WHERE tipo_alumnos_id = " + id;
            MySqlDataReader dato = conector.executeReader(sql);
            while (dato.Read())
            {
                list.Add(dato["id"]);
            }
            conector.close();
            return list;
        }

        public Calificaciones obtieneCalificaciones(Calificaciones cal, int idA, int idT)
        {
            conector.abrirConexion();
            cal.Califica.Clear();
            string sql = string.Format("SELECT alumnos.numero, CONCAT(alumnos.nombre,' ',alumnos.apellido_paterno,' ',alumnos.apellido_materno) as nombre, alumnos.promedio, especialidades.especialidad, calificaciones.cal_final "
                    + "FROM especialidades LEFT JOIN alumnos ON especialidades.tipo_alumnos_id = alumnos.tipo_alumnos_id LEFT JOIN calificaciones ON calificaciones.especialidades_id = especialidades.id "
                    + "AND calificaciones.alumnos_id = alumnos.id WHERE alumnos.tipo_alumnos_id = '{0}' AND alumnos.id = '{1}' ORDER BY especialidades.especialidad", idT, idA);
            MySqlDataReader dato = conector.executeReader(sql);
            while (dato.Read())
            {
                cal.Numero = Convert.ToInt16(dato["numero"]);
                cal.Nombre = dato["nombre"].ToString();
                cal.Promedio = Convert.ToDouble(dato["promedio"]);
                cal.Califica.Add(dato["cal_final"]);
            }
            conector.close();
            return cal;
        }

        public Calificaciones obtieneCalificacionesR1(Calificaciones cal, int idA, int idT)
        {
            conector.abrirConexion();
            cal.Califica.Clear();
            string sql = string.Format("SELECT alumnos.numero, CONCAT(alumnos.nombre,' ',alumnos.apellido_paterno,' ',alumnos.apellido_materno) as nombre, alumnos.promedio, calificaciones.bimestre, calificaciones.cal_final "
                    + "FROM calificaciones LEFT JOIN alumnos ON calificaciones.alumnos_id = alumnos.id WHERE alumnos.id = '{0}' AND alumnos.tipo_alumnos_id = '{1}' ", idA, idT);
            MySqlDataReader dato = conector.executeReader(sql);
            while (dato.Read())
            {
                cal.Numero = Convert.ToInt16(dato["numero"]);
                cal.Nombre = dato["nombre"].ToString();
                cal.Promedio = Convert.ToDouble(dato["promedio"]);
                cal.Califica.Add(dato["cal_final"]);
            }
            conector.close();
            return cal;
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
            string sql = "SELECT * FROM alumnos WHERE id = " + expe.ID;
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

        public Calificaciones mostrarCalificacionesMIP(Calificaciones cal)
        {
            conector.abrirConexion();
            string sql = "SELECT cal_cogno, cal_psico, cal_afect, cal_final FROM calificaciones WHERE alumnos_id = " + cal.ID_Alumno + " AND especialidades_id = " + cal.ID_Servicio;
            MySqlDataReader datos = conector.executeReader(sql);
            while (datos.Read())
            {
                cal.Cal_Cogno = Convert.ToInt16(datos["cal_cogno"]);
                cal.Cal_Psico = Convert.ToInt16(datos["cal_psico"]);
                cal.Cal_Afect = Convert.ToInt16(datos["cal_afect"]);
                cal.Cal_Final = Convert.ToInt16(datos["cal_final"]);
            }
            conector.close();
            return cal;
        }

        public Boolean existeCalificacionMIP(Calificaciones cal)
        {
            conector.abrirConexion();
            Boolean flag = false;
            string sql = "SELECT COUNT(*) as contador FROM calificaciones WHERE alumnos_id = " + cal.ID_Alumno + " AND especialidades_id = " + cal.ID_Servicio;
            MySqlDataReader datos = conector.executeReader(sql);
            while(datos.Read())
            {
                if (Convert.ToInt16(datos["contador"]) != 0)
                {
                    flag = true;
                }
            }
            conector.close();
            return flag;
        }

        public Expediente sacaPromedio(int id)
        {
            conector.abrirConexion();
            Expediente expe = new Expediente();
            string sql = "SELECT promedio FROM alumnos WHERE id = " + id;
            MySqlDataReader datos = conector.executeReader(sql);
            while (datos.Read())
            {
                expe.Promedio = Convert.ToDouble(datos["promedio"]);
            }
            return expe;
        }

        public Boolean actualizaExpediente(Expediente expe)
        {
            conector.abrirConexion();
            Boolean flag = false;
            string sql = string.Format("UPDATE alumnos SET "
                + "nombre = '{0}', apellido_paterno = '{1}', apellido_materno = '{2}', nacimiento = '{3}', lugar = '{4}', fecha_inicio = '{5}', fecha_termino = '{6}', genero = '{7}', rfc = '{8}', curp = '{9}', domicilio = '{10}', colonia = '{11}', telefono = '{12}', email = '{13}', "
                + "civil = '{14}', t_pantalon = '{15}', t_filipina = '{16}', t_bata = '{17}', t_zapato = '{18}', persona_referencia = '{19}', tel_referencia = '{20}', tipo_sangre = '{21}', alergias = '{22}', enf_cronica = '{23}', med_cronico = '{24}', guardia = '{25}', turno = '{26}', "
                + "cedula = '{27}', creencias_id = '{28}', escuelas_id = '{29}', especialidades_id = '{30}' WHERE id = '{31}'",
                expe.Nombre, expe.ApellidoP, expe.ApellidoM, expe.Nacimiento, expe.Lugar, expe.Fec_Inicio, expe.Fec_Termino, expe.Genero, expe.RFC, expe.CURP, expe.Domicilio, expe.Colonia, expe.Telefono, expe.Mail, expe.Civil,
                expe.T_Pantalon, expe.T_Filipina, expe.T_Bata, expe.T_Zapato, expe.Per_Referencia, expe.Tel_Referencia, expe.Tipo_Sangre, expe.Alergias, expe.Enf_Cronica, expe.Med_Cronico, expe.Guardia, expe.Turno, expe.Cedula, expe.Religion, expe.Escuela, expe.Servicio, expe.ID);
            if (conector.executeSQL(sql))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean guardaVacaciones(Expediente expe)
        {
            conector.abrirConexion();
            Boolean flag = false;
            string sql = string.Format("UPDATE alumnos SET vac1_inicio = '{0}', vac1_termino = '{1}', vac2_inicio = '{2}', vac2_termino = '{3}' WHERE id = '{4}'", expe.Vac1_Inicio, expe.Vac1_Termino, expe.Vac2_Inicio, expe.Vac2_Termino, expe.ID);
            if (conector.executeSQL(sql))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean guardaCalificacionesMIP(Calificaciones cal, Expediente expe)
        {
            Boolean flag = false;
            conector.abrirConexion();
            string sql = string.Format("INSERT INTO calificaciones (cal_cogno, cal_psico, cal_afect, cal_final, alumnos_id, especialidades_id) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", cal.Cal_Cogno, cal.Cal_Psico, cal.Cal_Afect,cal.Cal_Final,cal.ID_Alumno,cal.ID_Servicio);
            string sql2 = string.Format("UPDATE alumnos SET promedio = '{0}' WHERE id = '{1}'", expe.Promedio, cal.ID_Alumno);
            if (conector.executeSQL(sql) && conector.executeSQL(sql2))
            {
                flag = true;
            }
            return flag;
        }

        public Boolean guardaCalificacionesR1(Calificaciones cal)
        {
            Boolean flag = false;
            conector.abrirConexion();
            string sql = string.Format("INSERT INTO calificaciones (bimestres_id, cal_final, alumnos_id, especialidades_id) VALUES ('{0}','{1}','{2}','{3}')", cal.Bimestre, cal.Cal_Final, cal.ID_Alumno, cal.ID_Servicio);
            string sql2 = string.Format("UPDATE alumnos SET promedio = '{0}' WHERE id = '{1}'", cal.Promedio, cal.ID_Alumno);
            if (conector.executeSQL(sql) && conector.executeSQL(sql2))
            {
                flag = true;
            }
            return flag;
        }
        #endregion
    }
}
