using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using shop.Views;
using shop.ViewModels.Admin;
using shop.ViewModels;

namespace shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SearchView());

        }
        //private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    //AdminView adminView = new AdminView();
        //    //adminView.
        //    NavigationService.Navigate(new Uri("AdminView.xaml", UriKind.Relative));
        //}
        //private void GoToAdminPage(object sender, MouseButtonEventArgs e)
        //{
        //    NavigationService.Navigate(new AdminViewModel());
        //}
    }
}
