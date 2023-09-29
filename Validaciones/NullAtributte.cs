using System.ComponentModel.DataAnnotations;

namespace CuotaPrestamos.Validaciones
{
    public class NullAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            int valor = Convert.ToInt32(value);
            if (valor < 1)
            {
                return new ValidationResult("Error");
            }

            

            return ValidationResult.Success;
        }
    }
}
