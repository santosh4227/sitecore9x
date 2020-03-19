using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PluralSight.Models;
using PluralSight.ViewModels;
namespace PluralSight.Controllers
{
    public class PieController : Controller
    {

        private readonly ICategoryRepository _CR;
        private readonly IPieRepository _PR;

        public PieController(ICategoryRepository CR, IPieRepository PR)
        {
            _CR = CR;
            _PR = PR;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _PR.AllPie.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _PR.AllPie.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _CR.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }



        public IActionResult Details(int id) {
            var pie = _PR.GetPie(id);
            if (pie == null) {
                return NotFound();
            }
            return View(pie);
        }
    }
}