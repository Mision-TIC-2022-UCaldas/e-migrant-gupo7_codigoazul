using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudTipoDoc
{
    public class EditModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public EditModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipoDoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocExists(TipoDoc.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TipoDocExists(int id)
        {
            return _context.TipoDoc.Any(e => e.Id == id);
        }
    }
}
