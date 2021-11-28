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

namespace E_Migrant.App.Presentacion.Pages.CrudEntidad
{
    public class EditModel : PageModel
    {
        private readonly E_Migrant.App.Persistencia.AppRepositorios.Conexion _context;

        public SelectList listaSector { get; set; }
        public SelectList listaCiudad { get; set; }
        public SelectList listaTipoServicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SectorID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CiudadID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TipoServicioID { get; set; }

        public EditModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public Entidad Entidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaSectorBD = _context.Sector;
            listaSector = new SelectList(listaSectorBD, nameof(Sector.Id), nameof(Sector.NombreSector), new { onchange = @"Model.ChangeValue();" });

            var listaCiudadBD = _context.Ciudad;
            listaCiudad = new SelectList(listaCiudadBD, nameof(Ciudad.Id), nameof(Ciudad.NombreCiudad), new { onchange = @"Model.ChangeValue();" });

            var listaTipoServicioBD = _context.TipoServicio;
            listaTipoServicio = new SelectList(listaTipoServicioBD, nameof(TipoServicio.Id), nameof(TipoServicio.NombreTipoServicio), new { onchange = @"Model.ChangeValue();" });

            Entidad = await _context.Entidades.FirstOrDefaultAsync(m => m.Id == id);

            if (Entidad == null)
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

            Sector Sector = _context.Sector.FirstOrDefault(p => p.Id == SectorID);
            Entidad.Sector = Sector;

            Ciudad Ciudad = _context.Ciudad.FirstOrDefault(p => p.Id == CiudadID);
            Entidad.Ciudad = Ciudad;

            TipoServicio TipoServicio = _context.TipoServicio.FirstOrDefault(p => p.Id == TipoServicioID);

            Entidad.rol = "Entidad";
            _context.Attach(Entidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadExists(Entidad.Id))
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

        private bool EntidadExists(int id)
        {
            return _context.Entidades.Any(e => e.Id == id);
        }
    }
}
