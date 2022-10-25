using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
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
            this.consumoDeafault = consumodef;
            this.colorDefault = colordef;
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

            public Television(double resolucion, bool sintonizadorTDT) : base()
            {
                this.resolucion = resolucion;
                this.sintonizadorTDT = sintonizadorTDT;
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

        static void Main(string[] args)
        {
<<<<<<< HEAD
=======
            Electrodomestico[] electrodomesticos = new Electrodomestico[11];
            Electrodomestico electro1 = new Electrodomestico(1500, 20, 'A', "Negro");
            electro1 = new Television(50, false);

            Electrodomestico electro2 = new Electrodomestico(2000, 30, 'C', "Rojo");

            Electrodomestico electro3 = new Electrodomestico(750, 15, 'D', "Blanco");
            electro3 = new Television(32, true);

            Electrodomestico electro4 = new Electrodomestico(15000, 50, 'B', "Azul");
            electro4 = new Lavadora(15000, 50);

            Electrodomestico electro5 = new Electrodomestico(1250, 10, 'B', "Naranja");
            electro5 = new Television(36, false);

            Electrodomestico electro6 = new Electrodomestico(5780, 5, 'F', "Verde");
            electro6 = new Lavadora(5780, 5);

            Electrodomestico electro7 = new Electrodomestico(574.50, 90, 'E', "Violeta");
            electro7 = new Television(50, true);

            Electrodomestico electro8 = new Electrodomestico(1450.50, 45, 'C', "Fucsia");
            electro8 = new Lavadora(1450.50, 45);

            Electrodomestico electro9 = new Electrodomestico(8500, 68, 'D', "Rosa");
            electro9 = new Television(37, false);

            Electrodomestico electro10 = new Electrodomestico(9999, 85, 'A', "Amarillo");
            electro10 = new Lavadora(9999, 85);

            Electrodomestico electro11 = new Television(5676.27, 56);
            electrodomesticos[0] = electro1;
            electrodomesticos[1] = electro2;
            electrodomesticos[2] = electro3;
            electrodomesticos[3] = electro4;
            electrodomesticos[4] = electro5;
            electrodomesticos[5] = electro6;
            electrodomesticos[6] = electro7;
            electrodomesticos[7] = electro8;
            electrodomesticos[8] = electro9;
            electrodomesticos[9] = electro10;
            electrodomesticos[10] = electro11;


            for (int i = 0; i < electrodomesticos.Length; i++)
            {
                electrodomesticos[i].precioBase = electrodomesticos[i].precioFinal();
            }

>>>>>>> d57cb9ab7bda8c372d3fb6edd5420b3142cd650c
            double sumaElectrodomesticos = 0;
            double sumaLavadora = 0;
            double sumaTelevision = 0;

<<<<<<< HEAD
            Electrodomestico electro1, electro2, electro3, electro4, electro5, electro6, electro7, electro8, electro9, electro10;

            electro1 = new Television(27, true, 2400, 16, 'A', "Negro");
            electro2 = new Television(48, false, 7500, 30, 'C', "Gris");
            electro3 = new Television(32, false, 4000, 20, 'D', "Negro");
            electro4 = new Television(24, true, 2000, 14, 'C', "Negro");
            electro5 = new Television(80, true, 15000, 30, 'A', "Gris");

            electro6 = new Lavadora(9000, 50, 23, 'F', "Rojo");
            electro7 = new Lavadora(2400.50, 30, 50, 'D', "Verde");
            electro8 = new Lavadora(2500, 60, 30, 'F', "Azul");
            electro9 = new Lavadora(2600.700, 50, 40, 'C', "Blanco");
            electro10 = new Lavadora(1234, 50, 45, 'A', "Azul");

            Electrodomestico[] electrodomesticos = { electro1, electro2, electro3, electro4, electro5, electro6, electro7, electro8, electro9, electro10 };

            Console.WriteLine("Precio Televisiones: ");

=======
>>>>>>> d57cb9ab7bda8c372d3fb6edd5420b3142cd650c
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
            Console.WriteLine("Televisiones precio total: " + sumaTelevision);

            Console.WriteLine("");
            Console.WriteLine("Precio Lavadoras: ");

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
            Console.WriteLine("Lavadoras precio total: " + sumaLavadora);
            Console.WriteLine("");
            Console.WriteLine("Total de electrodomesticos: " + sumaElectrodomesticos);

            Console.ReadLine();
        }
    }
}