 using System;

namespace Ejercicio_1

{
    internal class Program
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
            Cuenta cuenta1, cuenta2, cuenta3;
            bool operacion = false;
            cuenta1 = new Cuenta("Gabriel", 200);
            cuenta2 = new Cuenta("Alexis", 400);
            cuenta3 = new Cuenta("Julian", 300);
            operacion = cuenta1.ingresar(400);
            if (operacion)
            {
                Console.WriteLine("Se ha ingresado dinero y su saldo ahora es: {0}", cuenta1.Cantidad);
            }


            operacion = cuenta2.retirar(150);

            if (operacion)
            {
                Console.WriteLine("Se ha retirado dinero y su saldo ahora es: {0} ", cuenta2.Cantidad);

            }
            else
            {
                Console.WriteLine("Error en la operacion, no se puedo retirar dinero. La nueva cantidad es: {0}", cuenta2.Cantidad);
            }

            operacion = cuenta3.retirar(200);

            if (operacion)
            {
                Console.WriteLine("Se ha retirado dinero y su saldo ahora es: {0} ", cuenta3.Cantidad);

            }
            else
            {
                Console.WriteLine("Error en la operacion, no se puedo retirar dinero. La nueva cantidad es: {0}", cuenta3.Cantidad);
            }

            Console.ReadKey();
        }
    }
}
