using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudCiudad
{
    public class IndexModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public IndexModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        public IList<Ciudad> Ciudad { get;set; }

        public async Task OnGetAsync()
        {
            Ciudad = await _context.Ciudad.ToListAsync();
        }
    }
}
