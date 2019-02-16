using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Models
{
    public class SalesRecords
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double Quantidade { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public Sellers Sellers { get; set; }
        public SalesRecords()
        {
        }

        public SalesRecords(int id, DateTime dataVenda, double quantidade, SaleStatus saleStatus, Sellers sellers)
        {
            Id = id;
            DataVenda = dataVenda;
            Quantidade = quantidade;
            SaleStatus = saleStatus;
            Sellers = sellers;
        }
    }
}
