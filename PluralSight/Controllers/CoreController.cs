using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PluralSight.Models.Features.Navigation;
using PluralSight.Services;

namespace PluralSight.Controllers
{
    public class CoreController : Controller
    {

        private readonly NavigationConfiguration NC;
        private readonly GuidService guidService;
        private readonly SingletonService singletonService;
        private readonly ScopeService scopeService;
        public CoreController(IOptions<NavigationConfiguration> options, GuidService _gs, SingletonService _singletonService, ScopeService _scopeService)
        {
            NC = options.Value;
            guidService = _gs; singletonService = _singletonService; scopeService = _scopeService;

        }

        public IActionResult ServiceLifeCycle()
        {
            return View(new Tuple<GuidService, SingletonService, ScopeService>(guidService, singletonService, scopeService));
        }

        //public IActionResult ServiceLifeCycle2()
        //{
        //    return View(new Tuple<GuidService, SingletonService, ScopeService>(guidService, singletonService, scopeService));
        //}


        public IActionResult Index()
        {

            return View(NC);
        }
    }
}