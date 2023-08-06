using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.Views;
using shop.Commands;
using shop.Database;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using shop.Models;

namespace shop.ViewModels
{
    public class RegViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        //public RegViewModel()
        //{
        //    loginFrame = loginView.loginFrame;
        //    loginFrame.Content = regView;
        //}

        private DelegateCommand regUserCommand;
        public ICommand RegUserCommand
        {
            get
            {
                if (regUserCommand == null)
                {
                    regUserCommand = new DelegateCommand(() =>
                    {

                        MessageBox.Show("regUserCommand");
                        Users user = new Users();
                        user.Name = Name;
                        user.Surname = Surname;
                        user.Login = Login;
                        user.Password = Password;
                        user.Email = Email;
                        user.Phone = Phone;

                        db.Users.Add(user);
                        db.SaveChanges();

                        MessageBox.Show("вы зарегистрированы");
                    });
                }
                return regUserCommand;

            }
        }
    }
}
