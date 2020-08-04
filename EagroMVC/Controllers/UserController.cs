using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eagro.Models;
using eagro.Options;
using eagro.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EagroMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private IBasketManager bskMngr;
        private IProductManager prdMngr;
        private IOrderManager ordrMngr;



        public UserController(IBasketManager _bskMngr, IProductManager _prdMngr,
            IOrderManager _ordrMngr, IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
            bskMngr = _bskMngr;
            prdMngr = _prdMngr;
            ordrMngr = _ordrMngr;
        }

        [HttpPost]
        public Product AddProduct([FromBody] ProductOption prodOpt)
        {
            return prdMngr.CreateProduct(prodOpt);
        }

    }
}
