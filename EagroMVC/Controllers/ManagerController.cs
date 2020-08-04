using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eagro.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EagroMVC.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private IBasketManager bskMngr;
        private IProductManager prdMngr;
        private IOrderManager ordrMngr;



        public ManagerController(IBasketManager _bskMngr, IProductManager _prdMngr,
            IOrderManager _ordrMngr, IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
            bskMngr = _bskMngr;
            prdMngr = _prdMngr;
            ordrMngr = _ordrMngr;
        }
    }
}
