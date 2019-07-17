﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using COREESCUELA.Entidades;
using static System.Console;

namespace CoreEscuela {
    class Program {
        static void Main (string[] args) {

            AppDomain.CurrentDomain.ProcessExit+=AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s)=> Printer.Beep(2000,1000,1);
            var engine = new EscuelaEngine ();
            engine.Inicializar ();
            Printer.WriteTitle ("BIENVENIDOS A LA ESCUELA");
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
           


        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000,1000,3);
            Printer.WriteTitle("SALIÓ");
            //throw new NotImplementedException();
        }

        private static void ImpimirCursosEscuela (Escuela escuela) {

            Printer.WriteTitle ("Cursos de la Escuela");

            if (escuela?.Cursos != null) {
                foreach (var curso in escuela.Cursos) {
                    WriteLine ($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }

    }
}