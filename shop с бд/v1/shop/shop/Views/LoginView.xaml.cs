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
using shop.Views.Admin;
using shop.Database;

namespace shop.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            //ShopDbContext.db = new Course_workEntities1();
            //loginFrame.Navigate(new LoginView());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginFrame.Navigate(new AuthView());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            loginFrame.Navigate(new RegView());
        }
    }
}
