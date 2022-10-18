using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Ejercicio2
    {

        public class Persona
        {

            private const char SEXO_DEF = 'H';
            public const int INFRAPESO = -1;
            public const int PESO_IDEAL = 0;
            public const int SOBREPESO = 1;

            private string nombre;
            private int edad;
            private string DNI;
            private char sexo;
            private double peso;
            private double altura;

            public Persona()
            {
            }

            public Persona(string nombre, int edad, char sexo)
            {

                this.nombre = nombre;
                this.edad = edad;
                this.sexo = sexo;
            }

            public Persona(string nombre, int edad, char sexo, double peso, double altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.peso = peso;
                this.altura = altura;
                generarDni();
                this.sexo = sexo;
                comprobarSexo();
            }

            public void comprobarSexo()
            {

                if (sexo != 'H' && sexo != 'M')
                {
                    this.sexo = SEXO_DEF;
                }
            }
            public Object generarDni()
            {
                const int divisor = 23;

                int numDNI;
                Random dni = new Random();
                return dni.Next(10000000, 999999999);
                int res = numDNI - (numDNI / divisor * divisor);

                char letraDNI = generaLetraDNI(res);

                DNI = numDNI.ToString() + letraDNI;
            }

            private char generaLetraDNI(int res)
            {
                char[] letras = {'T', 'R', 'W', 'A', 'G', 'M', 'Y',
                'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z',
                'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

                return letras[res];
            }

            public void setNombre(string nombre)
            {
                this.nombre = nombre;
            }

            public void setEdad(int edad)
            {
                this.edad = edad;
            }

            public void setSexo(char sexo)
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
                double pesoActual = peso / Math.Pow(altura, 2);
                if (pesoActual >= 20 && pesoActual <= 25)
                {
                    return PESO_IDEAL;
                }
                else if (pesoActual < 20)
                {
                    return INFRAPESO;
                }
                else
                {
                    return SOBREPESO;
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

            public string toString()
            {
                string sexo;
                if (this.sexo == 'H')
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
            
            public static void MuestraMensajePeso(Persona peso)
            {
                var IMC = peso.calcularIMC();
                switch (IMC)
                {
                    case Persona.PESO_IDEAL:
                        Console.WriteLine("La persona esta en su peso ideal");
                        break;
                    case Persona.INFRAPESO:
                        Console.WriteLine("La persona esta por debajo de su peso ideal");
                        break;
                    case Persona.SOBREPESO:
                        Console.WriteLine("La persona esta por encima de su peso ideal");
                        break;
                }
            }
            public static void MuestraMayorDeEdad(Persona p)
            {
                if (p.esMayorDeEdad())
                {
                    Console.WriteLine("La persona es mayor de edad");
                }
                else
                {
                    Console.WriteLine("La persona no es mayor de edad");
                }
            }

            public static void Main(String[] args)
            {

                Console.Write("Introduce el nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Introduce la edad: ");
                int edad = Int32.Parse(Console.ReadLine());
                Console.Write("Introduce el sexo: ");
                char sexo = Console.ReadLine()[0];
                Console.Write("Introduce el peso: ");
                double peso = Double.Parse(Console.ReadLine());
                Console.Write("Introduce la altura: ");
                double altura = Double.Parse(Console.ReadLine());
                Console.Clear();

                var persona1 = new Persona();
                var persona2 = new Persona(nombre, edad, sexo);
                var persona3 = new Persona(nombre, edad, sexo, peso, altura);
                persona1.setNombre("Mauro");
                persona1.setEdad(26);
                persona1.setSexo('H');
                persona1.setPeso(80);
                persona1.setAltura(1.73);
                persona2.setPeso(90.5);
                persona2.setAltura(1.74);
                Console.WriteLine("Persona1");

                MuestraMensajePeso(persona1);
                MuestraMayorDeEdad(persona1);
                Console.WriteLine(persona1.toString());
                Console.WriteLine("Persona2");
                MuestraMensajePeso(persona2);
                MuestraMayorDeEdad(persona2);
                Console.WriteLine(persona2.toString());
                Console.WriteLine("Persona3");
                MuestraMensajePeso(persona3);
                MuestraMayorDeEdad(persona3);
                Console.WriteLine(persona3.toString());
                Console.ReadKey();
            }

        }
    }
}

