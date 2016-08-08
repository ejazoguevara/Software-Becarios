using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calificaciones
    {
        private int bimestre;
        private int cal_cogno;
        private int cal_psico;
        private int cal_afect;
        private int cal_final;
        private int id_alumno;
        private int id_servicio;

        public int Bimestre { get { return bimestre; } set { bimestre = value; } }
        public int Cal_Cogno { get { return cal_cogno; } set { cal_cogno = value; } }
        public int Cal_Psico { get { return cal_psico; } set { cal_psico = value; } }
        public int Cal_Afect { get { return cal_afect; } set { cal_afect = value; } }
        public int Cal_Final { get { return cal_final; } set { cal_final = value; } }
        public int ID_Alumno { get { return id_alumno; } set { id_alumno = value; } }
        public int ID_Servicio { get { return id_servicio; } set { id_servicio = value; } }
    }
}
