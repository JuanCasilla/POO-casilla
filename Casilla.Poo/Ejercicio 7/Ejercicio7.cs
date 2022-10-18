using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    internal class Program
    {

        public class Raices
        {

            private double a;
            private double b;
            private double c;

            public Raices(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            private void obtenerRaices()
            {

                double F1 = (-b + Math.Sqrt(getDiscriminante())) / (2 * a);
                double F2 = (-b - Math.Sqrt(getDiscriminante())) / (2 * a);

                Console.WriteLine("Solucion 1: " + F1);
                Console.WriteLine("Solucion 2: " + F2);
            }

            private void obtenerRaiz()
            {
                double x = (-b) / (2 * a);

                Console.WriteLine("Es la unica solucion");
                Console.WriteLine(x);
            }

            private double getDiscriminante()
            {
                return Math.Pow(b, 2) - (4 * a * c);
            }

            private bool tieneRaices()
            {
                return getDiscriminante() > 0;
            }

            private bool tieneRaiz()
            {
                return getDiscriminante() == 0;
            }

            public void calcular()
            {

                if (tieneRaices())
                {
                    obtenerRaices();
                }
                else if (tieneRaiz())
                {
                    obtenerRaiz();
                }
                else
                {
                    Console.WriteLine("Sin soluciones");
                }

            }

            static void Main(string[] args)
            {

                Raices ecuacion = new Raices(5, 5, 1);
                ecuacion.calcular();
                Console.ReadKey();

            }
        }
    }
}
