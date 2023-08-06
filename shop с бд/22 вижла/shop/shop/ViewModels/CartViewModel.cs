using shop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace shop.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private ObservableCollection<Cart> userCart;
        public ObservableCollection<Cart> UserCart
        {
            get
            {
                return userCart;
            }
            set
            {
                userCart = value;
                OnPropertyChanged(nameof(UserCart));
            }
        }
        private ObservableCollection<Product> productsInCart { get; set; }
        public ObservableCollection<Product> ProductsInCart
        {
            get
            {
                return productsInCart;
            }
            set
            {
                productsInCart = value;
                OnPropertyChanged(nameof(ProductsInCart));
            }
        }


        public CartViewModel()
        {
            //выводит товары определенного пользователя, но цена и количество должны быть из типа Cart
            //ProductsInCart = new ObservableCollection<Product>(db.Carts.Where(x => x.User.ID == App.CurrentUser.ID).Select(x=>x.Product));

            UserCart = new ObservableCollection<Cart>(db.Carts.Where(x => x.User.ID == App.CurrentUser.ID));
           
            
            //var cattt = db.Carts.Select(c=> new
           //{
           //    Cart=c,
           //    Product=c.Product.Select
           //})

        }
    }
}
