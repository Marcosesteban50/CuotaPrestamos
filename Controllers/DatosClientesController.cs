using CuotaPrestamos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuotaPrestamos.Controllers
{
    public class DatosClientesController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Crear(DatosCliente datosCliente)
        {

            if (!ModelState.IsValid) 
            {
                
                return View(datosCliente);
            }
            
            return View();
        }


        public IActionResult TablaAmortizada()
        {
            return View();
        }

        [HttpPost]

        public IActionResult TablaAmortizada(DatosCliente datosCliente)
        {
            if(!ModelState.IsValid)
            {
                return View(datosCliente);
            }

            return View(datosCliente);
        }
    }
}
