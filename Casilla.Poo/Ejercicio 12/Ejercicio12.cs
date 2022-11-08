using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_12
{
    internal class Ejercicio12
    {

        public class Metodos
        {
            public static Random random = new Random();

            public static int generaNumeroAleatorio(int minimo, int maximo)
            {
                int num = random.Next(minimo, maximo);
                return num;
            }
        }

        public class Revolver
        {
            private int posicionBalaActual;
            private int posicionBala;

            public Revolver()
            {
                posicionBalaActual = Metodos.generaNumeroAleatorio(1, 6);
                posicionBala = Metodos.generaNumeroAleatorio(1, 6);
            }

            public bool disparar()
            {
                bool exito = false;

                if (posicionBalaActual == posicionBala)
                {
                    exito = true;
                }
                tambor();

                return exito;

            }

            public void tambor()
            {
                if (posicionBalaActual == 6)
                {
                    posicionBalaActual = 1;
                }
                else
                {
                    posicionBalaActual++;
                }
            }
        }

        public class Jugador
        {

            private int id;
            private string nombre;
            private bool vivo;

            public Jugador(int id)
            {
                this.id = id;
                this.nombre = "Jugador " + id;
                this.vivo = true;
            }

            public void disparar(Revolver r)
            {
                Console.WriteLine(nombre + " se está apuntando");
                if (r.disparar())
                {
                    this.vivo = false;
                    Console.WriteLine(nombre + " murió");
                }
                else
                {
                    Console.WriteLine(nombre + " salvado");
                }
            }

            public bool isVivo()
            {
                return vivo;
            }
        }

        public class Juego
        {
            private Jugador[] jugadores;
            private Revolver revolver;

            public Juego(int numJugadores)
            {
                jugadores = new Jugador[comprobarJugadores(numJugadores)];
                crearJugadores();
                revolver = new Revolver();
            }

            private int comprobarJugadores(int numJugadores)
            {
                Console.WriteLine("Ingrese número de jugadores: ");
                int cantJugadores = Int32.Parse(Console.ReadLine());
                numJugadores = cantJugadores;

                if (!(numJugadores >= 1 && numJugadores <= 6))
                {
                    numJugadores = 6;
                }
                return numJugadores;
            }

            private void crearJugadores()
            {
                for (int i = 0; i < jugadores.Length; i++)
                {
                    jugadores[i] = new Jugador(i + 1);
                }
            }

            public bool finJuego()
            {
                for (int i = 0; i < jugadores.Length; i++)
                {
                    if (!jugadores[i].isVivo())
                    {
                        return true;
                    }
                }
                return false;
            }

            public void ronda()
            {

                for (int i = 0; i < jugadores.Length; i++)
                {
                    jugadores[i].disparar(revolver);
                }

            }

            public void rondaV2()
            {
                for (int i = 0; i < jugadores.Length; i++)
                {
                    if (jugadores[i].isVivo())
                    {
                        jugadores[i].disparar(revolver);
                    }

                }
                return;
            }
        }

        static void Main(string[] args)
        {

            Juego juego = new Juego(2);

            while (!juego.finJuego())
            {
                Console.WriteLine("");
                Console.WriteLine("Ronda 1: ");
                juego.ronda();
                Console.WriteLine("Ronda 2: ");
                juego.rondaV2();
                Console.WriteLine("Ronda 3: ");
                juego.rondaV2();
            }

            Console.WriteLine("");
            Console.WriteLine("Fin del juego.");
            Console.ReadLine();
        }
    }
}
