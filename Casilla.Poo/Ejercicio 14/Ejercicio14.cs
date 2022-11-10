using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_14
{
    internal class Ejercicio14
    {

        public class Producto
        {
            private string nombre;
            private double precio;

            public Producto(string nombre, double precio)
            {
                this.nombre = nombre;
                this.precio = precio;
            }

            public string getNombre()
            {
                return nombre;
            }

            public void setNombre(string nombre)
            {
                this.nombre = nombre;
            }

            public double getPrecio()
            {
                return precio;
            }

            public void setPrecio(double precio)
            {
                this.precio = precio;
            }

            public virtual double calcular(int cantidad)
            {
                return precio * cantidad;
            }
        }

        public class Perecedero : Producto
        {
            private int dias_a_caducar;

            public Perecedero(int dias_a_caducar, string nombre, double precio) : base(nombre, precio)
            {
                this.dias_a_caducar = dias_a_caducar;
            }

            public int getDias_a_caducar()
            {
                return dias_a_caducar;
            }

            public void setDias_a_caducar(int dias_a_caducar)
            {
                this.dias_a_caducar = dias_a_caducar;
            }

            public override double calcular(int cantidad)
            {

                double precioFinal = base.calcular(cantidad);

                    if (dias_a_caducar == 3){
                    precioFinal = precioFinal / 2;
                }else if(dias_a_caducar == 2){
                    precioFinal = precioFinal / 3;
                }else if(dias_a_caducar == 1){
                        precioFinal = precioFinal / 4;
                }
                return precioFinal;
            }
        }

        public class NoPerecedero : Producto
        {

            private string tipo;

            public NoPerecedero(string tipo, string nombre, double precio) : base(nombre, precio)
            {
                this.tipo = tipo;
            }

            public string getTipo()
            {
                return tipo;
            }

            public void setTipo(string tipo)
            {
                this.tipo = tipo;
            }
        }

        static void Main(string[] args)
        {
            Producto[] productos = new Producto[3];

            productos[0] = new Producto("producto 1", 10);
            productos[1] = new Perecedero(1, "producto 2", 20);
            productos[2] = new NoPerecedero("tipo 1", "producto 3", 5);

            Console.WriteLine("Precios sin calcular: ");
            Console.WriteLine("");
            Console.WriteLine("Productos normales: " + productos[0].getPrecio());
            Console.WriteLine("Productos perecederos: " + productos[1].getPrecio());
            Console.WriteLine("Productos NO perecederos: " + productos[2].getPrecio());
            Console.WriteLine("");

            double total = 0;
            int numprod = 1;

            for (int i = 0; i < productos.Length; i++)
            {
                total += productos[i].calcular(5);
                numprod++;
            }

            Console.WriteLine("Precio final calculado: " + total);
            Console.ReadLine();
        }
    }
}