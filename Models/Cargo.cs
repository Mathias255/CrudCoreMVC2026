using System;
using System.Collections.Generic;

namespace CrudCoreMVC2026.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
