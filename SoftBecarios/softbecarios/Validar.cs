using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftBecarios
{
    class Validar
    {
        public static bool soloNumeros(char e)
        {
            int tecla = (int)e;
            if (tecla >= 48 && tecla <= 57)
                return false;
            else if (tecla == 8)
                return false;
            else
                return true;
        }

        public static bool soloLetras(char e)
        {
            int tecla = (int)e;
            if (tecla >= 65 && tecla <= 90)
                return false;
            else if (tecla >= 97 && tecla <= 122)
                return false;
            else if (tecla == 8) //retroceso
                return false;
            else if (tecla == 32) //espacio
                return false;
            else if (tecla == 46) //punto
                return false;
            else
                return true;
        }

        public static bool correo(char e)
        {
            int tecla = (int)e;
            if (tecla >= 65 && tecla <= 90)
                return false;
            else if (tecla >= 97 && tecla <= 122)
                return false;
            else if (tecla >= 48 && tecla <= 57)  // numeros
                return false;
            else if (tecla == 8) //retroceso
                return false;
            else if (tecla == 32) //espacio
                return false;
            else if (tecla == 46) //punto
                return false;
            else if (tecla == 64) //simbolo @
                return false;
            else if (tecla == 95) //simbolo _
                return false;
            else
                return true;
        }

        public static bool telefono(char e)
        {
            int tecla = (int)e;
            if (tecla >= 48 && tecla <= 57)
                return false;
            else if (tecla == 8) //retroceso
                return false;
            else if (tecla == 40) //simbolo (
                return false;
            else if (tecla == 41) //simbolo )
                return false;
            else if (tecla == 45) //guion
                return false;
            else if (tecla == 46) //punto
                return false;
            else
                return true;
        }

        public static bool letrasSignos(char e)
        {
            int tecla = (int)e;
            if (tecla >= 65 && tecla <= 90)
                return false;
            else if (tecla >= 97 && tecla <= 122)
                return false;
            else if (tecla >= 48 && tecla <= 57)  // numeros
                return false;
            else if (tecla == 8) //espacio
                return false;
            else if (tecla == 13) //enter
                return false;
            else if (tecla == 45) //guion
                return false;
            else if (tecla == 46) //punto
                return false;
            else if (tecla == 32) //espacio
                return false;
            else if (tecla == 35) //simbolo #
                return false;
            else
                return true;
        }

        public static bool ComprobarEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
