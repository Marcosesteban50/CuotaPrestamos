using CuotaPrestamos.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.Diagnostics;

namespace CuotaPrestamos.Controllers
{
    public class HomeController : Controller
    {

        
        public HomeController()
        {
            
        }
            

       


        public IActionResult Index()
        {
            return View();
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