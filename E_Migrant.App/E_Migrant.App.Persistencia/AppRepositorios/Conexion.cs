using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;

namespace E_Migrant.App.Persistencia.AppRepositorios
{
    public class Conexion : DbContext
    {

        public DbSet<Pais> Pais {get; set;}
        public DbSet<Ciudad> Ciudad {get; set;}
        public DbSet<SituacionLaboral> SituacionLaboral {get; set;}
        public DbSet<TipoDoc> TipoDoc {get; set;}
        public DbSet<Migrante> Migrantes {get; set;}
        public DbSet<Sector> Sector {get; set;}
        public DbSet<TipoServicio> TipoServicio {get; set;}
        public DbSet<Entidad> Entidades {get; set;}
        public DbSet<Servicio> Servicio {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder conn){
            if(!conn.IsConfigured){
                conn.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = CodigoAzulG7");
            }
        }
    }
}