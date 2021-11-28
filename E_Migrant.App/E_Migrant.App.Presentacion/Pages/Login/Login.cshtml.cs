using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace E_Migrant.App.Presentacion
{
    public class LoginModel : PageModel
    {
        private  E_Migrant.App.Persistencia.AppRepositorios.Conexion conexion;
        [BindProperty]
        public string Usuario { get; set; }

        [BindProperty]
        public string Contraseña { get; set;}
        
        [BindProperty]
        public string MensajeUsuario {get;set;}
        public string MensajeContraseña {get;set;}
        
        public void OnGet()
        {
        }
        public IActionResult OnPost()
       
        {
            conexion = new E_Migrant.App.Persistencia.AppRepositorios.Conexion();
            var p = conexion.Migrantes.FirstOrDefault(p => p.Usuario == Usuario);
            Console.WriteLine("Usuario migrante"+ Usuario);
            var q = conexion.Entidades.FirstOrDefault(q => q.Usuario == Usuario);
            Console.WriteLine("Este es el Usuario"+ Usuario);
            if (p == null || q == null){
                MensajeUsuario = "Usuario no encontrado. Intenta de nuevo";
            }
            else if (!p.Contraseña.Equals(Contraseña) || !q.Contraseña.Equals(Contraseña)){
                Console.WriteLine("Esta no es la contraseña"+ Contraseña);
                HttpContext.Session.SetString("Usuario", Usuario);
                MensajeContraseña = "Contraseña incorrecta. Intenta de nuevo";
            }
            
            if (p != null){
                Console.WriteLine("Entre a p (migrante)");
                HttpContext.Session.SetString("UsuarioAutenticado", p.rol);
                Console.WriteLine("Este es el rol"+p.rol);
                HttpContext.Session.SetInt32("GetId", p.Id);
                Console.WriteLine("Este es el Id"+p.Id);
                return RedirectToPage("../Index");
            }
            
            if (q != null){
                Console.WriteLine("Entre a q (entidad)");
                HttpContext.Session.SetString("UsuarioAutenticado", q.rol);
                Console.WriteLine("Este es el rol"+q.rol);
                HttpContext.Session.SetInt32("GetId", q.Id);
                Console.WriteLine("Este es el Id"+q.Id);
                return RedirectToPage("../Index");
            }
            return Page();
        }
    }
}
