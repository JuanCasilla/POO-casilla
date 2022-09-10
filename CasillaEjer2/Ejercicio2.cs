using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasillaEjer2
{
    internal class Ejercicio2
    {

        public class Persona
        {

            private string nombre;
            private int edad;
            private string DNI;
            private string sexo;
            private int peso;
            private int altura;

            private string sexodef = "H";
            private int infrapeso = -1;
            private int pesoideal = 0;
            private int sobrepeso = 1;

            public Persona()
            {
                nombre = "";
                edad = 0;
                sexo = sexodef;
                peso = 0;
                altura = 0;
            }

            public Persona(string nombre, int edad, string sexo)
            {

                this.nombre = nombre;
                this.edad = edad;
                this.sexo = sexo;
                peso = 0;
                altura = 0;

            }

            public Persona(string nombre, int edad, string dni, string sexo, int peso, int altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                DNI = dni;
                this.sexo = sexo;
                this.peso = peso;
                this.altura = altura;
            }

            public int calcularIMC()
            {
                double pesoactual = peso / (Math.Pow(altura, 2));

                if (pesoactual >= 20 && pesoactual <= 25)
                {
                    return pesoideal;
                }
                else if (peso < 20)
                {
                    return infrapeso;
                }
                else
                {
                    return sobrepeso;
                }
            }

            public bool esMayorDeEdad(int edad)
            {
                return false;
            }

            public void comprobarSexo()
            {
                if (sexo != "H" && sexo != "M")
                {
                    this.sexo = sexodef;
                }
            }

            static void Main(string[] args)
            {

                Persona p1;

                p1 = new Persona();

            }
        }
    }
}