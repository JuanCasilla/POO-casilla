using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace CasillaEjer3
{
    internal class Program
    {

        public class Password
        {

            private static int longdefault = 8;
            private int longitud;
            private string contraseña;

            public int getLongitud()
            {
                return longitud;
            }

            public string getContrase()
            {
                return contraseña;
            }

            public void setLongitud(int longitud)
            {
                this.longitud = longitud;
            }

            public Password()
            {
                this.longitud = 0;
            }

            public Password(int longitud)
            {
                this.longitud = longitud;
                contraseña = GenerarPassword();
            }

            public string GenerarPassword()
            {
                string password = "";
                for (int i = 0; i < longitud; i++)
                {
                    Random random = new Random();
                    int eleccion = random.Next((1) * 3 + 1);

                    if (eleccion == 1)
                    {
                        char minus;
                    }
                    else if (eleccion == 2)
                    {
                        char mayus;
                    }
                    else
                    {
                        char nums;
                    }
                }
                return password;
            }

            public bool esFuerte()
            {
                int cuentanums = 0;
                int cuentaminus = 0;
                int cuentamayus = 0;
                for (int i = 0; i < contraseña.Length; i++)
                {
                    if (contraseña[i] >= 97 && contraseña[i] <= 122)
                    {
                        cuentaminus += 1;
                    }
                    else
                    {
                        if (contraseña[i] >= 65 && contraseña[i] <= 90)
                        {
                            cuentamayus += 1;
                        }
                        else
                        {
                            cuentanums += 1;
                        }
                    }
                }
                if (cuentanums >= 5 && cuentaminus >= 1 && cuentamayus >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            static void Main(string[] args)
            {

                Console.Readkey();

            }
        }
    }
}
