using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudSituacionLaboral
{
    public class DeleteModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public DeleteModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public SituacionLaboral SituacionLaboral { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SituacionLaboral = await _context.SituacionLaboral.FirstOrDefaultAsync(m => m.Id == id);

            if (SituacionLaboral == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SituacionLaboral = await _context.SituacionLaboral.FindAsync(id);

            if (SituacionLaboral != null)
            {
                _context.SituacionLaboral.Remove(SituacionLaboral);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
