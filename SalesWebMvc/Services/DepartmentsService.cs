using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        public readonly SalesWebMvcContext _context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departments>> FindAllAsync()
        {
            return await _context.Departments.OrderBy(x => x.Descricao).ToListAsync();
        }

    }
}
