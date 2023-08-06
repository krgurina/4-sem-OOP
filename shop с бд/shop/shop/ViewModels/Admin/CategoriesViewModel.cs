using shop.Commands;
using shop.Models;
using shop.Views.Admin;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;

namespace shop.ViewModels.Admin
{
    public class CategoriesViewModel : ViewModelBase
    {
        private static Frame frame { get; set; } = new Frame();

        Views.Admin.Admin adminView = new Views.Admin.Admin();

        public ObservableCollection<Category> Categories { get; set; }
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Category>();

            //CategoriesView categoriesView = new CategoriesView();
            //CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            //categoriesView.DataContext = categoriesViewModel;

            //frame = adminView.frame;
            //frame.Content = categoriesView;
        }

        ////public string Description { get; set; }
        //private Category selectedCategory;
        //public Category SelectedCategory
        //{
        //    get { return selectedCategory; }
        //    set
        //    {
        //        selectedCategory = value;
        //        OnPropertyChanged("SelectedCategory");
        //    }
        //}
    }
}
