using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
   public class CartViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public Product product { get; set; }

        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }

    }
}
