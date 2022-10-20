using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Ejercicio5
    {
        interface Entregable
        {
            void entregar();
            void devolver();
            bool isEntregado();
            void compareTo(Object e);
        }

        public class videosJuego : Entregable
        {
            public string titulo { get; set; }

            public int horasEstimadas { get; set; } = 10;

            public bool entregado = false;

            public string genero { get; set; }

            public string compania { get; set; }

            public videosJuego()
            {
            }

            public videosJuego(string titulo, int horasestimadas)
            {
                this.titulo = titulo;
                this.horasEstimadas = horasestimadas;
            }

            public videosJuego(string titulo, int horasestimadas, string genero, string compania)
            {
                this.titulo = titulo;
                this.horasEstimadas = horasestimadas;
                this.genero = genero;
                this.compania = compania;
            }

            public void MostrarInfoJuego()
            {
                Console.WriteLine("Juego: {0}. Horas estimadas: {1}. Género: {2}. Desarrollador: {3}.", titulo, horasEstimadas, genero, compania);
            }

            public void MostrarInfoJuegoMasHorasEstimadas()
            {
                Console.WriteLine("Juego: {0}. Horas estimadas: {1}. Género: {2}. Desarrollador: {3}.", titulo, horasEstimadas, genero, compania);
            }

            public void entregar()
            {
                this.entregado = true;
            }

            public void devolver()
            {
                entregado = false;
            }

            public bool isEntregado()
            {
                return entregado;
            }

            public void compareTo(Object e)
            {
                var videojuego = (videosJuego)e;

                if (videojuego.horasEstimadas > 10)
                {
                    MostrarInfoJuegoMasHorasEstimadas();
                }
            }
        }

        public class Serie : Entregable
        {
            private string titulo;

            private int temporadas = 3;

            private bool entregado = false;

            private string genero;

            private string creador;

            public string Titulo { get { return titulo; } }

            public int Temporadas { get { return temporadas; } }

            public bool Entregado { get { return entregado; } }

            public string Genero { get { return genero; } }

            public string Creador { get { return creador; } }

            public Serie()
            {
            }

            public Serie(string titulo, string creador)
            {
                this.titulo = titulo;
                this.creador = titulo;
            }

            public Serie(string titulo, string creador, int temporadas, string genero)
            {
                this.titulo = titulo;
                this.creador = creador;
                this.temporadas = temporadas;
                this.genero = genero;
            }

            public void MostrarInfoSerie()
            {
                Console.WriteLine("Nombre: {0}. Creador: {1}. Temporadas: {2}. Genero: {3}.", titulo, creador, temporadas, genero);
            }

            public void entregar()
            {
                entregado = true;
            }

            public void devolver()
            {
                entregado = false;
            }

            public bool isEntregado()
            {
                return entregado;
            }

            public void compareTo(Object e)
            {
                var serie = (Serie)e;

                if (serie.Temporadas > 3)
                {
                    MostrarInfoSerie();
                }
            }

            static void Main(string[] args)
            {

                Serie serie1 = new Serie("Daredevil", "Stan Lee", 3, "Acción");
                Serie serie2 = new Serie("She-Hulk", "Stan Lee", 1, "Acción");
                Serie serie3 = new Serie("Chainsaw Man", "Tatsuki Fujimoto", 1, "Acción");
                Serie serie4 = new Serie("Game Of Thrones", "George R. R. Martin", 8, "Acción");
                Serie serie5 = new Serie("Spy X Family", "Tatsuya Endo", 2, "Acción");
                videosJuego juego1 = new videosJuego("GTA V", 20, "Disparos", "Rockstar Games");
                videosJuego juego2 = new videosJuego("League Of Legends", 10, "Accion", "Riot Games");
                videosJuego juego3 = new videosJuego("Untitled Goose Game", 4, "Aventura", "House House");
                videosJuego juego4 = new videosJuego("Hades", 18, "Roguelike", "Supergiant Games");
                videosJuego juego5 = new videosJuego("It Takes Two", 15, "Aventura", "Hazelight Studios");


                Serie[] series = { serie1, serie2, serie3, serie4, serie5 };
                videosJuego[] videojuegos = { juego1, juego2, juego3, juego4, juego5 };

                Console.WriteLine("Videojuegos: ");
                Console.WriteLine("");
                juego1.entregar();
                juego1.MostrarInfoJuego();
                Console.WriteLine("");
                juego2.MostrarInfoJuego();
                juego2.devolver();
                Console.WriteLine("");
                juego3.MostrarInfoJuego();
                juego3.entregar();
                Console.WriteLine("");
                juego4.MostrarInfoJuego();
                juego4.isEntregado();
                Console.WriteLine("");
                juego5.devolver();
                juego5.MostrarInfoJuego();
                Console.WriteLine("");
                Console.WriteLine("");


                Console.WriteLine("Series:");
                Console.WriteLine("");
                serie1.devolver();
                serie1.MostrarInfoSerie();
                Console.WriteLine("");
                serie2.MostrarInfoSerie();
                serie2.entregar();
                Console.WriteLine("");
                serie3.MostrarInfoSerie();
                serie3.devolver();
                Console.WriteLine("");
                serie4.MostrarInfoSerie();
                serie4.isEntregado();
                Console.WriteLine("");
                serie5.entregar();
                serie5.MostrarInfoSerie();
                Console.WriteLine("");

                int juegosEntregado = 0;
                int juegosNoEntregado = 0;
                int serieEntregado = 0;
                int serieNoEntregado = 0;

                for (var i = 0; i < videojuegos.Length; i++)
                {
                    if (videojuegos[i].entregado)
                    {
                        juegosEntregado = juegosEntregado + 1;
                    }
                    else
                    {
                        juegosNoEntregado = juegosNoEntregado + 1;
                    }
                }

                for (var i = 0; i < series.Length; i++)
                {
                    if (series[i].Entregado)
                    {
                        serieEntregado = serieEntregado + 1;
                    }
                    else
                    {
                        serieNoEntregado = serieNoEntregado + 1;
                    }
                }

                Console.WriteLine("Juegos entregados: {0}", juegosEntregado);
                Console.WriteLine("Juegos no entregados: {0}", juegosNoEntregado);
                Console.WriteLine("Series entregadas: {0}", serieEntregado);
                Console.WriteLine("Series no entregadas: {0}", serieNoEntregado);
                Console.WriteLine("Los juegos con mas horas estimadas son: ");

                for (int i = 0; i < videojuegos.Length; i++)
                {
                    videojuegos[i].compareTo(videojuegos[i]);
                }


                Console.WriteLine("Las series con mas horas estimadas son: ");

                for (int i = 0; i < series.Length; i++)
                {
                    series[i].compareTo(series[i]);
                }

                Console.ReadKey();

            }
        }
    }
}
