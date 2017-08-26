using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Models;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class HomeController : Controller
    {
        private SupplementsContext db = new SupplementsContext();


        public ActionResult Index()
        {
            Category category = new Category()
            {
                CategoryName = "Witaminy i minerały",
                IconFileName = "Witaminy.png",
                CategoryDescription = "Najważniejsze elementy zapewniające zdrowie, energię i witalność"
            };

            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }
    }
}