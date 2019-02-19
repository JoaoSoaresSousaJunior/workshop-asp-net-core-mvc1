
using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellersFormViewModel
    {
        public Sellers Sellers { get; set; }
        public ICollection<Departments> Departments { get; set; }
    }
}
