using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasillaEjer1
{
    internal class Ejercicio1
    {
        public class Cuenta
        {

            private string titular;
            private int cantidad;

            public string Titular
            {
                get { return titular; }
                set { titular = value; }
            }

            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public Cuenta(string titular)
            {
                this.titular = titular;
            }

            public Cuenta(string titular, int cantidad)
            {
                this.titular = titular;
                this.cantidad = cantidad;
            }

            public bool ingresar(int valor)
            {
                if ((this.cantidad) <= 0)
                {
                    return false;
                }
                else
                {
                    cantidad = cantidad + valor;
                    return true;
                }
            }

            public bool retirar(int valor)
            {
                if (this.cantidad - valor < 0)
                {
                    cantidad = 0;
                    return false;
                }
                else
                {
                    cantidad = cantidad - valor;
                    return true;
                }
            }

        }

        static void Main(string[] args)
        {
            Cuenta c1, c2;
            bool r;
            c1 = new Cuenta("Pablo", 200);
            c2 = new Cuenta("Lorem", 900);
            r = c1.ingresar(100);
            if(r)
            {
                Console.WriteLine("Ingreso exitoso. La nueva cantidad es: " + c1.Cantidad);
            } else
            {
                Console.WriteLine("No se puede ingresar una cantidad negativa");
            }

            r = c2.retirar(90);

            if (r)
            {
                Console.WriteLine("Retiro exitoso. La nueva cantidad es: " + c2.Cantidad);

            }
            else
            {
                Console.WriteLine("No se pudo retirar. La nueva cantidad es: " + c2.Cantidad);
            }

            Console.ReadKey();
        }
    }
}
