using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using shop.ViewModels;
using shop.ViewModels.Admin;
using shop.Views;
using shop.Database;
using shop.Models;

namespace shop
{

    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Frame loginFrame { get; set; } = new Frame();
        private static Frame frame { get; set; } = new Frame();
        private static Frame mainFrame { get; set; } = new Frame();

        private void DoStartup(object sender, StartupEventArgs e)
        {
            //для авторизации
            //LoginView loginView = new LoginView();
            //LoginViewModel loginViewModel = new LoginViewModel();
            //loginView.DataContext = loginViewModel;
            //loginView.Show();

            //AuthView authView = new AuthView();
            //AuthViewModel authViewModel = new AuthViewModel();
            //authView.DataContext = authViewModel;

            //loginFrame = loginView.loginFrame;
            //loginFrame.Content = authView;

            //для добавления товаров
            Views.Admin.Admin adminView = new Views.Admin.Admin();
            AdminViewModel adminViewModel = new AdminViewModel();
            adminView.DataContext = adminViewModel;
            adminView.Show();

            AddProductView addProductView = new AddProductView();
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductView.DataContext = addProductViewModel;

            frame = adminView.frame;
            frame.Content = addProductView;



        }

        private void StartAdmin(object sender, StartupEventArgs e)
        {
            Views.Admin.Admin adminView = new Views.Admin.Admin();
            AdminViewModel adminViewModel = new AdminViewModel();
            adminView.DataContext = adminViewModel;
            adminView.Show();

            AddProductView addProductView = new AddProductView();
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductView.DataContext = addProductViewModel;

            frame = adminView.frame;
            frame.Content = addProductView;

        }

        private void StartUser(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

            HomeView homeView = new HomeView();
            HomeViewModel homeViewModel = new HomeViewModel();
            homeView.DataContext = homeViewModel;

            mainFrame = mainWindow.mainFrame;
            mainFrame.Content = homeView;

        }
    }
}
