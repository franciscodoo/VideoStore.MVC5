using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    //custom validation must inherit from ValidationAttribute
    public class MembershipRequiresLegalAge : ValidationAttribute
    {
        //ValidationContext gives access to other model props
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)  
        {
            //ObjectInstance gives access to containing class. in this case, customer
            var customer = (Customer) validationContext.ObjectInstance; //must cast to Customer

            if (customer.MembershipTypeId == MembershipType.NotDefined || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                //If type == pay as you go, birthdate should not be validated
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success : new ValidationResult("Membership only to customers with at least 18 years old");
        }
    }
}