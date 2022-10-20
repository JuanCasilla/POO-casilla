using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_8
{
    public abstract class Persona
    {

        private string nombre;
        private char sexo;
        private int edad;
        private bool asistencia;

        private static string[] NOMBRES_CHICOS = { "Pepe", "Fernando", "Alberto", "Nacho", "Eustaquio" };
        private static string[] NOMBRES_CHICAS = { "Alicia", "Laura", "Clotilde", "Pepa", "Elena" };
        private static int CHICO = 0;
        private static int CHICA = 1;

        public Persona()
        {

            int determinar_sexo = MetodosSueltos.generaNumeroAleatorio(0, 1);


            if (determinar_sexo == CHICO)
            {
                nombre = NOMBRES_CHICOS[MetodosSueltos.generaNumeroAleatorio(0, 4)];
                sexo = 'H';
            }
            else if (determinar_sexo == CHICA)
            {
                nombre = NOMBRES_CHICAS[MetodosSueltos.generaNumeroAleatorio(0, 4)];
                sexo = 'M';
            }

            disponibilidad();
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public char getSexo()
        {
            return sexo;
        }

        public void setSexo(char sexo)
        {
            this.sexo = sexo;
        }

        public int getEdad()
        {
            return edad;
        }

        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public bool isAsistencia()
        {
            return asistencia;
        }
        public void setAsistencia(bool asistencia)
        {
            this.asistencia = asistencia;
        }

        public abstract void disponibilidad();

    }

    public class Constantes
    {

        public static string[] Materias = { "Matematicas", "Filosofia", "Fisica" };

    }

    public class MetodosSueltos
    {
        public static Random random = new Random();

        public static int generaNumeroAleatorio(int minimo - 1, int maximo)
        {
            int num = random.Next(minimo, maximo);
            return num;
        }

    }

    public class Alumno : Persona
    {
        private int nota;

        public Alumno() : base()
        {
            nota = MetodosSueltos.generaNumeroAleatorio(0, 10);

            base.setEdad(MetodosSueltos.generaNumeroAleatorio(12, 15));

        }

        public int getNota()
        {
            return nota;
        }

        public void setNota(int nota)
        {
            this.nota = nota;
        }

        public override void disponibilidad()
        {

            int prob = MetodosSueltos.generaNumeroAleatorio(0, 100);

            if (prob < 50)
            {
                base.setAsistencia(false);
            }
            else
            {
                base.setAsistencia(true);
            }

        }

        public class Profesor : Persona
        {

            private string materia;
            public Profesor() : base()
            {

                base.setEdad(MetodosSueltos.generaNumeroAleatorio(25, 50));

                materia = Constantes.Materias[MetodosSueltos.generaNumeroAleatorio(0, 2)];
            }

            public string getMateria()
            {
                return materia;
            }
            public void setMateria(string materia)
            {
                this.materia = materia;
            }

            public override void disponibilidad()
            {

                int prob = MetodosSueltos.generaNumeroAleatorio(0, 100);

                if (prob < 20)
                {
                    base.setAsistencia(false);
                }
                else
                {
                    base.setAsistencia(true);
                }

            }

        }
        public class Aula
        {
            private int id;
            private Profesor profesor;
            private Alumno[] alumnos;
            private string materia;

            private int MAX_ALUMNOS = 20;

            public Aula()
            {
                id = 1;

                profesor = new Profesor();
                alumnos = new Alumno[MAX_ALUMNOS];
                creaAlumnos();
                materia = Constantes.Materias[MetodosSueltos.generaNumeroAleatorio(0, 2)];
            }

            private void creaAlumnos()
            {
                for (int i = 0; i < alumnos.Length; i++)
                {
                    alumnos[i] = new Alumno();
                }
            }

            private bool asistenciaAlumnos()
            {
                int cuentaAsistencias = 0;

                for (int i = 0; i < alumnos.Length; i++)
                {
                    if (alumnos[i].isAsistencia())
                    {
                        cuentaAsistencias++;
                    }
                }

                Console.WriteLine("Hay " + cuentaAsistencias + " alumnos");

                return cuentaAsistencias >= ((int)(alumnos.Length / 2));
            }

            public bool darClase()
            {
                if (!profesor.isAsistencia())
                {
                    Console.WriteLine("El profesor no esta, no se puede dar clase");
                    return false;
                }
                else if (!profesor.getMateria().Equals(materia))
                {
                    Console.WriteLine("La materia del profesor y del aula no es la misma, no se puede dar clase");
                    return false;
                }
                else if (!asistenciaAlumnos())
                {
                    Console.WriteLine("La asistencia no es suficiente, no se puede dar clase");
                    return false;
                }

                Console.WriteLine("Se puede dar clase");
                return true;
            }

            public void notas()
            {
                int chicosApro = 0;
                int chicasApro = 0;

                for (int i = 0; i < alumnos.Length; i++)
                {
                    if (alumnos[i].getNota() >= 5)
                    {
                        if (alumnos[i].getSexo() == 'H')
                        {
                            chicosApro++;
                        }
                        else
                        {
                            chicasApro++;
                        }
                    }
                }
                Console.WriteLine("Hay " + chicosApro + " chicos y " + chicasApro + " chicas aprobados/as");
                Console.ReadKey();
            }
        }

        class Ejercicio8
        {
            static void Main(string[] args)
            {

                Aula aula = new Aula();

                if (aula.darClase())
                {
                    aula.notas();

                }

                Console.ReadKey();
            }
        }
    }
}