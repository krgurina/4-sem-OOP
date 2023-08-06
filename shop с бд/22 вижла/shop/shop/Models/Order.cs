using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderState { get; set; } = string.Empty;
        public Users User { get; set; }
        public Cart Cart { get; set; }

    }
}
