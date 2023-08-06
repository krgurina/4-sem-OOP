using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace shop.Models
{
    public class Users
    {
        //[Key]
        // public int Id { get; set; }
        // //[Required(ErrorMessage = "Имя пользователя обязательно")]
        // //[StringLength(20, MinimumLength = 5, ErrorMessage = "Имя должно быть не менее 5 и не более 20 символов")]
        // //[RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Логин должен состоять только из английских символов и цифр")]

        // //[RegularExpression(@"^[A-Z]{1}[a-z]+", ErrorMessage = "Имя должно начинатсья с большой буквы и написано латинецей")]
        // public string Name { get; set; }

        // //[RegularExpression(@"^[A-Z]{1}[a-z]+", ErrorMessage = "Фамилия должно начинатсья с большой буквы и написано латинецей")]
        // public string Surname { get; set; }
        // public string Login { get; set; }
        // //[Required(ErrorMessage = "Пароль обязателен")]
        // //[RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Пароль должен состоять только из английских символов и цифр")]
        // public string Password { get; set; }


        //// [Required(ErrorMessage = "Электронная почта обязательна")]
        // //[RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        // public string Email { get; set; }
        // public string Phone { get; set; }


        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
