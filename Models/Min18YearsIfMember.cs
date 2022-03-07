using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerFormViewModel)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == CustomerFormViewModel.MembershipUnknown ||
                customer.MembershipTypeId == CustomerFormViewModel.MembershipPayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required!");

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                   ? ValidationResult.Success
                   : new ValidationResult("Customer should be at least 18 years old to go on a membership!");

        }
    }
}