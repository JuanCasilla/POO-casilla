using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_13
{
    internal class Ejercicio13
    {

        public abstract class Empleado
        {

            private string nombre;
            private int edad;
            private double salario;

            public double PLUS = 300;

            public Empleado(string nombre, int edad, double salario)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.salario = salario;
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

            public double getSalario()
            {
                return salario;
            }

            public void setSalario(double salario)
            {
                this.salario = salario;
            }

            public abstract bool plus();

        }

        public class Comercial : Empleado
        {
            private double comision;

            public Comercial(double comision, string nombre, int edad, double salario) : base(nombre, edad, salario)
            {
                this.comision = comision;
            }

            public double getComision()
            {
                return comision;
            }

            public void setComision(double comision)
            {
                this.comision = comision;
            }

            public override bool plus()
            {
                if (base.getEdad() > 30 && this.comision > 200)
                {
                    double nuevoSalario = base.getSalario() + base.PLUS;
                    base.setSalario(nuevoSalario);
                    Console.WriteLine("Se le añadido el plus a " + base.getNombre());
                    return true;
                }
                return false;
            }
        }

        public class Repartidor : Empleado
        {

            private string zona;

            public Repartidor(string zona, string nombre, int edad, double salario) : base(nombre, edad, salario)
            {
                this.zona = zona;
            }

            public string getZona()
            {
                return zona;
            }

            public void setZona(string zona)
            {
                this.zona = zona;
            }


            public override bool plus()
            {
                if (base.getEdad() < 25 && this.zona == "zona 3")
                {
                    double nuevoSalario = base.getSalario() + base.PLUS;
                    base.setSalario(nuevoSalario);
                    Console.WriteLine("Se le añadido el plus a " + base.getNombre());
                    return true;
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            Comercial c1 = new Comercial(300, "Duki", 37, 1000);
            Repartidor r1 = new Repartidor("zona 3", "YSY A", 22, 900);

            Console.WriteLine("El empleado comercial tiene un salario de: " + c1.getSalario());
            c1.plus();
            Console.WriteLine("El empleado comercial con PLUS tiene un salario de: " + c1.getSalario());
            Console.WriteLine();
            Console.WriteLine("El empleado repartidor tiene un salario de: " + r1.getSalario());
            r1.plus();
            Console.WriteLine("El empleado repartidor con PLUS tiene un salario de: " + r1.getSalario());
            Console.ReadKey();
        }
    }
}