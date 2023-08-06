using shop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using shop.Models;
using shop.Views;
using System.Collections.ObjectModel;

namespace shop.ViewModels.Admin
{
    public class AddProductViewModel : ViewModelBase
    {
        AddProductView addProductView { get; set; } = new AddProductView();
        public ObservableCollection<Category> Categories { get; set; }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
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
        public AddProductViewModel()
        {
            //Categories = new ObservableCollection<Category>(db.Categories);
        }

        private DelegateCommand addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (addProductCommand == null)
                {
                    addProductCommand = new DelegateCommand(() =>
                    {
                        MessageBox.Show("начало добавления продукта");

                        //добавление продукта(поменять для другого типа подключения бд)
                        Product product = new Product();
                        product.Title = Title;
                        product.Category = Category;//selectedCategory.Name;
                        product.Price = Convert.ToInt32(Price);///
                        product.Rating = Convert.ToInt32(Rating);
                        product.Description = Description;
                        product.ImageLink = ImageLink;

                        db.Products.Add(product);
                        db.SaveChanges();

                        addProductView.ProductsGrid.ItemsSource = db.Products.ToList();
                    });
                }
                return addProductCommand;

            }
        }


    }
}
