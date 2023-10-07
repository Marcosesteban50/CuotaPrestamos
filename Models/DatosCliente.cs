using CuotaPrestamos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace CuotaPrestamos.Models
{
    public class DatosCliente
    {


        public int id { get; set; }
        [Required(ErrorMessage ="El Campo {0} Es Requerido")]
        [Null]
        [Display(Name ="Monto")]
        public float Monto_Del_Prestamo { get; set; }
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [Null]

        public int Plazo { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [Null]

        [Display(Name ="Interes Anual")]
        public float tasa_interes_anual { get; set; }
        public float tasa_interes_mensual { get; set; }
        public float capital_pagado { get; set; }

        public float Interes_Pagado { get; set; }

        public float pago { get; set; }

        public float UsuarioId { get; set; }

        [Display(Name ="Moneda")]
        public TipoOperacion TipoOperacionId { get; set; }

    }
}
