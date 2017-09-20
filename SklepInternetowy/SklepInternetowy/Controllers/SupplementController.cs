using SklepInternetowy.Data_Access_Layer;
using System.Linq;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class SupplementController : Controller
    {
        private SupplementsContext db = new SupplementsContext();

        // GET: Supplement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryname)
        {
            var categories =
                db.Categories
                    .Include("Supplements")
                    .Single(a => a.CategoryName.ToUpper() == categoryname.ToUpper());

            var products = categories.Supplements.ToList();
            return View(products);
        }

        public ActionResult Details(string id)
        {
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }

       
    }
}