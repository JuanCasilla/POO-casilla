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

            private int preciodef = 100;
            private string colordef = "blanco";
            private string consumodef = "F";
            private int pesodef = 5;

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

            public int precioFinal(int precio)
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

            public Lavadora()
            {
                this.carga = cargadef;
            }


            public Lavadora(int precio, int peso) : base(precio, peso)
            {
                this.Precio = precio;
                this.Peso = peso;
            }

            public Lavadora() : base()

        }

        static void Main(string[] args)
        {
        }

    }
}
