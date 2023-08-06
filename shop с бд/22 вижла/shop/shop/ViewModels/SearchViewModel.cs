using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.Models;
using shop.Database;
using System.Collections.ObjectModel;
using shop.Views;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using shop.Commands;
using System.Windows;

namespace shop.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        //CartViewModel CartViewModel = new CartViewModel();
        public ObservableCollection<Category> Categories { get; set; }

        private ObservableCollection<Product> products { get; set; }
       // private ObservableCollection<Product> productsInCart { get; set; }
        public ObservableCollection<Product> SearchProducts { get; set; }
        public ObservableCollection<Product> SortProducts { get; set; }

        private ObservableCollection<Product> productsInCart;
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

        public string SelectedSort { get; set; }
        public int SelectedSortIndex { get; set; }
        public Product SelectedProduct { get; set; }

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        ///\\\\///////
        //public ObservableCollection<Product> ProductsInCart
        //{
        //    get
        //    {
        //        return productsInCart;
        //    }
        //    set
        //    {
        //        productsInCart = value;
        //        OnPropertyChanged(nameof(ProductsInCart));
        //    }
        //}
        /// <summary>
        /// 

       // public ObservableCollection<Product> ProductsInCart { get; set; } = new ObservableCollection<Product>();



        /// </summary>
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        private double minValue;
        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = Math.Round(value, 2);
                OnPropertyChanged("MinValue");
            }
        }
        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = Math.Round(value);
                OnPropertyChanged("MaxValue");
            }
        }
        private int productsCount;
        public int ProductsCount
        {
            get { return productsCount; }
            set
            {
                productsCount = Products.Count();
                OnPropertyChanged("ProductsCount");
            }
        }
        public string textForSearch { get; set; }


        public SearchViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products);
            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Rating));
            Products = new ObservableCollection<Product>(SortProducts);
            Categories = new ObservableCollection<Category>(db.Categories);
            //ProductsCount = Products.Count();

        }

        private DelegateCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(() =>
                    {
                        Products = new ObservableCollection<Product>(db.Products.Where(x => x.Title.Contains(textForSearch)));
                    });
                }
                return searchCommand;

            }
        }

        //добавление в корзину
        private DelegateCommand addToCart;
        public ICommand AddToCart
        {
            get
            {
                if (addToCart == null)
                {
                    addToCart = new DelegateCommand(() =>
                    {
                        //CartViewModel.ProductsInCart.Add(SelectedProduct);
                        //MessageBox.Show(CartViewModel.ProductsInCart.Count.ToString());
                       

                        Cart cart = new Cart();
                        cart.Count = 1;
                        cart.Product = SelectedProduct;
                        cart.User = App.CurrentUser;
                        cart.SumPrice = SelectedProduct.Price * cart.Count;

                        db.Carts.Add(cart);
                        db.SaveChanges();
                        //Products.Add(product);

                    });
                }
                return addToCart;

            }
        }

        //фильтрация
        //криво косо 
        private DelegateCommand filterCommand;
        public ICommand FilterCommand
        {
            get
            {
                if (filterCommand == null)
                {
                    filterCommand = new DelegateCommand(() =>
                    {
                        if (SelectedCategory != null && MaxValue != 0)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Price >= MinValue && x.Price <= MaxValue && x.Category.Name == SelectedCategory.Name));

                        }

                        if (SelectedCategory != null && MinValue == 0 && MaxValue == 0)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Category.Name == SelectedCategory.Name));

                        }
                        if (MaxValue!=0 && SelectedCategory == null)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Price >= MinValue && x.Price <= MaxValue));

                        }

                        if (SelectedSortIndex == 0)
                        {
                            //Products = new ObservableCollection<Product>(db.Products.OrderBy(x => x.Price));
                            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Price));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        if (SelectedSortIndex == 1)
                        {
                            SortProducts = new ObservableCollection<Product>(Products.OrderByDescending(x => x.Price));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        if (SelectedSortIndex == 2)
                        {
                            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Rating));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        ProductsCount = Products.Count();
                    });
                }
                return filterCommand;

            }
        }
        private DelegateCommand showAllCommand;
        public ICommand ShowAllCommand
        {
            get
            {
                if (showAllCommand == null)
                {
                    showAllCommand = new DelegateCommand(() =>
                    {
                        Products = new ObservableCollection<Product>(db.Products);

                    });
                }
                ProductsCount = Products.Count();
                return showAllCommand;

            }
        }





    }
}
