using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private const string Format = "yyyy-MM-dd";
              private readonly SalesRecordsService _salesRecordsService;
        public IActionResult Index()
        {
            return View();
        }

        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate,DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now; 
            }

            ViewData["minDate"] = minDate.Value.ToString(Format);
            ViewData["maxDate"] = maxDate.Value.ToString(Format);
            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate); 
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}