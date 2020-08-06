using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_IT_Done.Models
{
    public class DOBValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var User = (Users)validationContext.ObjectInstance;
            if (User.DateOfBirth.HasValue)
            {
                TimeSpan DOBDiff = DateTime.Now.Subtract(User.DateOfBirth.Value);
                if (DOBDiff.Ticks < 0)
                {
                    return new ValidationResult("Are You from the future ??!!");
                }
                else if (DOBDiff.Days >= 0 && DOBDiff.Days < 4745) //Arbitary 13 years
                {
                    return new ValidationResult("You are too young to register");
                }
            }
            return ValidationResult.Success;
        }
    }
}