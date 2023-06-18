using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
