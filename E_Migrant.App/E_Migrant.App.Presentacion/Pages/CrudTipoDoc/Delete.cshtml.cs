using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudTipoDoc
{
    public class DeleteModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public DeleteModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoDoc TipoDoc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoDoc = await _context.TipoDoc.FirstOrDefaultAsync(m => m.Id == id);

            if (TipoDoc == null)
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

            TipoDoc = await _context.TipoDoc.FindAsync(id);

            if (TipoDoc != null)
            {
                _context.TipoDoc.Remove(TipoDoc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
