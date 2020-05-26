using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Web.Core.ViewModels
{
    public class ValideDate: ValidationAttribute 
    {
        public override bool IsValid(object value)
        {
            DateTime dt;

            var isValide = DateTime.TryParseExact(Convert.ToString(value),
                "dd MMM yyyy",
                new CultureInfo("en-US"),
                DateTimeStyles.None,
                out dt);

            return isValide;
        }
    }
}