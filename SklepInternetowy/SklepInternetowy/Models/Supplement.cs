using System;

namespace SklepInternetowy.Models
{
    public class Supplement
    {
        public int SupplementId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public DateTime AddTime { get; set; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }

        public virtual Category Category { get; set; }
    }
}