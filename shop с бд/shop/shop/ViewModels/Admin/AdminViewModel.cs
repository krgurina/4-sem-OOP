using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using shop.Views.Admin;
using shop.Commands;
using shop.SingletonView;
using System.Windows;
using shop.ViewModels.Admin;
using shop.Models;
using System.Windows.Controls;

namespace shop.ViewModels.Admin
{
    public class AdminViewModel : ViewModelBase
    {
        
        private DelegateCommand openCategoriesCommand;
        public ICommand OpenCategoriesCommand
        {
            get
            {
                if (openCategoriesCommand == null)
                {
                    openCategoriesCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminCategory();
                    });
                }
                return openCategoriesCommand;

            }
        }

        private DelegateCommand openProductsCommand;
        public ICommand OpenProductsCommand
        {
            get
            {
                if (openProductsCommand == null)
                {
                    openProductsCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminProducts();
                    });
                }
                return openProductsCommand;

            }
        }

        private DelegateCommand openUsersCommand;
        public ICommand OpenUsersCommand
        {
            get
            {
                if (openUsersCommand == null)
                {
                    openUsersCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminUsers();
                    });
                }
                return openUsersCommand;

            }
        }

        private DelegateCommand openOdersCommand;
        public ICommand OpenOdersCommand
        {
            get
            {
                if (openOdersCommand == null)
                {
                    openOdersCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminOrders();
                    });
                }
                return openOdersCommand;

            }
        }







    }
}
