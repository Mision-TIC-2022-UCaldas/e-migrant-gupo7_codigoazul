using System;

namespace E_Migrant.App.Dominio
{
    public class Migrante
    {
        public int Id {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public TipoDoc TipoDocumento {get; set;}
        public string NumeroDocumento {get; set;}
        public Pais PaisOrigen {get; set;}
        public DateTime FechaNacimiento {get; set;}
        public string Email {get; set;}
        public string NumeroTelefono {get; set;}
        public string DireccionActual {get; set;}
        public Ciudad Ciudad {get;set;}
        public SituacionLaboral SituacionLaboral {get;set;}
        public string Usuario {get; set;}
        public string Contraseña {get; set;}
        public string rol {get; set;}
    }
}