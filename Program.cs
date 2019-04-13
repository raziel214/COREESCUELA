using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela= new Escuela("John's School",2012,TiposEscuela.Primaria,
               ciudad:"cali", pais:"Colombia");
            //escuela.Pais="Colombia";
            //escuela.ciudad="Cali";
            //escuela.Nombre="John's School";
            //escuela.TipoEscuela=TiposEscuela.Secundaria;
            Console.WriteLine(escuela);
        }

        
    }
}
