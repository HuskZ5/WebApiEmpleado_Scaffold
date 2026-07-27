namespace WebApiEmpleado_Scaffold.ModelsEx
{
    public class EmpleadoEx
    {
        public int IdE { get; set; }

        public int IdEmpresa { get; set; }

        public string Nombre { get; set; } = null!;

        public string Paterno { get; set; } = null!;

        public decimal SueldoBruto { get; set; }

        public decimal SueldoNeto { get; set; }

        public EmpresaEx? IdEmpresaNavigation { get; set; }
    }
}
