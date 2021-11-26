using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudPais
{
    public class CreateModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public CreateModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pais Pais { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pais.Add(Pais);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
