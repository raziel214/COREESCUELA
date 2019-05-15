using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {public Alumno()
        {
            UniqueId = Guid.NewGuid().ToString();
            Evaluaciones = new List<Evaluaciones>();
        }
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        //public Alumno() => UniqueId = Guid.NewGuid().ToString();
        //Evaluaciones = new List<Evaluaciones>();
        public List<Evaluaciones> Evaluaciones { get; set; }

        
    }
}