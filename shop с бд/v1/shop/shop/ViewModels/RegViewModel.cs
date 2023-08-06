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

namespace shop.ViewModels
{
    public class RegViewModel : ViewModelBase
    {
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
                        //LoginView loginView = new LoginView();
                        //LoginViewModel loginViewModel = new LoginViewModel();
                        //loginView.DataContext = loginViewModel;
                        ////loginView.Show();

                        //RegView regView = new RegView();
                        //RegViewModel regViewModel = new RegViewModel();
                        //regView.DataContext = regViewModel;

                        ////loginView.loginFrame.Navigate(new RegView());     // вызывает 
                        ////loginView.loginFrame.Content = regView;
                        //loginFrame = loginView.loginFrame;
                        //loginFrame.Content = regView;

                    });
                }
                return regUserCommand;

            }
        }
    }
}
