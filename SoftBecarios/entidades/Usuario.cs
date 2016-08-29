using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string user;
        private string password;
        private int activo;
        private int permisos_id;

        public int ID { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string User { get { return user; } set { user = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int Activo { get { return activo; } set { activo = value; } }
        public int Permisos { get { return permisos_id; } set { permisos_id = value; } }
    }
}
