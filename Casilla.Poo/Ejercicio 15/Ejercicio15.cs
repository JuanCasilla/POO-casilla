using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    internal class Ejercicio15
    {

        public class Bebida
        {
            private static int idActual = 1;
            private int id;
            private double cantidad;
            private double precio;
            private string marca;

            public Bebida(double cantidad, double precio, string marca)
            {

                this.id = idActual++;

                this.cantidad = cantidad;
                this.precio = precio;
                this.marca = marca;
            }

            public int getId()
            {
                return id;
            }

            public void setId(int id)
            {
                this.id = id;
            }

            public double getCantidad()
            {
                return cantidad;
            }

            public void setCantidad(double cantidad)
            {
                this.cantidad = cantidad;
            }

            public virtual double getPrecio()
            {
                return precio;
            }

            public void setPrecio(double precio)
            {
                this.precio = precio;
            }

            public string getMarca()
            {
                return marca;
            }

            public void setMarca(string marca)
            {
                this.marca = marca;
            }
        }

        public class BebidaAzucarada : Bebida
        {
            private double porcentajeAzucar;
            private bool promocion;

            public BebidaAzucarada(double porcentajeAzucar, bool promocion, double cantidad, double precio, string marca) : base(cantidad, precio, marca)
            {
                this.porcentajeAzucar = porcentajeAzucar;
                this.promocion = promocion;
            }

            public double getPorcentajeAzucar()
            {
                return porcentajeAzucar;
            }
            public void setPorcentajeAzucar(double porcentajeAzucar)
            {
                this.porcentajeAzucar = porcentajeAzucar;
            }
            public bool isPromocion()
            {
                return promocion;
            }

            public void setPromocion(bool promocion)
            {
                this.promocion = promocion;
            }
            public override double getPrecio()
            {
                if (isPromocion())
                {
                    return base.getPrecio() * 0.9;
                }
                else
                {
                    return base.getPrecio();
                }
            }
        }

        public class AguaMineral : Bebida
        {
            private string manatial;
            public AguaMineral(string manatial, double cantidad, double precio, string marca) : base(cantidad, precio, marca)
            {
                this.manatial = manatial;
            }

            public string getManatial()
            {
                return manatial;
            }
            public void setManatial(string manatial)
            {
                this.manatial = manatial;
            }
        }

        public class Almacen
        {
            private Bebida[,] estanteria;

            public Almacen(int filas, int columnas)
            {
                estanteria = new Bebida[filas, columnas];
            }

            public Almacen()
            {
                estanteria = new Bebida[5,5];
            }

            public void agregarBebida(Bebida b)
            {
                bool encontrado = false;
                for (int i = 0; i < estanteria.Length && !encontrado; i++)
                {
                    for (int j = 0; j < estanteria.GetLength(0) && !encontrado; j++)
                    {
                        if (estanteria[i, j] == null)
                        {
                            estanteria[i, j] = b;
                            encontrado = true;
                        }
                    }
                }

                if (encontrado)
                {
                    Console.WriteLine("Bebida añadida");
                }
                else
                {
                    Console.WriteLine("No se ha podido añadir la bebida");
                }
            }

            public void eliminarBebida(int id)
            {

                bool encontrado = false;
                for (int i = 0; i < estanteria.Length && !encontrado; i++)
                {
                    for (int j = 0; j < estanteria.GetLength(0) && !encontrado; j++)
                    {
                        if (estanteria[i, j] != null)
                        {
                            if (estanteria[i, j].getId() == id)
                            {
                                estanteria[i, j] = null;
                                encontrado = true;
                            }
                        }
                    }
                }

                if (encontrado)
                {
                    Console.WriteLine("Bebida eliminada");
                }
                else
                {
                    Console.WriteLine("No existe la bebida");
                }
            }

            public void mostrarBebidas()
            {
                for (int i = 0; i < estanteria.Length; i++)
                {
                    for (int j = 0; j < estanteria.GetLength(0); j++)
                    {
                        if (estanteria[i, j] != null)
                        {
                            Console.WriteLine("fila " + i + ", columna: " + j + " Bebida: " + estanteria[i, j].getMarca());
                        }
                    }
                }
            }

            public double calcularPrecioBebidas()
            {
                double precioTotal = 0;
                for (int i = 0; i < estanteria.Length; i++)
                {
                    for (int j = 0; j < estanteria.GetLength(0); j++)
                    {
                        if (estanteria[i, j] != null)
                        {
                            precioTotal += estanteria[i, j].getPrecio();
                        }
                    }
                }

                return precioTotal;

            }

            public double calcularPrecioBebidas(string marca)
            {
                double precioTotal = 0;
                for (int i = 0; i < estanteria.Length; i++)
                {
                    for (int j = 0; j < estanteria.GetLength(0); j++)
                    {
                        if (estanteria[i, j] != null)
                        {

                            if (estanteria[i, j].getMarca().Equals(marca))
                            {
                                precioTotal += estanteria[i, j].getPrecio();
                            }
                        }
                    }
                }
                return precioTotal;
            }

            public double calcularPrecioBebidas(int columna)
            {
                double precioTotal = 0;
                if (columna >= 0 && columna < estanteria.GetLength(0))
                {
                    for (int i = 0; i < estanteria.Length; i++)
                    {
                        if (estanteria[i, columna] != null)
                        {
                            precioTotal += estanteria[i, columna].getPrecio();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("La columna debe estar entre 0 y " + estanteria.GetLength(0));
                }

                return precioTotal;
            }
        }

        static void Main(string[] args)
        {
            Almacen a = new Almacen();
            Bebida b;

            for (int i = 0; i < 10; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        b = new AguaMineral("manantial1", 1.5, 5, "bezoya");
                        a.agregarBebida(b);
                        break;
                    case 1:
                        b = new BebidaAzucarada(0.2, true, 1.5, 10, "Coca Cola");
                        a.agregarBebida(b);
                        break;
                }
            }

            a.mostrarBebidas();
            Console.WriteLine("Precio de todas las bebidas " + a.calcularPrecioBebidas());
            a.eliminarBebida(4);
            a.mostrarBebidas();
            Console.WriteLine("Precio de todas las bebidas" + a.calcularPrecioBebidas());
            Console.WriteLine("Precio de todas las bebidas de la marca bezoya" + a.calcularPrecioBebidas("bezoya"));
            Console.WriteLine("Calcular el precio de la columna 0: " + a.calcularPrecioBebidas(0));
            Console.ReadLine();

        }
    }
}
