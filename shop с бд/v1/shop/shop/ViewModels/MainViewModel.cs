using shop.Commands;
using shop.Database;
using shop.SingletonView;
using shop.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using shop.Models;
using System.Collections.ObjectModel;

namespace shop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //public ObservableCollection<Product> products = new ObservableCollection<Product>();
        //
        //

        //хз что это
        //private ViewModelBase currentViewModel;

        //public ViewModelBase CurrentViewModel
        //{
        //    get { return currentViewModel; }
        //    set
        //    {
        //        currentViewModel = value;
        //        OnPropertyChanged("CurrentViewModel");
        //    }
        //}
        //public MainViewModel()
        //{
        //    Singleton.getInstance(this);
        //    CurrentViewModel = new AdminViewModel();
        //}
       
        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
       

        
        //private Command openAdmin;
        //public ICommand OpenAdmin
        //{
        //    get
        //    {
        //        return openAdmin ??
        //         (openAdmin = new Command(obj =>
        //         {
        //             Singleton.getInstance(null).MainViewModel.CurrentViewModel = new AdminViewModel();
        //         }));
        //    }
        //}
       
    }
}
