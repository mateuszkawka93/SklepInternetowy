using SklepInternetowy.Models;
using System.Collections.Generic;

namespace SklepInternetowy.ViewModels
{
    public class CartViewModel
    {
        public List<CartPosition> CartPositions { get; set; }
        public decimal TotalPrice { get; set; }
    }
}