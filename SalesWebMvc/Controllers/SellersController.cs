using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;

        public SellersController(SellersService sellersService)
        {
            _sellersService = sellersService;
        }

        public IActionResult Index()
        {
            var list = _sellersService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sellers sellers)
        {
            _sellersService.Insert(sellers);


            return RedirectToAction(nameof(Index));
        }


    }
}