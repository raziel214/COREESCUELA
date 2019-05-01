using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1 {
    class Program {
        static void Main (string[] args) {
            var escuela = new Escuela ("John's School", 2012, TiposEscuela.Primaria,
                ciudad: "cali", pais: "Colombia");

            /** var arregloCursos = new Curso[3]{
                    new Curso{Nombre="201"},
                    new Curso{Nombre="202"},
                    new Curso{Nombre="203"}

            };*/

            escuela.Cursos = new List<Curso> () {
                new Curso { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "301", Jornada = TiposJornada.Mañana }
            };

            escuela.Cursos.Add (new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });

            var otraollection = new List<Curso> () {
                new Curso { Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso { Nombre = "501", Jornada = TiposJornada.Tarde },
                new Curso { Nombre = "502", Jornada = TiposJornada.Tarde }
            };
            Curso tmp = new Curso () {
                Nombre = "101.Vacacional", Jornada = TiposJornada.Noche

            };
            otraollection.Clear ();
            escuela.Cursos.Add (tmp);
            escuela.Cursos.AddRange (otraollection);
            ImprimirCUrsosEscuela (escuela);            
            
            escuela.Cursos.RemoveAll (Predicado);
            WriteLine ("### nuevos");
            ImprimirCUrsosEscuela (escuela);

            /* escuela.Cursos = new Curso[]  {
                     new Curso{Nombre="201"},
                     new Curso{Nombre="202"},
                     new Curso{Nombre="203"}

             }; */
            //escuela = null;

            //ImprimirCUrsosEscuela(escuela);

            //escuela.Cursos=arregloCursos;

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

            /** //escuela.Pais="Colombia";
             //escuela.ciudad="Cali";
             //escuela.Nombre="John's School";
             //escuela.TipoEscuela=TiposEscuela.Secundaria;
             Console.WriteLine(escuela);
             System.Console.WriteLine("#############");
             ImprimirCursosFor(escuela.Cursos);
             System.Console.WriteLine("#############");
             ImprimirCursosForEach(escuela.Cursos); */

        }

        private static bool PredicadoMalEcho (Curso cursobj) {
            return cursobj.Nombre == "101.Vacacional";
        }

        private static bool Predicado (Curso cursobj) {
            return cursobj.Nombre == "101.Vacacional";
        }

        private static void ImprimirCUrsosEscuela (Escuela escuela) {
            TimeSpan stop;
            TimeSpan start = new TimeSpan (DateTime.Now.Ticks);
            WriteLine ("#############################");
            WriteLine ("Cursos de la escuela");
            WriteLine ("#############################");
            if (escuela?.Cursos != null) {

                foreach (var curso in escuela.Cursos) {
                    WriteLine ($"Nombre{curso.Nombre},Id {curso.UniqueId} ,Jornada {curso.Jornada}");
                }
            } else {
                WriteLine (" No hay cursos disponibles");
            }
            stop = new TimeSpan (DateTime.Now.Ticks);
            WriteLine (stop.Subtract (start).TotalMilliseconds);
        }

        private static void ImprimirCursosForEach (Curso[] arregloCursos) {
            TimeSpan stop;
            TimeSpan start = new TimeSpan (DateTime.Now.Ticks);
            foreach (var curso in arregloCursos) {
                System.Console.WriteLine ($"Nombre{curso.Nombre},Id {curso.UniqueId} ");
            }
            stop = new TimeSpan (DateTime.Now.Ticks);
            Console.WriteLine (stop.Subtract (start).TotalMilliseconds);
        }

        private static void ImprimirCursosFor (Curso[] arregloCursos) {
            TimeSpan stop;
            TimeSpan start = new TimeSpan (DateTime.Now.Ticks);

            for (int i = 0; i < arregloCursos.Length; i++) {
                System.Console.WriteLine ($"Nombre{arregloCursos[i].Nombre},Id {arregloCursos[i].UniqueId} ");

            }

            stop = new TimeSpan (DateTime.Now.Ticks);
            Console.WriteLine (stop.Subtract (start).TotalMilliseconds);
        }
    }
}