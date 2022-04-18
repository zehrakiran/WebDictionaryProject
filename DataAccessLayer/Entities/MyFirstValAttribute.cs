﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class MyFirstValAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "Değer boş olamaz";
                return false;
            }
            if (value.ToString().ToUpperInvariant() == "Kelime".ToUpperInvariant())
            {
                ErrorMessage = "Boş olamaz";
                return false;
            }
            return true;
        }
    }
}
