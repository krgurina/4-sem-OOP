using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.SingletonView;

namespace shop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //ViewModelBase curViewModel;
        //public ViewModelBase CurrentViewModel
        //{
        //    get { return curViewModel; }
        //    set
        //    {
        //        curViewModel = value;
        //        OnPropertyChanged("CurrentViewModel");
        //    }
        //}
        //public LoginViewModel()
        //{
        //    SingletonAuth.getInstance(this);
        //    CurrentViewModel = new AuthViewModel();
        //}
        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}
