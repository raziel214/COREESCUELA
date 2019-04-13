
namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre
        {
            get { return "Copia:" + nombre; }
            set { nombre = value.ToUpper(); }


        }

        public int AnioDeCreacion { get; set; }

        public string  Pais { get; set; }

        public string ciudad { get; set; }

        public TiposEscuela TipoEscuela{get;set;}

        /** public Escuela(string nombre,int anio){
             this.nombre=nombre;
              AnioDeCreacion=anio;

         } */


        public Escuela(string nombre, int anio)=>(Nombre,AnioDeCreacion)=(nombre,anio);

        public override string ToString(){

            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}\n,Pais: {Pais},Ciudad: {ciudad}";
        }


        




    }

}