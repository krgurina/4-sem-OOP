using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using shop.ViewModels;

namespace shop.Models
{
    public class Product : ViewModelBase
    {
        public int ID { get; set; } 
        public string Title { get; set; }
        public double Price { get; set; } = default;
        public double Rating { get; set; } = default;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public string ImageLink { get; set; } = string.Empty;



    }
}
