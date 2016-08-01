using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Session
    {
        private string usuario;
        private string pass;

        public Session() { }

        public string Usuario { get { return usuario; } set { usuario = value; } }

        public string Password
        { get { return pass; } set { pass = value; } }
    }
}
