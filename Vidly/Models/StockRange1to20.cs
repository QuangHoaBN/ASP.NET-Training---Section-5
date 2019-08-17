using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class StockRange1to20:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return movie.Stock == null
                ? new ValidationResult("Stock is reqiured!")
                : (movie.Stock>=1 && movie.Stock<=20) ? ValidationResult.Success : new ValidationResult("Stock should be range 1 to 20!");
        }
    }
}