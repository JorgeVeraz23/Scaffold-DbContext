using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int? IdProfesor { get; set; }

    public int? IdMateria { get; set; }

    public virtual Materium? IdMateriaNavigation { get; set; }

    public virtual Profesor? IdProfesorNavigation { get; set; }
}
