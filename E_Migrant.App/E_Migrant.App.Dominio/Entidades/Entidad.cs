using System;

namespace E_Migrant.App.Dominio
{
    public class Entidad
    {
        public int Id {get; set;}
        public string RazonSocial {get; set;}
        public string Nit {get; set;}
        public string Direccion {get; set;}
        public Ciudad Ciudad {get; set;}
        public string Telefono {get; set;}
        public string Email {get; set;}
        public string PaginaWeb {get; set;}
        public Sector Sector {get; set;}
        public System.Collections.Generic.List<TipoServicio> TipoServicios {get; set;}
        public string Usuario {get; set;}
        public string Contraseña {get; set;}
        public string rol {get; set;}
    }
}