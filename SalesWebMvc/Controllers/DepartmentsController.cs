using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departments> list = new List<Departments>();
            list.Add(new Departments { Id = 1, Descricao = "Eletrônicos" });
            list.Add(new Departments { Id = 2, Descricao = "Moda" });
            list.Add(new Departments { Id = 3, Descricao = "Brinquedos" });
            return View(list);
        }
    }
}