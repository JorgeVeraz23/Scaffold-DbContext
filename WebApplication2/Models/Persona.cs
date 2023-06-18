using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
