using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace FullStackCourse1.Core.ViewModels
{
    public class ValideTime: ValidationAttribute 
    {
        public override bool IsValid(object value)
        {
            DateTime dt;

            var isValide = DateTime.TryParseExact(Convert.ToString(value),
                "H:mm",
                new CultureInfo("en-US"),
                DateTimeStyles.None,
                out dt);

            return isValide;
        }
    }
}