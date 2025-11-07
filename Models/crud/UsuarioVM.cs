using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudCoreMVC2026.Models.crud
{
    public class UsuarioVM
    {
        public Usuario oUsuario { get; set; }
        public List<SelectListItem> oListaCargos { get; set; }
    }
}
