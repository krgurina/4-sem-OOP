using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public Users User { get; set; }
        public Product Product { get; set; }
        public string ReviewContent { get; set; } = string.Empty;
        public int Likes { get; set; } = default;
        public int Dislikes { get; set; } = default;
    }
}
