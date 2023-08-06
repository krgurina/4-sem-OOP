using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Order
    {
        //[Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
       // public List<OrderedParts> Parts { get; set; }
        public string OrderState { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        //public int DeliveryId { get; set; }
        //
        //--ToDo: Добавить класс Delivery и создать навигационное свойство
    }
}
