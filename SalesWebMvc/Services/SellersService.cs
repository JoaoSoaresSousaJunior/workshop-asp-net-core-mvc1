using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellersService
    {
        public readonly SalesWebMvcContext _context;

        public SellersService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Sellers> FindAll()
        {

            return _context.Sellers.ToList();
        }

        public void Insert(Sellers objeto)
        {
            _context.Add(objeto);
            _context.SaveChanges();
        }
    }
}
