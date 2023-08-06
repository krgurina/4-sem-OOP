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
using shop.Views.Admin;
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
        public static Users CurrentUser { get; set; } = new Users();

        private void DoStartup(object sender, StartupEventArgs e)
        {
            //для авторизации
            LoginView loginView = new LoginView();
            LoginViewModel loginViewModel = new LoginViewModel();
            loginView.DataContext = loginViewModel;
            loginView.Show();

            AuthView authView = new AuthView();
            AuthViewModel authViewModel = new AuthViewModel();
            authView.DataContext = authViewModel;

            loginFrame = loginView.loginFrame;
            loginFrame.Content = authView;

            //получить текущего пользователя
            //CurrentUser=


            //для добавления товаров
            //Views.Admin.Admin adminView = new Views.Admin.Admin();
            //AdminViewModel adminViewModel = new AdminViewModel();
            //adminView.DataContext = adminViewModel;
            //adminView.Show();

            //AddProductView addProductView = new AddProductView();
            //AddProductViewModel addProductViewModel = new AddProductViewModel();
            //addProductView.DataContext = addProductViewModel;

            //frame = adminView.frame;
            //frame.Content = addProductView;


            //поиск
            //MainWindow mainWindow = new MainWindow();
            //MainViewModel mainViewModel = new MainViewModel();
            //mainWindow.DataContext = mainViewModel;
            //mainWindow.Show();

            //SearchView searchView = new SearchView();
            //SearchViewModel searchViewModel = new SearchViewModel();
            //searchView.DataContext = searchViewModel;

            //mainFrame = mainWindow.mainFrame;
            //mainFrame.Content = searchView;



        }
        public static void OpenReg()
        {
            RegView regView = new RegView();
            RegViewModel regViewModel = new RegViewModel();
            regView.DataContext = regViewModel;

            loginFrame.Content = regView;
        }


        public static void StartAdmin()
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

        public static void StartUser()
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

        public static void OpenAdminCategory()
        {
            CategoriesView categoriesView = new CategoriesView();
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesView.DataContext = categoriesViewModel;

            frame.Content = categoriesView;
        }
        public static void OpenAdminProducts()
        {
            AddProductView addProductView = new AddProductView();
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductView.DataContext = addProductViewModel;

            frame.Content = addProductView;
        }
        public static void OpenAdminUsers()
        {
            UsersView usersView = new UsersView();
            UsersViewModel usersViewModel = new UsersViewModel();
            usersView.DataContext = usersViewModel;

            frame.Content = usersView;
        }
        public static void OpenAdminOrders()
        {
            OrdersView ordersView = new OrdersView();
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            ordersView.DataContext = ordersViewModel;

            frame.Content = ordersView;
        }

        public static void OpenUserCab()
        {
            UserCabView userCabView = new UserCabView();
            UserCabViewModel userCabViewModel = new UserCabViewModel();
            userCabView.DataContext = userCabViewModel;

            mainFrame.Content = userCabView;
        }
        public static void OpenCart()
        {
            CartView cartView = new CartView();
            CartViewModel cartViewModel = new CartViewModel();
            cartView.DataContext = cartViewModel;

            mainFrame.Content = cartView;
        }

        public static void OpenAboutUs()
        {
            AboutUsView aboutUsView = new AboutUsView();
            AboutUsViewModel aboutUsViewModel = new AboutUsViewModel();
            aboutUsView.DataContext = aboutUsViewModel;

            mainFrame.Content = aboutUsView;
        }

        public static void OpenHome()
        {
            HomeView homeView = new HomeView();
            HomeViewModel homeViewModel = new HomeViewModel();
            homeView.DataContext = homeViewModel;

            mainFrame.Content = homeView;
        }
    }
}
