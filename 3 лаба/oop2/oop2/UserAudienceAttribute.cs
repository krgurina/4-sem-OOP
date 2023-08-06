using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace oop2
{
    public class SemesterValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int semesterName)
            {
                if (semesterName == 1 || semesterName == 2)
                    return true;
                else
                    ErrorMessage = "Некорректный номер семестра.";
            }
            return false;
        }
    }
    public class UserAudienceAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            //if (value == null)
            //    return false;

            //if (!(value is int))
            //    return false;

            //if (value.GetType() != typeof(int))
            //    return false;

            //if (((int)value < 100) || ((int)value > 500))
            //    return false;
            //return true;

            if (value is string audience)
            {
                //var data = new string[] { lector.audience };
                string pattern = @"(1|2|3|4{1}[0-4]{1}[0-9]{1}-[1-4]{1})";
                //string pattern = @"[0-9]{3}";

                for (int i = 0; i < audience.Length; i++)
                {
                    if (!Regex.IsMatch(audience[i].ToString(), pattern))
                    {
                        ErrorMessage = "Некорректный номер аудитории (Пример: 134-4)";
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
