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
            var engine = new EscuelaEngine ();
            engine.Inicializar ();
            Printer.WriteTitle ("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            ImpimirCursosEscuela (engine.Escuela);
            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(10,      "JohnF");
            diccionario.Add(23, "Ibeth Amor");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"key: {keyValPair.Key} valor:{keyValPair.Value}");
                
            }
            var dictmp=engine.GetDiccionarioObjetos();

            //Printer.WriteTitle("Acceso a Diccionario");
            engine.ImprimirDiccionario(dictmp);
           


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