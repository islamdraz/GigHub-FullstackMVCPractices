using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.Web.Core.ViewModels
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