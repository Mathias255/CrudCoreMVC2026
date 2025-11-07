using System;
using System.Collections.Generic;

namespace CrudCoreMVC2026.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombrecompleto { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? IdCargo { get; set; }

    public virtual Cargo? oCargo { get; set; }
}
