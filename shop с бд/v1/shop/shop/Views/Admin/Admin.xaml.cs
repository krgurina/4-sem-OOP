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
using System.Windows.Shapes;

namespace shop.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new CategoriesView());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AddProductView());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new OrdersView());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new UsersView());
        }
    }
}
