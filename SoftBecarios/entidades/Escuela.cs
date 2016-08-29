using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escuela
    {
        private int id;
        private string nombre;
        private string corto;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Corto { get { return corto; } set { corto = value; } }
    }
}
