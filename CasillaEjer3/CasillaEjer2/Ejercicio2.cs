using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
                this.DNI = generarDNI();
                this.sexo = sexo;
                peso = 0;
                altura = 0;

            }

            public Persona(string nombre, int edad, string dni, string sexo, int peso, double altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.DNI = generarDNI();
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

            public bool esMayorDeEdad()
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

            public string ImpPersona()
            {
                string sexo;
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

            public string generarDNI()
            {
                int divisor = 23;

                Random randDNI = new Random();
                int numDNI = randDNI.Next((100000000 - 10000000) + 10000000);
                int res = numDNI - (numDNI / divisor * divisor);
                char resCHAR = (char)res;

                char letraDNI = LetraDNI(resCHAR);

                return DNI = numDNI.ToString() + letraDNI;
            }

            private char LetraDNI(char res)
            {
                char[] letras = {'T', 'R', 'W', 'A', 'G', 'M', 'Y',
            'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z',
            'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

                return letras[res];
            }
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
            double altura1 = Double.Parse(Console.ReadLine());

            Persona persona1, persona2, persona3;

            persona1 = new Persona(nombre1, edad1, "", sexo1, peso1, altura1);
            persona2 = new Persona(nombre1, edad1, "", sexo1, 70, 1.92);
            persona3 = new Persona();

            persona3.setNombre("Carla");
            persona3.setEdad(50);
            persona3.setSexo("F");
            persona3.setPeso(59);
            persona3.setAltura(1.66);

            Console.WriteLine("\n");

            Console.WriteLine(persona1.ImpPersona());
            MensajePeso(persona1);
            MensajeEdad(persona1);
            Console.WriteLine("\n");

            Console.WriteLine(persona2.ImpPersona());
            MensajePeso(persona2);
            MensajeEdad(persona2);
            Console.WriteLine("\n");

            Console.WriteLine(persona3.ImpPersona());
            MensajePeso(persona3);
            MensajeEdad(persona3);

            Console.ReadKey();

        }

        public static void MensajePeso(Persona p)
        {
            int IMC = p.calcularIMC();
            if (IMC == 0)
            {
                Console.WriteLine("Esta en peso ideal");
            }
            else if (IMC == 1)
            {
                Console.WriteLine("Arriba de su peso ideal");
            }
            else
            {
                Console.WriteLine("Abajo de su peso ideal");
            }
        }

        public static void MensajeEdad(Persona p)
        {
            if (p.esMayorDeEdad())
            {
                Console.WriteLine("Es mayor de edad");
            }
            else
            {
                Console.WriteLine("No es mayor de edad");
            }
        }
    }
}