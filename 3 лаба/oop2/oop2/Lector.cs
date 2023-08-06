using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace oop2
{
    public class Lector
    {
        [Required]
        public string kafedra { get; set; }
        [Required]
        [RegularExpression(@"^[а-яА-Я]{3,}$", ErrorMessage = "Разрешены только буквы русского алфавита")]
        public string FIO { get; set; }
        //[UserAudience]
        [Required]
        public string audience { get; set; }

        public Lector(string FIO, string kafedra, string audience)
        {
            this.kafedra = kafedra;
            this.FIO = FIO;
            this.audience = audience;
        }
        public Lector() { }
        public override string ToString()
        {
            return "\nЛектор: " + this.FIO + "\nкафедра: " + this.kafedra + "\nаудитрия: " + this.audience + "\n===============================\n";
        }
    }
}
