using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudEntidad
{
    public class DetailsModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public DetailsModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        public Entidad Entidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entidad = await _context.Entidades.Where(m => m.Id == id)
            .Include(m => m.Ciudad)
            .Include(m => m.Sector).FirstOrDefaultAsync();


            //Entidad = await _context.Entidades.FirstOrDefaultAsync(m => m.Id == id);

            if (Entidad == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
