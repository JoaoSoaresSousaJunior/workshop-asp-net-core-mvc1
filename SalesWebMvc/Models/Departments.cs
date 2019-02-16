using System;
using System.Collections.Generic;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Sellers> Sellers { get; set; } = new List<Sellers>();

        public Departments()
        {
        }

        public Departments(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void AddSellers(Sellers seller)
        {
            Sellers.Add(seller);
        }

        public void RemoveSellers(Sellers seller)
        {
            Sellers.Remove(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial,final));
        }
    }
}
