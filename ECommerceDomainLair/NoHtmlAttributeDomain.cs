using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerceDomainLair
{

    public class NoHtmlAttribute : ValidationAttribute
    {
        private static readonly Regex _htmlPattern =
            new(@"<[^>]*>|javascript\s*:|on\w+\s*=",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);


        protected override ValidationResult IsValid(
            object value, ValidationContext context)
        {
            if (value is string str && _htmlPattern.IsMatch(str))
                return new ValidationResult(
                    "Invalid characters detected in this field.");
            return ValidationResult.Success;
        }
    }


}
