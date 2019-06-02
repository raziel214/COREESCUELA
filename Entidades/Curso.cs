using System;
using System.Collections.Generic;
using CoreEscuela.Util;
using COREESCUELA.Entidades;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {
       
        //public TiposJornada Jornada { get; set; }
        //public List<Asignatura> Asignaturas{ get; set; }
        //public List<Alumno> Alumnos{ get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get ; set; }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            //System.Console.WriteLine("Limpiaando Escuela ........");
            System.Console.WriteLine("Limpiando Curso ........");
            System.Console.WriteLine($"Curso{Nombre} Limpio ");
        }

       

    }
}