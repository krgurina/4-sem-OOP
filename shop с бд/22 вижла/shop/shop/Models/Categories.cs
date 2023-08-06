using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        //private string name;


        //public string Name {
        //    get { return name; }
        //    set 
        //    {
        //        if (name == value) return;
        //        name = value; 
        //        OnPropertyChanged("Name"); 
        //    } 
        //}

        //public List<Product> Products { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName ="")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
