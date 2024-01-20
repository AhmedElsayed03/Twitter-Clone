using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.CustomValidations
{
    public class MustBePlusEighteen : ValidationAttribute
    {
        public override bool IsValid(object? value)
         => value is DateTime date && (DateTime.Now - date).Days >= 6570;

        //public override bool IsValid(object? value)
        //{
        //    DateTime? date = value as DateTime?;
        //    TimeSpan subDates = (TimeSpan)(DateTime.Now - date);
        //    if (date == null)
        //    {

        //        return false;
        //    }

        //    else if (subDates.Days >= 6570)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

    }
}
