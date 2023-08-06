using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using shop.Commands;
using shop.Database;
using shop.Models;
using System.Windows;
using shop.Views;
using shop.Views.Admin;

namespace shop.ViewModels.Admin
{
    public class AddProductViewModel : ViewModelBase
    {

        public string Title { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ImageLink { get; set; }
        public AddProductView AddProductView { get; set; } = new AddProductView();
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        //private Product selectedProduct;
        //public Product SelectedPart
        //{
        //    get { return selectedProduct; }
        //    set
        //    {
        //        selectedProduct = value;
        //        OnPropertyChanged("SelectedPart");
        //    }
        //}

        private Product selectedItemForDataGrid;

        public Product SelectedItemForDataGrid
        {
            get
            {
                return selectedItemForDataGrid;
            }
            set
            {
                selectedItemForDataGrid = value;
                OnPropertyChanged(nameof(SelectedItemForDataGrid));
            }
        }

        public AddProductViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products);

        }

        private DelegateCommand addProducеCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (addProducеCommand == null)
                {
                    addProducеCommand = new DelegateCommand(() =>
                    {

                        MessageBox.Show("addProducеCommand");

                        Product product = new Product();
                        product.Title = Title;
                        product.Category.Name = Category;
                        product.Price = Convert.ToDouble(Price);
                        product.Rating = 0;
                        product.Description = Description;
                        //product.CategoryId = Convert.ToInt32(CategoryId);
                        product.ImageLink = ImageLink;

                        db.Products.Add(product);
                        db.SaveChanges();
                        Products.Add(product);

                        MessageBox.Show("товар добавлен");
                    });
                }
                return addProducеCommand;

            }
        }

        private DelegateCommand changeProducеCommand;
        public ICommand ChangeProducеCommand
        {
            get
            {
                if (changeProducеCommand == null)
                {
                    changeProducеCommand = new DelegateCommand(() =>
                    {

                        MessageBox.Show("changeProducеCommand");
                        Product CurrentItem = AddProductView.ProductsGrid.SelectedItem as Product;


                        Product product = new Product();
                        product.Title = Title;
                        product.Category.Name = Category;
                        product.Price = Convert.ToDouble(Price);
                        product.Rating = 0;
                        product.Description = Description;
                        //product.CategoryId = Convert.ToInt32(CategoryId);
                        product.ImageLink = ImageLink;

                        db.Products.Add(product);
                        db.SaveChanges();
                        Products.Add(product);

                        MessageBox.Show("товар изменен");
                    });
                }
                return changeProducеCommand;

            }
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

                        if (MessageBox.Show("вы действительно хотите удалить этот товар?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            if (SelectedItemForDataGrid != null)
                            {
                                db.Products.Remove(SelectedItemForDataGrid);
                                Products.Remove(SelectedItemForDataGrid);
                                db.SaveChanges();

                            }
                            else
                            {
                                MessageBox.Show("Вы не выбрали товар!");
                            }
                            //Product CurrentItem = (Product)AddProductView.ProductsGrid.SelectedItem;
                            //var CurrentItem = AddProductView.ProductsGrid.SelectedItem as Product;
                            //if (CurrentItem == null)
                            //    MessageBox.Show("Вы не выбрали товар!");
                            //else
                            //{
                            //    db.Products.Remove(CurrentItem);
                            //    Products.Remove(CurrentItem);
                            //    db.SaveChanges();

                            //    AddProductView.ProductsGrid.ItemsSource = Products.ToList();
                            //}
                            

                        }
                    });
                }
                return deleteProducеCommand;

            }
        }

    }
}
