using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudMigrante
{
    public class CreateModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public SelectList listaTipos {get; set;}
        public SelectList listaPais {get; set;}
        public SelectList listaCiudad {get; set;}
        public SelectList listaSituacionLaboral {get; set;}
        

        [BindProperty(SupportsGet =true)]
        public int TiposID {get; set;}

        [BindProperty(SupportsGet =true)]
        public int PaisID {get; set;}

        [BindProperty(SupportsGet =true)]
        public int CiudadID {get; set;}

        [BindProperty(SupportsGet =true)]
        public int SituacionLaboralID {get; set;}

        public CreateModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var listaTiposBD = _context.TipoDoc;
            listaTipos = new SelectList(listaTiposBD, nameof(TipoDoc.Id), nameof(TipoDoc.TipoDocumento), new {onchange = @"Model.ChangeValue();"});

            var listaPaisBD = _context.Pais;
            listaPais = new SelectList(listaPaisBD, nameof(Pais.Id), nameof(Pais.NombrePais), new {onchange = @"Model.ChangeValue();"});
            
            var listaCiudadBD = _context.Ciudad;
            listaCiudad = new SelectList(listaCiudadBD, nameof(Ciudad.Id), nameof(Ciudad.NombreCiudad), new {onchange = @"Model.ChangeValue();"});

            var listaSituacionBD = _context.SituacionLaboral;
            listaSituacionLaboral = new SelectList(listaSituacionBD, nameof(SituacionLaboral.Id), nameof(SituacionLaboral.TipoSituacionLaboral), new {onchange = @"Model.ChangeValue();"});


            return Page();
        }

        [BindProperty]
        public Migrante Migrante { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TipoDoc tipoDoc = _context.TipoDoc.FirstOrDefault(p => p.Id == TiposID);
            Migrante.TipoDocumento = tipoDoc;

            Pais Pais = _context.Pais.FirstOrDefault(p => p.Id == PaisID);
            Migrante.PaisOrigen = Pais;

            Ciudad Ciudad = _context.Ciudad.FirstOrDefault(p => p.Id == CiudadID);
            Migrante.Ciudad = Ciudad;

            SituacionLaboral SituacionLaboral = _context.SituacionLaboral.FirstOrDefault(p => p.Id == SituacionLaboralID);
            Migrante.SituacionLaboral = SituacionLaboral;

            Migrante.rol = "Migrante";
            _context.Migrantes.Add(Migrante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
