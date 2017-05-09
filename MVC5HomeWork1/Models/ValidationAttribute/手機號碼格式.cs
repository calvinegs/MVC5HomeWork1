using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5HomeWork1.Models.ValidationAttribute
{
    public class 手機號碼格式Attribute : DataTypeAttribute
    {
        public 手機號碼格式Attribute() : base(DataType.Text)
        {

        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            Regex regex = new Regex(@"\d{4}-\d{8}");
            Match match = regex.Match(value.ToString());
            return match.Success;
        }
    }
}