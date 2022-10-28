using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_9
{
    internal class Ejercicio9
    {

        public class Espectador
        {
            private string nombre;
            private int edad;
            private double dinero;

            public Espectador(string nombre, int edad, double dinero)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.dinero = dinero;
            }

            public string getNombre()
            {
                return nombre;
            }

            public void setNombre(string nombre)
            {
                this.nombre = nombre;
            }
            public int getEdad()
            {
                return edad;
            }
            public void setEdad(int edad)
            {
                this.edad = edad;
            }
            public double getDinero()
            {
                return dinero;
            }
            public void setDinero(double dinero)
            {
                this.dinero = dinero;
            }

            public void pagar(double precio)
            {
                dinero -= precio;
            }

            public bool tieneEdad(int edadMinima)
            {
                return edad >= edadMinima;
            }

            public bool tieneDinero(double precioEntrada)
            {
                return dinero >= precioEntrada;
            }
        }

        public class Asiento
        {
            private char letra;
            private int fila;
            private Espectador espectador;

            public Asiento(char letra, int fila)
            {
                this.letra = letra;
                this.fila = fila;
                espectador = null;
            }

            public char getLetra()
            {
                return letra;
            }
            public void setLetra(char letra)
            {
                this.letra = letra;
            }
            public int getFila()
            {
                return fila;
            }
            public void setFila(int fila)
            {
                this.fila = fila;
            }

            public Espectador getEspectador()
            {
                return espectador;
            }

            public void setEspectador(Espectador espectador)
            {
                this.espectador = espectador;
            }

            public bool ocupado()
            {
                return espectador != null;
            }
        }

        public class Pelicula
        {

            private string titulo;
            private int duracion;
            private int edadMinima;
            private string director;

            public Pelicula(string titulo, int duracion, int edadMinima, string director)
            {
                this.titulo = titulo;
                this.duracion = duracion;
                this.edadMinima = edadMinima;
                this.director = director;
            }

            public string getTitulo()
            {
                return titulo;
            }
            public void setTitulo(string titulo)
            {
                this.titulo = titulo;
            }
            public int getDuracion()
            {
                return duracion;
            }
            public void setDuracion(int duracion)
            {
                this.duracion = duracion;
            }
            public int getEdadMinima()
            {
                return edadMinima;
            }
            public void setEdadMinima(int edadMinima)
            {
                this.edadMinima = edadMinima;
            }
            public string getDirector()
            {
                return director;
            }
            public void setDirector(string director)
            {
                this.director = director;
            }
        }

        public class Cine
        {
            private Asiento[,] asientos;
            private double precio;
            private Pelicula pelicula;

            public Cine(int filas, int columnas, double precio, Pelicula pelicula)
            {
                asientos = new Asiento[filas,columnas];
                this.precio = precio;
                this.pelicula = pelicula;
                rellenaButacas();
            }

            public Asiento[,] getAsientos()
            {
                return asientos;
            }
            public void setAsientos(Asiento[,] asientos)
            {
                this.asientos = asientos;
            }
            public double getPrecio()
            {
                return precio;
            }
            public void setPrecio(double precio)
            {
                this.precio = precio;
            }
            public Pelicula getPelicula()
            {
                return pelicula;
            }
            public void setPelicula(Pelicula pelicula)
            {
                this.pelicula = pelicula;
            }

            private void rellenaButacas()
            {
                int fila = asientos.Length;
                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    for (int j = 0; j < asientos.GetLength(1); j++)
                    {
                        asientos[i,j] = new Asiento((char)('A' + j), fila);
                    }
                    fila--;
                }
            }

            public bool haySitio()
            {

                int contador = 0;

                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    for (int j = 0; j < asientos.GetLength(1); j++)
                    {
                        if (!asientos[i,0+contador].ocupado())
                        {
                            return true;
                        }
                    }
                    contador++;
                }
                return false;
            }

            public bool haySitioButaca(int fila, char letra)
            {
                return getAsiento(fila, letra).ocupado();
            }

            public bool sePuedeSentar(Espectador e)
            {
                return e.tieneDinero(precio) && e.tieneEdad(pelicula.getEdadMinima());
            }

            public void sentar(int fila, char letra, Espectador e)
            {
                getAsiento(fila, letra).setEspectador(e);
            }

            public Asiento getAsiento(int fila, char letra)
            {
                return asientos[asientos.GetLength(0) - fila - 1 , letra - 'A'];
            }
            public int getFilas()
            {
                return asientos.GetLength(1);
            }
            public int getColumnas()
            {
                return asientos.GetLength(0);
            }

            public void mostrar()
            {
                Console.WriteLine("Información cine");
                Console.WriteLine("Pelicula reproducida: " + pelicula);
                Console.WriteLine("Precio entrada: " + precio);
                Console.WriteLine("");

                int contador = 0;

                for (int i = 0; i < asientos.Length; i++)
                {
                    for (int j = 0; j < asientos.GetLength(0); j++)
                    {
                        Console.WriteLine(asientos[i,0+contador]);
                    }
                    Console.WriteLine("");
                    contador++;
                }
            }
        }

        public class Metodos
        {
            public static string[] nombres = {"Fernando", "Nacho", "Zeus", "ELfrasco"};
            
            public static Random random = new Random();
            public static int generaNumeroEnteroAleatorio(int minimo, int maximo)
            {
                int num = random.Next(minimo , maximo);
                return num;
            }

        }

        static void Main(string[] args)
        {

            Pelicula pelicula = new Pelicula("Avengers: Endgame", 200, 13, "Kevin Feige");

            Console.WriteLine("Introduce el numero de filas");
            
            int filas = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el numero de columnas");
            int columnas = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el precio de la entrada de cine");
            double precio = Int32.Parse(Console.ReadLine());

            Cine cine = new Cine(filas, columnas, precio, pelicula);

            Console.WriteLine("Introduce el numero de espectadores a crear");
            int numEspectadores = Int32.Parse(Console.ReadLine());

            Espectador e;
            int fila;
            char letra;

            Console.WriteLine("Espectadores generados: ");
            for (int i = 0; i < numEspectadores && cine.haySitio(); i++) {

                e = new Espectador(
                        Metodos.nombres[Metodos.generaNumeroEnteroAleatorio(0, Metodos.nombres.Length - 1)],
                        Metodos.generaNumeroEnteroAleatorio(10, 30),
                        Metodos.generaNumeroEnteroAleatorio(1, 10));

                Console.WriteLine(e.getNombre());
                do
                {
                    fila = Metodos.generaNumeroEnteroAleatorio(0, cine.getFilas() - 1);
                    letra = (char)Metodos.generaNumeroEnteroAleatorio('A', 'A' + (cine.getColumnas() - 1));
                } while (cine.haySitioButaca(fila, letra));

                if (cine.sePuedeSentar(e))
                {
                    e.pagar(cine.getPrecio());
                    cine.sentar(fila, letra, e);
                }
            }

            Console.WriteLine("");
            cine.mostrar();
            Console.ReadLine();

        }
    }
}