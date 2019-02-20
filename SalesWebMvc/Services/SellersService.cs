using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
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

        public async Task<List<Sellers>> FindAllAsync()
        {

            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Sellers objeto)
        {
            _context.Add(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task<Sellers> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(objeto => objeto.Departments).FirstOrDefaultAsync(objeto => objeto.Id == id);

        }
        public async Task RemoveAsync(int id)
        {
            try { 
            var objeto = await _context.Sellers.FindAsync(id);
             _context.Sellers.Remove(objeto);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e){
                throw new IntegrityException("Esse Vendedor Possui Vendas.");

            }

        }

        public async Task UpdateAsync(Sellers objeto)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == objeto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {

                _context.Update(objeto);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
