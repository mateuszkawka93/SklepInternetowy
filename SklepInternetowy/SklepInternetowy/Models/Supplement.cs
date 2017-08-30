using System;
using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.Models
{
    public class Supplement
    {
        public int SupplementId { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę produktu!")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wprowadź producenta!")]
        [StringLength(100)]
        public string Producer { get; set; }

        public DateTime AddTime { get; set; }

        [StringLength(100)]
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
        public string ShortDescription { get; set; }

        public virtual Category Category { get; set; }
    }
}