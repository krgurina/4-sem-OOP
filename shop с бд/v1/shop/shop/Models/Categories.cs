using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace shop.Models
{
    public class Category : INotifyPropertyChanged
    {
        //[Key]
        public int CategoryId { get; set; }
        private string name;


        public string Name {
            get { return name; }
            set 
            {
                if (name == value) return;
                name = value; 
                OnPropertyChanged("Name"); 
            } 
        }
        public string ImageCategorLink { get; set; }

        public List<Product> Products { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
