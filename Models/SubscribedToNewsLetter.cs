using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieApp.ViewModels;

namespace MovieApp.Models
{
    public class SubscribedToNewsLetter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerFormViewModel)validationContext.ObjectInstance;

            if (customer.IsSubscribedNewsLetter)
                return ValidationResult.Success;

            return new ValidationResult("Ypu should subscribe the newsletter!");
        }
    }
}