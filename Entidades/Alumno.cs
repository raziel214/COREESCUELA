using System;
using System.Collections.Generic;
using COREESCUELA.Entidades;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}