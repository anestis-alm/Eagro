using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EagroMVC.Models;
using Microsoft.AspNetCore.Authorization;
using eagro.Repository;
using eagro.Services;

namespace EagroMVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EagroDbContext _db;
        private IBasketManager _bskMng;
        private IOrderManager _ordrMng;
        private IProductManager _prdMng;
        private ICustomerManager _cstMng;

        public HomeController(ILogger<HomeController> logger, EagroDbContext db, IBasketManager bskMng, 
            IOrderManager ordrMng, IProductManager prdMng, ICustomerManager cstMng)
        {
            _logger = logger;
            _db = db;
            _bskMng = bskMng;
            _ordrMng = ordrMng;
            _prdMng = prdMng;
            _cstMng = cstMng;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
