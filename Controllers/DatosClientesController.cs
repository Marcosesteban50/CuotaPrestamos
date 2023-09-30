using ClosedXML.Excel;
using CuotaPrestamos.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CuotaPrestamos.Controllers
{

    public class DatosClientesController : Controller
    {
        private readonly IConverter _converter;
        public DatosClientesController(IConverter converter)
        {
            _converter = converter;
        }

       
       


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
            if (!ModelState.IsValid)
            {
                return View(datosCliente);
            }

            return View(datosCliente);
        }

        [HttpGet]
        public FileResult ExportarExcelM()
        {
            var nombreArchivo = "Tabla De Prestamos.xlsx";
            var Clientes = new List<DatosCliente>();

            return GenerarExcel(nombreArchivo, Clientes);
        }

        private FileResult GenerarExcel(string nombreArchivo,
            IEnumerable<DatosCliente> datosClientes)
        {
            //# Pago InteresPagado CapitalPagado MontoPrestamo
            DataTable dataTable = new DataTable("Datos Clientes");
            dataTable.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("Pago"),
                new DataColumn("InteresPagado"),
                new DataColumn("CapitalPagado"),
                new DataColumn("MontoPrestamo"),
            });

            foreach (var item in datosClientes)
            {
                dataTable.Rows.Add(item.pago,
                    item.Interes_Pagado,
                    item.capital_pagado,
                    item.Monto_Del_Prestamo);

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        , nombreArchivo);
                }
            }


        }






        [HttpGet]
        public FileResult ExportarPDFM()
        {
            var nombreArchivo = "Tabla De Prestamos.pdf";
            var Clientes = new List<DatosCliente>();

            return GenerarPDF(nombreArchivo, Clientes);
        }

        private FileResult GenerarPDF(string nombreArchivo,
            IEnumerable<DatosCliente> datosClientes)
        {
            //# Pago InteresPagado CapitalPagado MontoPrestamo
            DataTable dataTable = new DataTable("Datos Clientes");
            dataTable.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("Pago"),
                new DataColumn("InteresPagado"),
                new DataColumn("CapitalPagado"),
                new DataColumn("MontoPrestamo"),
            });

            foreach (var item in datosClientes)
            {
                dataTable.Rows.Add(item.pago,
                    item.Interes_Pagado,
                    item.capital_pagado,
                    item.Monto_Del_Prestamo);

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        , nombreArchivo);
                }
            }


        }




    }
}
