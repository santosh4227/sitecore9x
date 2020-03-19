using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PluralSight.Models;
namespace PluralSight.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies;

        public string CurrentCategory;
    }
}
