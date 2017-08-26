using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Wprowadź kategorię!")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Wprowadź opis kategorii!")]
        
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Supplement> Supplements { get; set; }
    }
}