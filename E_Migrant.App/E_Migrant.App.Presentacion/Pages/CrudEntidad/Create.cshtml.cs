using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia.AppRepositorios;

namespace E_Migrant.App.Presentacion.Pages.CrudEntidad
{
    public class CreateModel : PageModel
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

        public CreateModel(E_Migrant.App.Persistencia.AppRepositorios.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var listaSectorBD = _context.Sector;
            listaSector = new SelectList(listaSectorBD, nameof(Sector.Id), nameof(Sector.NombreSector), new { onchange = @"Model.ChangeValue();" });

            var listaCiudadBD = _context.Ciudad;
            listaCiudad = new SelectList(listaCiudadBD, nameof(Ciudad.Id), nameof(Ciudad.NombreCiudad), new { onchange = @"Model.ChangeValue();" });

            var listaTipoServicioBD = _context.TipoServicio;
            listaTipoServicio = new SelectList(listaTipoServicioBD, nameof(TipoServicio.Id), nameof(TipoServicio.NombreTipoServicio), new { onchange = @"Model.ChangeValue();" });
            return Page();
        }

        [BindProperty]
        public Entidad Entidad { get; set; }

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

            
            if (Entidad.TipoServicios != null)
            {
                Entidad.TipoServicios.Add(TipoServicio);
            }
            else
            {
                Entidad.TipoServicios = new List<TipoServicio> { };
                Entidad.TipoServicios.Add(TipoServicio);
            }

            //Entidad.Sector = TipoServicio;

            Entidad.rol = "Entidad";
            _context.Entidades.Add(Entidad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
