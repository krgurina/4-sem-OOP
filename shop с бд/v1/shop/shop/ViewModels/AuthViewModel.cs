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
        public string login { get; set; }
        public string password { get; set; }
        private static Frame loginFrame = new Frame();
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
                        MessageBox.Show("админ");

                        //Database.USERS CurrentUser = ShopDbContext.db.USERS.Where(a => a.LOGIN == login && a.PASSWORD == password).FirstOrDefault();

                        //if (CurrentUser != null)
                        //{
                        //    if (CurrentUser.ID == 1)
                        //    {
                        //        MessageBox.Show("админ");
                        //        //для админа
                        //        Views.Admin.Admin adminView = new Views.Admin.Admin();
                        //        AdminViewModel adminViewModel = new AdminViewModel();
                        //        adminView.DataContext = adminViewModel;
                        //        adminView.Show();

                        //        //HomeAdminView homeAdminView = new HomeAdminView();
                        //        //HomeAdminViewModel homeAdminViewModel = new HomeAdminViewModel();
                        //        //homeAdminView.DataContext = homeAdminViewModel;

                        //        //adminView.adminFrame.Content = homeAdminView;
                        //        LoginViewModel.Close();
                        //    }

                        //    //для пользователя
                        //    MessageBox.Show("пользователь");

                        //    MainWindow mainView = new MainWindow();
                        //    MainViewModel mainViewModel = new MainViewModel();
                        //    mainView.DataContext = mainViewModel;
                        //    mainView.Show();

                        //    HomeView homeView = new HomeView();
                        //    HomeViewModel homeViewModel = new HomeViewModel();
                        //    homeView.DataContext = homeViewModel;

                        //    mainView.Content = homeView;
                        //    LoginViewModel.Close();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("такого пользователя нет");
                        //}
                    });
                }
                return loginCommand;

            }
        }

        //private Command loginCommand;

        //public ICommand LoginCommand
        //{
        //    get
        //    {
        //        return loginCommand ??
        //         (loginCommand = new Command(obj =>
        //         {
        //             //var CurrentUser = ShopDbContext.db.USERS.FirstOrDefault(u => u.LOGIN == login && u.PASSWORD == password);

        //             //if (CurrentUser != null)
        //             //{
        //             //    if (CurrentUser.ID == 1)
        //             //    {
        //             //       Views.Admin.Admin mainAdmin = new Views.Admin.Admin();
        //             //        mainAdmin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //             //        mainAdmin.Show();
        //             //        LoginViewModel.Close();
        //             //    }
        //             //    else
        //             //    {
        //             //        MainWindow main = new MainWindow();
        //             //        main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //             //        main.Show();
        //             //        LoginViewModel.Close();
        //             //    }

        //             //}



        //             //try
        //             //{
        //             //    using (PartShopDbContext db = new PartShopDbContext())
        //             //    {
        //             //        User authUser = null;
        //             //        password = SecurePassService.Hash(password);
        //             //        authUser = db.Users.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
        //             //        if (authUser == null)
        //             //        {
        //             //            throw new Exception("Невозможно найти пользователя с введенными данными");
        //             //        }
        //             //        if (authUser != null)
        //             //        {
        //             //            if (authUser.Is_admin == false)
        //             //            {
        //             //                MainWindow main = new MainWindow();
        //             //                main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //             //                main.Show();
        //             //                LoginViewModel.Close();
        //             //            }
        //             //            else
        //             //            {
        //             //                MainAdminView mainAdmin = new MainAdminView();
        //             //                mainAdmin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //             //                mainAdmin.Show();
        //             //                LoginViewModel.Close();
        //             //            }
        //             //            //Settings.Default.UserMail = authUser.Email;
        //             //            //Settings.Default.UserId = authUser.Id;
        //             //        }
        //             //    }
        //             //}
        //             //catch (Exception e)
        //             //{
        //             //    ErrorMessage = e.Message;
        //             //}
        //         }));
        //    }
        //}
        private DelegateCommand openRegCommand;
        public ICommand OpenRegCommand
        {
            get
            {
                 if(openRegCommand==null)
                {
                    openRegCommand = new DelegateCommand(() =>
                    {
                        //messageBox.Show("ddd");
                        LoginView loginView = new LoginView();
                        LoginViewModel loginViewModel = new LoginViewModel();
                        loginView.DataContext = loginViewModel;
                        //loginView.Show();

                        RegView regView = new RegView();
                        RegViewModel regViewModel = new RegViewModel();
                        regView.DataContext = regViewModel;

                        //loginView.loginFrame.Navigate(new RegView());     // вызывает 
                        //loginView.loginFrame.Content = regView;
                        loginFrame = loginView.loginFrame;
                        loginFrame.Content = regView;

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
