using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casilla456
{
    internal class Ejer4
    {
        public class Electrodomestico
        {

            private int precio;
            private string color;
            private string consumo;
            private int peso;

            public int preciodef = 100;
            public string colordef = "blanco";
            public string consumodef = "F";
            public int pesodef = 5;

            public string consumoA = "A";
            public string consumoB = "B";
            public string consumoC = "C";
            public string consumoD = "D";
            public string consumoE = "E";
            public string consumoF = "F";

            public int Precio
            {
                set { precio = value; }
                get { return precio; }
            }
            public string Color
            {
                set { color = value; }
                get { return color; } 
            }
            public string Consumo
            {
                set { consumo = value; }
                get { return consumo; }
            }
            public int Peso
            {
                set { peso = value; }
                get { return peso; }
            }

            public Electrodomestico()
            {
                this.precio = preciodef;
                this.color = colordef;
                this.consumo = consumodef;
                this.peso = pesodef;
                comprobarColor(color);
                comprobarConsumoEnergetico(consumo);
            }

            public Electrodomestico(int precio, int peso)
            {
                this.precio = precio;
                this.color = colordef;
                this.consumo = consumodef;
                this.peso = peso;
                comprobarColor(color);
                comprobarConsumoEnergetico(consumo);
            }

            public Electrodomestico(int precio, string color, string consumo, int peso)
            {
                this.precio = precio;
                this.color = color;
                this.consumo = consumo;
                this.peso = peso;
                comprobarColor(color);
                comprobarConsumoEnergetico(consumo);
            }

            private void comprobarConsumoEnergetico(string consumo)
            {
                {
                    string[] consumos = { "A", "B", "C", "D", "E", "F" };
                    bool encontrado = false;

                    for (int i = 0; i < consumos.Length && !encontrado; i++)
                    {
                        if (consumos[i] == (consumo))
                        {
                            encontrado = true;
                        }
                    }
                    encontrado = false;

                    if (encontrado)
                    {
                        consumo = consumodef;
                    }
                }
            }

            private void comprobarColor(string color)
            {
                {
                    string[] colores = { "blanco", "negro", "rojo", "azul", "gris" };
                    bool encontrado = false;

                    for (int i = 0; i < colores.Length && !encontrado; i++)
                    {
                        if (colores[i] == (color))
                        {
                            encontrado = true;
                        }
                    }
                    encontrado = false;

                    if (encontrado)
                    {
                        color = colordef;
                    }
                }
            }

            virtual public int precioFinal(int precio)
            {
                int suma = 0;
                if(consumo == consumoA)
                {
                    suma += 100;
                }
                else if (consumo == consumoB)
                {
                    suma += 80;
                }
                else if(consumo == consumoC)
                {
                    suma += 60;
                }
                else if(consumo == consumoD)
                {
                    suma += 50;
                }
                else if(consumo == consumoE)
                {
                    suma += 30;
                }
                else if(consumo == consumoF)
                {
                    suma += 10;
                }

                if (peso >= 0 && peso < 19)
                {
                    suma += 10;
                }
                else if (peso >= 20 && peso < 49)
                {
                    suma += 50;
                }
                else if (peso >= 50 && peso <= 79)
                {
                    suma += 80;
                }
                else if (peso >= 80)
                {
                    suma += 100;
                }

                return precio+suma;
            }
        }

        public class Lavadora : Electrodomestico
        {

            private int carga;
            public int cargadef = 5;

            public int Carga
            {
                set { carga = value; }
            }

            public Lavadora() : base()
            {
                this.carga = cargadef;
                base.Color = colordef;
                base.Consumo = consumodef;
                base.Peso = pesodef;
                base.Precio = preciodef;
            }

            public Lavadora(int precio, int peso) : base(precio, peso)
            {
                this.Precio = precio;
                this.Peso = peso;
                base.Color = colordef;
                base.Consumo = consumodef;
            }
<<<<<<< HEAD
=======

            public Lavadora(int precio, string color, string consumo, int peso, int carga) : base (precio, color, consumo, peso)
            {
                this.carga = carga;
                base.Color = color;
                base.Consumo = consumo;
                base.Peso = peso;
                base.Precio = precio;
            }

            override public int precioFinal (int precio)
            {
                int suma = 0;
                if (base.Peso > 30)
                {
                    suma += 50;
                }
                return precio + suma;
            }
        }

        public class Television : Electrodomestico
        {

            private int resolucion;
            private bool sintonizadorTDT;
            public int resdef = 20;
            public bool TDTdef = false;

            public bool SintonizadorTDT
            {
                set { sintonizadorTDT = value; }
                get { return sintonizadorTDT; }
            }

            public Television() : base()
            {
                base.Color = colordef;
                base.Consumo = consumodef;
                base.Peso = pesodef;
                base.Precio = preciodef;

            }

            public Television(int precio, int peso) : base(precio, peso)
            {
                this.Precio = precio;
                this.Peso = peso;
                base.Color = colordef;
                base.Consumo = consumodef;
            }

            public Television(int precio, string color, string consumo, int peso, int resolucion, bool sintonizadorTDT) : base(precio, color, consumo, peso)
            {
                base.Precio = precio;
                base.Color = color;
                base.Consumo = consumo;
                base.Peso = peso;
                this.resolucion = resolucion;
                this.sintonizadorTDT = sintonizadorTDT;
            }

            override public int precioFinal(int precio)
            {
                if(resolucion >= 40)
                {
                    precio = precio + ((precio / 100) * 30);
                }
                
                if(sintonizadorTDT)
                {
                    precio = precio + 50;
                }
                return precio;
            }
>>>>>>> 2e97deffdd508f3c96d889e24aba5f56467fd9d1
        }

        static void Main(string[] args)
        {
            Object[] electrodomesticos = new Object[10];
            electrodomesticos[0] = new Lavadora(80, 40);
            electrodomesticos[1] = new Lavadora(80, 40);
            electrodomesticos[2] = new Lavadora(80, 40);

            for (int i = 0; i < electrodomesticos.Length; i++)
            {
                    Console.WriteLine("a");
            }    

            

            Console.ReadKey();
        }

    }
}
