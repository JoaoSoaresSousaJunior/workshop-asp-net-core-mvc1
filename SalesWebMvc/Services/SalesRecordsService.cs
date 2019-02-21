using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordsService
    {
        public readonly SalesWebMvcContext _context;

        public SalesRecordsService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecords>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataVenda >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataVenda <= maxDate.Value);
            }

            return await result
                   .Include(x => x.Sellers)
                   .Include(x => x.Sellers.Departments)
                   .OrderByDescending(x => x.DataVenda)
                   .ToListAsync();
        }


    }
}
