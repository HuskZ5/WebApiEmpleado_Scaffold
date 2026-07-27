using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEmpleado_Scaffold.Models;
using WebApiEmpleado_Scaffold.ModelsEx;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEmpleado_Scaffold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpresaContext _db;

        public EmpleadosController(EmpresaContext db)
        {
            _db = db;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public List<EmpleadoEx> Get()
        {
            List<Empleado> ls = _db.Empleados.Include(x => x.IdEmpresaNavigation).ToList();
            List<EmpleadoEx> lsEx = new List<EmpleadoEx>();

            foreach (var e in ls)
            {
                EmpleadoEx ex = new EmpleadoEx();
                EmpresaEx emx = new EmpresaEx();

                ex.IdE = e.IdE;
                ex.IdEmpresa = e.IdEmpresa;
                ex.SueldoBruto = e.SueldoBruto;
                ex.SueldoNeto = e.SueldoNeto;
                ex.Nombre = e.Nombre;
                ex.Paterno = e.Paterno;

                emx.Estatus = e.IdEmpresaNavigation.Estatus;
                emx.Nombre = e.IdEmpresaNavigation.Nombre;
                emx.Id = e.IdEmpresaNavigation.Id;

                ex.IdEmpresaNavigation = emx;

                lsEx.Add(ex);
            }

            return lsEx;
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public EmpleadoEx Get(int id)
        {
            Empleado e = _db.Empleados.Include(x => x.IdEmpresaNavigation).FirstOrDefault(x => x.IdE == id)!;

            EmpleadoEx ex = new EmpleadoEx();
            EmpresaEx emx = new EmpresaEx();

            ex.IdE = e.IdE;
            ex.IdEmpresa = e.IdEmpresa;
            ex.SueldoBruto = e.SueldoBruto;
            ex.SueldoNeto = e.SueldoNeto;
            ex.Nombre = e.Nombre;
            ex.Paterno = e.Paterno;

            emx.Estatus = e.IdEmpresaNavigation.Estatus;
            emx.Nombre = e.IdEmpresaNavigation.Nombre;
            emx.Id = e.IdEmpresaNavigation.Id;

            ex.IdEmpresaNavigation = emx;

            return ex;
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public void Post([FromBody] EmpleadoEx e)
        {
            decimal sueldoNeto = e.SueldoBruto * (1 - 0.16m);

            Empleado nEmpleado = new Empleado
            {
                Nombre = e.Nombre,
                Paterno = e.Paterno,
                SueldoBruto = e.SueldoBruto,
                SueldoNeto = sueldoNeto,
                IdEmpresa = e.IdEmpresa
            };

            _db.Empleados.Add(nEmpleado);
            _db.SaveChanges();
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmpleadoEx e)
        {
            var empleadoExist = _db.Empleados.Find(id);

            empleadoExist.Nombre = e.Nombre;
            empleadoExist.Paterno = e.Paterno;
            empleadoExist.SueldoBruto = e.SueldoBruto;
            empleadoExist.SueldoNeto = e.SueldoBruto * (1 - 0.16m);
            empleadoExist.IdEmpresa = e.IdEmpresa;

            _db.SaveChanges();
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var empleado = _db.Empleados.Find(id);

            _db.Empleados.Remove(empleado);
            _db.SaveChanges();
        }

        [HttpGet("Empresas")]
        public List<EmpresaEx> GetPeticiones()
        {
            List<Empresa> ls = _db.Empresas.ToList();
            List<EmpresaEx> lsex = new List<EmpresaEx>();

            foreach (Empresa e in ls)
            {
                EmpresaEx ex = new EmpresaEx();

                ex.Estatus = e.Estatus;
                ex.Nombre = e.Nombre;
                ex.Id = e.Id;

                lsex.Add(ex);
            }

            return lsex;
        }
    }
}
