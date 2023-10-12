using ClosedXML.Excel;
using CuotaPrestamos.Models;

using Dapper;
using DinkToPdf.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using System.Data;


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

        public async Task<IActionResult> TablaAmortizada(DatosCliente datosCliente)
        {
            if (!ModelState.IsValid)
            {
                return View(datosCliente);
            }

            //Usando Session Para guardar 

            await Task.Run(() =>
            {
                HttpContext.Session.SetString("DatosClientes", JsonConvert.SerializeObject(datosCliente));
            });

            return View(datosCliente);
        }




        public IActionResult ImprimirVenta()
        {
            var datos =  HttpContext.Session.GetString("DatosClientes");
            DatosCliente modelo = JsonConvert.DeserializeObject<DatosCliente>(datos);

            //View De La Tabla A Imprimir
            return new ViewAsPdf("TablaAmortizadaVista", modelo)
            {
                FileName = $"Tabla {DateTime.Today.ToString("MMMM-yyyy-dddd")}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A6
            };
        }


        

       





        }
    }
















