using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Sellers
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departments Departments { get; set; }
        public ICollection<SalesRecords> SalesRecords = new List<SalesRecords>();

        public Sellers()
        {
        }

        public Sellers(int id, string nome, string email, DateTime date, double salarioBase, Departments departments)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = date;
            SalarioBase = salarioBase;
            Departments = departments;
        }

        public void AddSales(SalesRecords sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSales(SalesRecords sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.DataVenda >= initial && sr.DataVenda <= final).Sum(sr=>sr.Quantidade);
        }


    }
}
