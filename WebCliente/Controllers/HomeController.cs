using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApiEmpleado_Scaffold.ModelsEx;
using WebCliente.Models;

namespace WebCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient http;

        public HomeController(IHttpClientFactory factory)
        {
            http = factory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            
            var datos = await http.GetFromJsonAsync<List<EmpleadoEx>>("api/Empleados");

            return View("Index", datos);
        }

        public async Task<IActionResult> Create()
        {

            var datos = await http.GetFromJsonAsync<List<EmpresaEx>>("api/Empleados/Empresas");
            ViewBag.IdEmpresa = new SelectList(datos, "Id", "Nombre");

            return View("Create");
        }

        public async Task<IActionResult> CreatePost(int id)
        {
            await http.DeleteAsync("api/Empleados/" + id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
