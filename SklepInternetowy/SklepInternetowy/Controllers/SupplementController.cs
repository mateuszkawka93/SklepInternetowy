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

            var supplement = categories.Supplements.ToList();
            return View(supplement);
        }

        public ActionResult Details(int id)
        {
            var supplement = db.Supplements.Find(id);
            
            return View(supplement);
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }

       
    }
}