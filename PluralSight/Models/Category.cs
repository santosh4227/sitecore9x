using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSight.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string description { get; set; }
        public List<Pie> pies { get; set; }
    }
}
