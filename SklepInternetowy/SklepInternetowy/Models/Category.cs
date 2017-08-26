using System.Collections.Generic;

namespace SklepInternetowy.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Supplement> Supplements { get; set; }
    }
}