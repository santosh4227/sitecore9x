using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PluralSight.Models;
using PluralSight.Models.Features.Navigation;
using PluralSight.ViewModels;
namespace PluralSight.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository PR;
        private readonly NavigationConfiguration NC;
        public HomeController(IPieRepository o, IOptions<NavigationConfiguration> options)
        {
            PR = o;
            NC = options.Value;
        }
        public IActionResult Index()
        {
            var vm = new HomeViewModel { PieOfTheWeeks = PR.PiesOfTheWeek, NC=this.NC };

            return View(vm);
        }
    }
}