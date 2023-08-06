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
using System.Windows.Media.Animation;

namespace shop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //public ObservableCollection<Product> products = new ObservableCollection<Product>();
        public static RoutedCommand Exit { get; set; }

        //корзина
        private DelegateCommand openCartCommand;
        public ICommand OpenCartCommand
        {
            get
            {
                if (openCartCommand == null)
                {
                    openCartCommand = new DelegateCommand(() =>
                    {
                        App.OpenCart();
                    });
                }
                return openCartCommand;

            }
        }

        //личный кабинет
        private DelegateCommand openUserCommand;
        public ICommand OpenUserCommand
        {
            get
            {
                if (openUserCommand == null)
                {
                    openUserCommand = new DelegateCommand(() =>
                    {
                        App.OpenUserCab();
                    });
                }
                return openUserCommand;

            }
        }

        //о нас
        private DelegateCommand openAboutUsCommand;
        public ICommand OpenAboutUsCommand
        {
            get
            {
                if (openAboutUsCommand == null)
                {
                    openAboutUsCommand = new DelegateCommand(() =>
                    {
                        App.OpenAboutUs();
                    });
                }
                return openAboutUsCommand;

            }
        }

        //главная
        private DelegateCommand openHomePageCommand;
        public ICommand OpenHomePageCommand
        {
            get
            {
                if (openHomePageCommand == null)
                {
                    openHomePageCommand = new DelegateCommand(() =>
                    {
                        App.OpenHome();
                    });
                }
                return openHomePageCommand;

            }
        }
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

        private DelegateCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new DelegateCommand(() =>
                    {
                        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                        DoubleAnimation animation = new DoubleAnimation
                        {
                            From = 1.0,
                            To = 0.0,
                            Duration = TimeSpan.FromSeconds(0.5)
                        };
                        animation.Completed += (s, e) =>
                        {
                            window.Visibility = Visibility.Hidden;
                            App.StartAdmin();
                            window.Close();
                        };
                        window.BeginAnimation(UIElement.OpacityProperty, animation);

                    });
                }
                return closeCommand;

            }
        }
        //public MainViewModel()
        //{
        //    Exit = new RoutedCommand("Exit", typeof(MainWindow));

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
       

        
       
    }
}
