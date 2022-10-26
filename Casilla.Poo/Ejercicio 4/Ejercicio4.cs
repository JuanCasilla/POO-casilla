using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio04.Electrodomestico;

namespace Ejercicio04
{
    public class Electrodomestico
    {
        public string colorDefault { get; set; } = "blanco";
        public char consumoDeafault { get; set; } = 'F';
        public double precioDeafault { get; set; } = 100;


        public double pesoDefault { get; set; } = 5;
        public double precioBase;
        public string color;
        public char consumoEnergetico;
        public double peso;


        public void comprobarColor(string color)
        {
            string[] colores = { "blanco", "negro", "rojo", "azul", "gris" };
            bool encontrado = false;

            for (int i = 0; i < colores.Length && !encontrado; i++)
            {

                if (colores[i].Equals(color))
                {
                    encontrado = true;
                }
            }

            if (encontrado)
            {
                this.color = color;
            }
            else
            {
                this.color = colorDefault;
            }
        }

        public void comprobarConsumoEnergetico(char consumoEnergetico)
        {
            if (consumoEnergetico >= 65 && consumoEnergetico <= 70)
            {
                this.consumoEnergetico = consumoEnergetico;
            }
            else
            {
                this.consumoEnergetico = consumoDeafault;
            }
        }

        public double precioFinal()
        {
            double plus = 0;
            switch (consumoEnergetico)
            {
                case 'A':
                    plus += 100;
                    break;
                case 'B':
                    plus += 80;
                    break;
                case 'C':
                    plus += 60;
                    break;
                case 'D':
                    plus += 50;
                    break;
                case 'E':
                    plus += 30;
                    break;
                case 'F':
                    plus += 10;
                    break;
            }
            if (peso >= 0 && peso < 19)
            {
                plus += 10;
            }
            else if (peso >= 20 && peso < 49)
            {
                plus += 50;
            }
            else if (peso >= 50 && peso <= 79)
            {
                plus += 80;
            }
            else if (peso >= 80)
            {
                plus += 100;
            }
            return precioBase += plus;
        }

        public Electrodomestico()
        {
        }

        public Electrodomestico(double precioBase, double peso, char consumodef, string colordef)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            consumoDeafault = consumodef;
            colorDefault = colordef;
        }
    }

    public class Television : Electrodomestico
    {
        double resolucion = 20;

        bool sintonizadorTDT = false;

        public Television()
        {
        }

        public Television(double precio, double peso)
        {
            this.precioBase = precio;
            this.peso = peso;
        }

        public Television(double resolucion, bool sintonizadorTDT, double precioBase, double peso, char consumodef, string colordef) : base(precioBase, peso, consumodef, colordef)
        {
            this.resolucion = resolucion;
            this.sintonizadorTDT = sintonizadorTDT;
        }

        public double getResolucion()
        {
            return resolucion;
        }

        public bool getSintonizadorTDT()
        {
            return sintonizadorTDT;
        }

        public void PrecioFinal()
        {
            if (resolucion > 40)
            {
                precioBase = (precioBase * 0.3) + precioBase;
            }

            if (sintonizadorTDT == true)
            {
                this.precioBase += 502;
            }
        }
    }

    public class Lavadora : Electrodomestico
    {
        public int carga = 5;

        public Lavadora()
        {

        }

        public Lavadora(double precio, int peso, int carga, char consumodef, string colordef) : base()
        {
            precioBase = precio;
            this.peso = peso;
            this.carga = carga;
            consumoDeafault = consumodef;
            colorDefault = colordef;
        }

        public int getCarga()
        {
            return carga;
        }

        public void PrecioFinal()
        {
            if (carga > 30)
            {
                precioBase += 50;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            double sumaElectrodomesticos = 0;
            double sumaLavadora = 0;
            double sumaTelevision = 0;

            Electrodomestico electro1 = new Television(27.56, true, 5000, 24, 'A', "Blanco");
            Electrodomestico electro3 = new Television(5000.50, true, 8000, 30, 'A', "Azul");
            Electrodomestico electro5 = new Television(30.70, true, 10000, 20, 'E', "Rojo");
            Electrodomestico electro7 = new Television(40.50, false, 6000, 45, 'B', "Verde");
            Electrodomestico electro9 = new Television(50.5, true, 5000, 45, 'A', "Rojo");

            Electrodomestico electro2 = new Lavadora(5000, 50, 23, 'F', "Rojo");
            Electrodomestico electro4 = new Lavadora(5000.50, 30, 50, 'D', "Verder");
            Electrodomestico electro6 = new Lavadora(5000, 60, 30, 'F', "Rojo");
            Electrodomestico electro8 = new Lavadora(4500.700, 50, 40, 'C', "Azul");
            Electrodomestico electro10 = new Lavadora(9999, 50, 45, 'A', "Blanco");

            Electrodomestico[] electrodomesticos = { electro1, electro2, electro3, electro4, electro5, electro6, electro7, electro8, electro9, electro10 };

            Console.WriteLine("Television precio final");

            for (int i = 0; i < electrodomesticos.Length; i++)
            {
                if (electrodomesticos[i].GetType() == typeof(Television))
                {
                    var aux = (Television)electrodomesticos[i];
                    aux.PrecioFinal();
                    electrodomesticos[i].precioFinal();
                    sumaTelevision += electrodomesticos[i].precioBase;
                    Console.WriteLine(electrodomesticos[i].precioBase);
                    sumaElectrodomesticos += electrodomesticos[i].precioBase;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("La suma de las televisiones es " + sumaTelevision);

            Console.WriteLine("");
            Console.WriteLine("Lavadoras precio final");

            for (int i = 0; i < electrodomesticos.Length; i++)
            {
                if (electrodomesticos[i].GetType() == typeof(Lavadora))
                {
                    Console.WriteLine(electrodomesticos[i].precioBase);
                    sumaLavadora += electrodomesticos[i].precioBase;
                    sumaElectrodomesticos += electrodomesticos[i].precioBase;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("La suma de las lavadoras es de " + sumaLavadora);
            Console.WriteLine("La suma total de todos los electrodomesticos es: " + sumaElectrodomesticos);
            Console.ReadKey();
        }
    }
}
