using System;

namespace E_Migrant.App.Dominio
{
    public class Servicio
    {
        public int Id {get; set;}
        public string NombreServicio {get; set;}
        public TipoServicio TipoServicio {get; set;}
        public DateTime FechaInicioOferta {get; set;}
        public DateTime FechaFinOferta {get; set;}
        public string Estado {get; set;}
        public Entidad Entidad {get; set;}
      
    }
}