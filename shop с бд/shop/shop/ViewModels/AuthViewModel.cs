using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using shop.Commands;
using shop.Database;
using shop.ViewModels;
using shop.ViewModels.Admin;
using shop.Views;
using shop.Views.Admin;
using shop.Models;

using shop.SingletonView;
namespace shop.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
       
        //логин
        private string login;

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        // пароль
        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                this.errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        private DelegateCommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand(() =>
                    {
                        App.CurrentUser = db.Users.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
                        //Users CurrentUser = db.Users.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();

                        if (App.CurrentUser != null)
                        {
                            if (App.CurrentUser.Login == "admin")
                            {
                                MessageBox.Show("админ");
                                App.StartAdmin();
                                //для админа

                            }
                            else
                            {
                                MessageBox.Show("пользователь");
                                App.StartUser();
                            }
                        }
                        else
                        {
                            MessageBox.Show("такого пользователя нет");
                        }
                    });
                }
                
                return loginCommand;

            }
        }

       
        private DelegateCommand openRegCommand;
        public ICommand OpenRegCommand
        {
            get
            {
                if (openRegCommand == null)
                {
                    openRegCommand = new DelegateCommand(() =>
                    {
                        App.OpenReg();
                    });
                }
                return openRegCommand;

            }
        }
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
    }
}
