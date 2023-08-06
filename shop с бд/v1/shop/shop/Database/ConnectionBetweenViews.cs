using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using shop.Models;


namespace shop.Database
{
    public static class ConnectionBetweenViews
    {
        public static ObservableCollection<Product> Products = new ObservableCollection<Product>();
        public static Product Product = new Product();
    }
}
