using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public Sellers FindById(int id)
        {
            return _context.Sellers.Include(objeto => objeto.Departments).FirstOrDefault(objeto => objeto.Id == id);

        }
        public void Remove(int id)
        {
            var objeto = _context.Sellers.Find(id);
            _context.Sellers.Remove(objeto);
            _context.SaveChanges();
        }
    }
}
