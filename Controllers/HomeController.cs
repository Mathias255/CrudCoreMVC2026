using System.Diagnostics;
using CrudCoreMVC2026.Models;
using CrudCoreMVC2026.Models.crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudCoreMVC2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuariosContext _DBContext;

        public HomeController(UsuariosContext contexto)
        {
            _DBContext = contexto;
        }

        public UsuarioVM oUsuario { get; private set; }
        public List<SelectListItem> oListaCargo { get; private set; }

        public IActionResult Index()
        {
            List<Usuario> ListaUsuarios = _DBContext.Usuario.Include(c => c.oCargo).ToList();
            return View(ListaUsuarios);
        }

        [HttpGet]
        public IActionResult Usuario_Detalle(int idUsuario)
        {
            UsuarioVM oUsuarioVM = new UsuarioVM()

            {
                oUsuario = new Usuario(),
                oListaCargos = _DBContext.Cargos.Select(c => new SelectListItem()
                {
                    Text = c.Descripcion,
                    Value = c.IdCargo.ToString()
                }).ToList()
            };
            if (idUsuario != 0)
            {
                oUsuarioVM.oUsuario = _DBContext.Usuario.Find(idUsuario);
            }
            return View(oUsuarioVM);
        }
    }
}