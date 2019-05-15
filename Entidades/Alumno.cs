using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        //public Alumno() => UniqueId = Guid.NewGuid().ToString();
        //Evaluaciones = new List<Evaluaciones>();
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
        public Alumno()=>UniqueId=Guid.NewGuid().ToString();

        
    }
}