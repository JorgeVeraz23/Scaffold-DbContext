using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public int? IdPersona { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual Persona? IdPersonaNavigation { get; set; }
}
