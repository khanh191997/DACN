using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}
