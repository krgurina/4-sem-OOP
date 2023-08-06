using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using shop.Commands;
using shop.Database;
using shop.Views.Admin;
using shop.Models;
using System.Collections.ObjectModel;

namespace shop.ViewModels.Admin
{
    public class UsersViewModel : ViewModelBase
    {
        public UsersView UsersView { get; set; } = new UsersView();
        public ObservableCollection<Users> Users { get; set; }

        public UsersViewModel()
        {
            Users = new ObservableCollection<Users>(db.Users);

        }
        private DelegateCommand deleteProducеCommand;
        public ICommand DeleteProducеCommand
        {
            get
            {
                if (deleteProducеCommand == null)
                {
                    deleteProducеCommand = new DelegateCommand(() =>
                    {

                        if (MessageBox.Show("вы действительно хотите удалить этого пользователя?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Product CurrentItem = (Product)AddProductView.ProductsGrid.SelectedItem;
                            var CurrentItem = UsersView.UsersGrid.SelectedItem as Users;
                            if (CurrentItem == null)
                                MessageBox.Show("Вы не выбрали пользователя!");
                            else
                            {
                                db.Users.Remove(CurrentItem);
                                Users.Remove(CurrentItem);
                                db.SaveChanges();

                                UsersView.UsersGrid.ItemsSource = Users.ToList();
                            }

                        }
                    });
                }
                return deleteProducеCommand;

            }
        }
    }
}
