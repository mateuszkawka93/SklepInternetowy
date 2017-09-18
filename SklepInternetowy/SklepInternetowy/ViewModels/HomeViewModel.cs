using SklepInternetowy.Models;
using System.Collections.Generic;

namespace SklepInternetowy.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplement> NewSupplements { get; set; }
        public IEnumerable<Supplement> BestsellerSupplements { get; set; }
    }
}