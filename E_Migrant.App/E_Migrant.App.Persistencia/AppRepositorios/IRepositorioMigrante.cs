using System.Collections.Generic;
using System.Linq;
using E_Migrant.App.Dominio;


namespace E_Migrant.App.Persistencia.AppRepositorios
{
    public interface IRepositorioMigrante
    {
         public List<Migrante> consultarTodos();

         public int guardarMigrante();

         public void eliminarMigrante(int Id);

         public void actualizarPersona(Migrante migrante);
         
    }
    
}