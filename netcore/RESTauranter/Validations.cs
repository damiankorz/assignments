using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter
{
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime inputDate = (DateTime)date;
            return inputDate < DateTime.Now;
        }
    }
}