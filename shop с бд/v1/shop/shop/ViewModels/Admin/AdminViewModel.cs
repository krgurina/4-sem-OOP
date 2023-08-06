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
        private static Frame frame { get; set; } = new Frame();

        private DelegateCommand onenCategoryCommand;
        Views.Admin.Admin adminView = new Views.Admin.Admin();

        public ICommand OnenCategoryCommand
        {
            get
            {
                if (onenCategoryCommand == null)
                {
                    onenCategoryCommand = new DelegateCommand(() =>
                    {
                        //Views.Admin.Admin adminView = new Views.Admin.Admin();
                        //AdminViewModel adminViewModel = new AdminViewModel();
                        //adminView.DataContext = adminViewModel;
                        //adminView.Show();

                        CategoriesView categoriesView = new CategoriesView();
                        CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
                        categoriesView.DataContext = categoriesViewModel;

                      
                        frame = adminView.frame;
                        frame.Content = categoriesView;


                    });
                }
                return onenCategoryCommand;

            }
        }

    }
}
