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

using shop.Models;
using shop.Database;


namespace shop.Views
{
    /// <summary>
    /// Логика взаимодействия для RegView.xaml
    /// </summary>

    public partial class RegView : Page
    {
        //protected int countForID = ShopDbContext.db.USERS.Count();

        public RegView()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.Name = userName.Text;
            user.Surname = userSurname.Text;
            user.Login = login.Text;
            user.Password = password.Text;
            user.Email = userEmail.Text;
            user.Phone = userPhone.Text;

            using (AppConnection db = new AppConnection())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

               
        }
    }
}
