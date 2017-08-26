using System;
using System.Collections.Generic;

namespace SklepInternetowy.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderValue { get; set; }

        private List<OrderPosition> OrderPositions { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Completed
    }
}