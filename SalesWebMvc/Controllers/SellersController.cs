using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentsService _departmentsService;

        public SellersController(SellersService sellersService, DepartmentsService departmentsService)
        {
            _sellersService = sellersService;
            _departmentsService = departmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellersService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentsService.FindAllAsync();
            var viewModel = new SellersFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sellers sellers)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentsService.FindAllAsync();
                var viewModel = new SellersFormViewModel { Sellers = sellers, Departments = departments };
                return View(viewModel);
            };
            await _sellersService.InsertAsync(sellers);


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }
            var objeto = await _sellersService.FindByIdAsync(id.Value);
            if (objeto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(objeto);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellersService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." }); ;
            }
            var objeto = await _sellersService.FindByIdAsync(id.Value);
            if (objeto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(objeto);
        }

        public IActionResult Error(string message)
          
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." }); ;
            }
            var objeto = await _sellersService.FindByIdAsync(id.Value);
            if (objeto == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            List<Departments> departments = await _departmentsService.FindAllAsync();
            SellersFormViewModel viewModel = new SellersFormViewModel { Sellers = objeto, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Sellers sellers)
        {
             if (!ModelState.IsValid)
            {
                var departments = await _departmentsService.FindAllAsync();
                var viewModel = new SellersFormViewModel { Sellers = sellers, Departments = departments };
                return View(viewModel);
            };
            if (id != sellers.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem." }); 
            }
            try
            {
                await _sellersService.UpdateAsync(sellers);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
            {
                 return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           


        }


    }
}