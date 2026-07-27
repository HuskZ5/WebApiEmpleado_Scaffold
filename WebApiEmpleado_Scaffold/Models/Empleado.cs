using System;
using System.Collections.Generic;

namespace WebApiEmpleado_Scaffold.Models;

public partial class Empleado
{
    public int IdE { get; set; }

    public int IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public string Paterno { get; set; } = null!;

    public decimal SueldoBruto { get; set; }

    public decimal SueldoNeto { get; set; }

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
