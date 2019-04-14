using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("John's School", 2012, TiposEscuela.Primaria,
               ciudad: "cali", pais: "Colombia");

            /** var arregloCursos = new Curso[3]{
                    new Curso{Nombre="201"},
                    new Curso{Nombre="202"},
                    new Curso{Nombre="203"}

            };*/

            Curso[] arregloCursos = {
                    new Curso{Nombre="201"},
                    new Curso{Nombre="202"},
                    new Curso{Nombre="203"}

            };

            /** arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            arregloCursos[1] = new Curso()
            {
                Nombre = "201"
            };
            arregloCursos[2] = new Curso()
            {
                Nombre = "301"
            };*/

            /**var curso1 = new Curso(){
                Nombre="101",

            };

            var curso2 = new Curso()
            {
                Nombre = "201",

            };
            var curso3 = new Curso()
            {
                Nombre = "301",

            };**/
            //escuela.Pais="Colombia";
            //escuela.ciudad="Cali";
            //escuela.Nombre="John's School";
            //escuela.TipoEscuela=TiposEscuela.Secundaria;
            Console.WriteLine(escuela);
            System.Console.WriteLine("#############");
            ImprimirCursosFor(arregloCursos);
            System.Console.WriteLine("#############");
            ImprimirCursosForEach(arregloCursos);

        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            foreach (var curso in arregloCursos)
            {
                System.Console.WriteLine($"Nombre{curso.Nombre},Id {curso.UniqueId} ");
            }
            stop = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine(stop.Subtract(start).TotalMilliseconds);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

            for (int i = 0; i < arregloCursos.Length; i++)
            {
                System.Console.WriteLine($"Nombre{arregloCursos[i].Nombre},Id {arregloCursos[i].UniqueId} ");

            }

            stop = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine(stop.Subtract(start).TotalMilliseconds);
        }
    }
}
