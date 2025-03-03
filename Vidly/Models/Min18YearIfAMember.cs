﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.Unknown || customer.MembershipTypeId==MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthday == null)
                return new ValidationResult("Please enter Customer's Birthday");
            var age = DateTime.Now.Year - customer.Birthday.Value.Year;
            return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be at 18 years old to go on a membership!");
        }
    }
}