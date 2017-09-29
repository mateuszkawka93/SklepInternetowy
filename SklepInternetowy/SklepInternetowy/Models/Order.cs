using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Wprowadź imię!")]
        [StringLength(40)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko!")]
        [StringLength(40)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Wprowadź ulicę!")]
        [StringLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Wprowadź miasto!")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź kod pocztowy!")]
        [StringLength(6)]
        public string Zipcode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderValue { get; set; }

        public List<OrderPosition> OrderPositions { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Completed
    }
}