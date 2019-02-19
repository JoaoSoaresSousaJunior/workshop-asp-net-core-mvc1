using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        public readonly SalesWebMvcContext _context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Departments> FindAll()
        {
            return _context.Departments.OrderBy(x => x.Descricao).ToList();
        }

    }
}
