using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_6
{
    internal class Ejercicio6
    {

        class Libro
        {
            public string ibsn { get; set; }
            public string titulo { get; set; }
            public string autor { get; set; }
            public int numPaginas { get; set; }

            public Libro()
            {
            }

            public Libro(string ibsn, string titulo, string autor, int numPaginas)
            {
                this.ibsn = ibsn;
                this.titulo = titulo;
                this.autor = autor;
                this.numPaginas = numPaginas;
            }

            public void mostrarInfo()
            {
                Console.WriteLine("Libro: {0}. Ibsn: {1}. Autor: {2}. Paginas: {3}", titulo, ibsn, autor, numPaginas);
            }
        }

        static void Main(string[] args)
        {

            Libro libro1 = new Libro("0000000001", "Chainsaw Man", "Tatsuki Fujimoto", 211);
            Libro libro2 = new Libro("0000000002", "Oyasumi Punpun", "Inio Asano", 400);
            libro1.mostrarInfo();
            libro2.mostrarInfo();

            if (libro1.numPaginas > libro2.numPaginas)
            {
                Console.WriteLine("El Libro con mas paginas es {0}", libro1.titulo);
            }
            else
            {
                Console.WriteLine("El libro con mas paginas es {0}", libro2.titulo);
            }
            Console.ReadKey();
        }
    }
}
