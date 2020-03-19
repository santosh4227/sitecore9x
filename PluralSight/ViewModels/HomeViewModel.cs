using PluralSight.Models;
using PluralSight.Models.Features.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSight.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Pie> PieOfTheWeeks { get; set; }

        public NavigationConfiguration NC {get; set;}
    }
}
