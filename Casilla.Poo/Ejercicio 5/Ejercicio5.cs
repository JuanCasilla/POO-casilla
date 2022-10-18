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
                Console.WriteLine("{0} tiene {1} horas estimadas de uso, spertenece al genero {2} y fue desarrollado por {3}", titulo, horasEstimadas, genero, compania);
            }

            public void MostrarInfoJuegoMasHorasEstimadas()
            {
                Console.WriteLine("{0} tiene {1} horas estimadas de uso, spertenece al genero {2} y fue desarrollado por {3}", titulo, horasEstimadas, genero, compania);
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

            //Ejemeplo abreviado de get/set
            // temporadas {get;set;} // temporadas {get;set;} = algun valor
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
                Console.WriteLine("{0} fue creado por {1} tiene {2} temporadas y pertenece al genero {3}", titulo, creador, temporadas, genero);
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

                // Series
                Serie serie1 = new Serie("Spider-man", "Stan Lee", 1, "Accion");
                Serie serie2 = new Serie("Iron-man", "Stan Lee", 5, "Accion");
                Serie serie3 = new Serie("Hawkeye", "Stan Lee", 6, "Accion");
                Serie serie4 = new Serie("The Boys", "Marvel", 4, "Accion");
                Serie serie5 = new Serie("Invincible", "Marvel", 2, "Super Heroes");
                // Videojuegos
                videosJuego juego1 = new videosJuego("Killzone", 12, "Disparos", "Guerrilla Games");
                videosJuego juego2 = new videosJuego("Valorant", 17, "Accion", "Riot Games");
                videosJuego juego3 = new videosJuego("CSGO", 8, "Disparos", "Valve");
                videosJuego juego4 = new videosJuego("Call of Duty", 13, "Disparos", "Activision");
                videosJuego juego5 = new videosJuego("DOOM Eternal", 23, "Disparos", "Bethesda");


                Serie[] series = { serie1, serie2, serie3, serie4, serie5 };
                videosJuego[] videojuegos = { juego1, juego2, juego3, juego4, juego5 };



                // Juegos
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

                Console.WriteLine("Los juegos entragados son: {0}", juegosEntregado);
                Console.WriteLine("Los juegos no entregados son: {0}", juegosNoEntregado);
                Console.WriteLine("Las series entragados son: {0}", serieEntregado);
                Console.WriteLine("Los series no entregados son: {0}", serieNoEntregado);
                Console.WriteLine("Los videos juegos con mas horas estimadas son: ");

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
