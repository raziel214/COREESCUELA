using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using COREESCUELA.Entidades;

namespace CoreEscuela {
    public sealed class EscuelaEngine {
        public Escuela Escuela { get; set; }

        public EscuelaEngine () {

        }

        public void Inicializar () {
            Escuela = new Escuela ("Platzi Academia", 2012, TiposEscuela.Primaria,
                ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos ();
            CargarAsignaturas ();
            CargarEvaluaciones ();

        }

        public  void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic,
                        bool imprEval=false)
        {
            foreach (var objdic in dic)
            {
                //System.Console.WriteLine( obj);
                Printer.WriteTitle(objdic.Key.ToString());
                foreach (var val in objdic.Value)
                {


                    switch (objdic.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if(imprEval)
                                 System.Console.WriteLine(val);
                        break;
                        case LlaveDiccionario.Escuela:                        
                                System.Console.WriteLine("Escuela: " + val);
                        break;
                        case LlaveDiccionario.Alumno:                           
                                System.Console.WriteLine("Alumno: " + val.Nombre);
                         break;

                        default:
                            System.Console.WriteLine(val);
                         break;   
                    }
                    
                    
                }
                
            }

        }

        public Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>>GetDiccionarioObjetos()
        {
           
            
            var diccionario=new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela,new[] {Escuela});           
            diccionario.Add(LlaveDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listatmp = new List<Evaluacion>();
            var listatmpasignaturas = new List<Asignatura>();
            var listatmpalumnos = new List<Alumno>();
            foreach (var cur in Escuela.Cursos)
            {
                listatmpasignaturas.AddRange(cur.Asignaturas);
                listatmpalumnos.AddRange(cur.Alumnos);
                //diccionario.Add(LlaveDiccionario.Asignatura, cur.Asignaturas.Cast<ObjetoEscuelaBase>());
                //diccionario.Add(        LlaveDiccionario.Alumno, cur.Alumnos.Cast<ObjetoEscuelaBase>());
               
                foreach (var alum in cur.Alumnos)
                {
                    listatmp.AddRange(alum.Evaluaciones);
                    
                }

            }
            diccionario.Add(LlaveDiccionario.Asignatura, listatmpasignaturas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listatmpalumnos.Cast<ObjetoEscuelaBase>());

            diccionario.Add(LlaveDiccionario.Evaluacion, listatmp.Cast<ObjetoEscuelaBase>());
            diccionario[LlaveDiccionario.Curso]=Escuela.Cursos.Cast<ObjetoEscuelaBase>();
            return diccionario;



        }

      
        public IReadOnlyList<ObjetoEscuelaBase>GetObjetosEscuela(
                        bool traeEvaluaciones,
                        bool traeAlumnos,
                        bool traeAsignaturas,
                        bool traeCursos
                        )
        {
            return GetObjetosEscuela(out int dummy,out dummy,out dummy,out dummy);

        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                        out int conteoEvaluaciones,
                        bool traeEvaluaciones,
                        bool traeAlumnos,
                        bool traeAsignaturas,
                        bool traeCursos
                        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);

        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                        out int conteoEvaluaciones,
                        out int conteoCursos,
                        bool traeEvaluaciones,
                        bool traeAlumnos,
                        bool traeAsignaturas,
                        bool traeCursos
                        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones,out conteoCursos ,out int dummy, out dummy);

        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                            out int conteoEvaluaciones,
                            out int conteoCursos,
                            out int conteoAsignaturas,
                            bool traeEvaluaciones,
                            bool traeAlumnos,
                            bool traeAsignaturas,
                            bool traeCursos
                            )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);

        }

        public IReadOnlyList <ObjetoEscuelaBase> GetObjetosEscuela (
                        out int conteoEvaluaciones,
                        out int conteoCursos,
                        out int conteoAsignaturas,
                        out int conteoAlumnos,
                        bool traeEvaluaciones = true,
                        bool traeAlumnos = true,
                        bool traeAsignaturas = true,
                        bool traeCursos = true
                        )
         {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase> ();
            listaObj.Add (Escuela);
            if (traeCursos == true)
                listaObj.AddRange (Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos) {

                conteoAlumnos += curso.Alumnos.Count;
                conteoAsignaturas += curso.Asignaturas.Count;
                if (traeAsignaturas)
                    listaObj.AddRange (curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange (curso.Alumnos);

                if (traeEvaluaciones) {
                    foreach (var alumno in curso.Alumnos) {
                        listaObj.AddRange (alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return (listaObj.AsReadOnly());
        }

        #region Metodos de Carga

        private void CargarAsignaturas () {
            foreach (var curso in Escuela.Cursos) {
                var listaAsignaturas = new List<Asignatura> () {
                    new Asignatura { Nombre = "Matemáticas" },
                    new Asignatura { Nombre = "Educación Física" },
                    new Asignatura { Nombre = "Castellano" },
                    new Asignatura { Nombre = "Ciencias Naturales" }
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar (int cantidad) {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
            from n2 in nombre2
            from a1 in apellido1
            select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy ((al) => al.UniqueId).Take (cantidad).ToList ();
        }

        private void CargarEvaluaciones () {

            foreach (var curso in Escuela.Cursos) {
                foreach (var asignatura in curso.Asignaturas) {
                    foreach (var alumno in curso.Alumnos) {
                        var rnd = new Random (System.Environment.TickCount);

                        for (int i = 0; i < 5; i++) {
                            var ev = new Evaluacion {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float) (5 * rnd.NextDouble ()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add (ev);
                        }
                    }
                }
            }

        }

        private void CargarCursos () {
            Escuela.Cursos = new List<Curso> () {
                new Curso () { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso () { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso { Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso () { Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso () { Nombre = "501", Jornada = TiposJornada.Tarde },
            };

            Random rnd = new Random ();
            foreach (var c in Escuela.Cursos) {
                int cantRandom = rnd.Next (5, 20);
                c.Alumnos = GenerarAlumnosAlAzar (cantRandom);
            }
        }
    }
    #endregion

    

}