using System;
using System.Collections.Generic;

namespace WebApiEmpleado_Scaffold.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estatus { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
