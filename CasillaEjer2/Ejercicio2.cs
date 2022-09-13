using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
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
            private double peso;
            private double altura;

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
                this.DNI = dni;
                this.sexo = sexo;
                this.peso = peso;
                this.altura = altura;
            }

            public void setNombre(String nombre)
            {
                this.nombre = nombre;
            }

            public void setEdad(int edad)
            {
                this.edad = edad;
            }

            public void setSexo(string sexo)
            {
                this.sexo = sexo;
            }

            public void setPeso(double peso)
            {
                this.peso = peso;
            }

            public void setAltura(double altura)
            {
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
                bool mayor = false;
                if (edad >= 18)
                {
                    mayor = true;
                }
                return mayor;
            }

            public void comprobarSexo()
            {
                if (sexo != "H" && sexo != "M")
                {
                    this.sexo = sexodef;
                }
            }

            public String toString()
            {
                String sexo;
                if (this.sexo == "H")
                {
                    sexo = "Hombre";
                }
                else
                {
                    sexo = "Mujer";
                }
                return "Informacion de la persona:\n"
                        + "Nombre: " + nombre + "\n"
                        + "Sexo: " + sexo + "\n"
                        + "Edad: " + edad + " años\n"
                        + "DNI: " + DNI + "\n"
                        + "Peso: " + peso + " kg\n"
                        + "Altura: " + altura + " metros\n";
            }

            public void generarDNI(){
                int divisor = 23;

                Random randDNI = new Random();
                int numDNI = randDNI.Next((100000000 - 10000000) + 10000000);
                int res = numDNI - (numDNI / divisor * divisor);
                char resCHAR = (char)res;

                char letraDNI = LetraDNI(resCHAR);

                DNI = numDNI.ToString() + letraDNI;
            }

            private char LetraDNI(char res)
            {
                char[] letras = {'T', 'R', 'W', 'A', 'G', 'M', 'Y',
            'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z',
            'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};
                
                return letras[res];
            }

            static void Main(string[] args)
            {

                Console.Write("Nombre: ");
                string nombre1 = Console.ReadLine();
                Console.Write("Edad: ");
                int edad1 = int.Parse(Console.ReadLine());
                Console.Write("Sexo: ");
                string sexo1 = Console.ReadLine();
                Console.Write("Peso: ");
                int peso1 = int.Parse(Console.ReadLine());
                Console.Write("Altura: ");
                int altura1 = int.Parse(Console.ReadLine());

                Persona persona1, persona2, persona3;

                string dni1 = Persona.generarDNI();

                persona1 = new Persona(nombre1, edad1, persona1.DNI, sexo1, peso1, altura1);
                persona2 = new Persona(nombre1, edad1, persona2.DNI, sexo1);
                persona3 = new Persona();

                persona2.setPeso(100);
                persona2.setAltura(1.92);

                persona3.setNombre("Pedro");
                persona3.setEdad(20);
                persona3.setSexo("H");
                persona3.setPeso(80);
                persona3.setAltura(1.73);
            }
        }
    }
}