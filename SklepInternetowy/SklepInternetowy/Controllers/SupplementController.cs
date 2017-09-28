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

        public ActionResult List(string categoryname, string searchQuery = null)
        {
            var categories =
                db.Categories
                    .Include("Supplements").Where(k=>k.CategoryName.ToUpper() == categoryname.ToUpper()).Single();


            var supplement = categories.Supplements.Where(a => (searchQuery == null ||
                                                                a.Name.ToLower().Contains(searchQuery.ToLower()) ||
                                                                a.Producer.ToLower().Contains(searchQuery.ToLower())) &&
                                                               !a.Hidden);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_SupplementsList", supplement);
            }

            return View(supplement);
        }

        public ActionResult Details(int id)
        {
            var supplement = db.Supplements.Find(id);
            
            return View(supplement);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoriesMenu()
        {
            
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }

        public ActionResult SupplementsTip(string term)
        {
            var tips = db.Supplements.Where(a => !a.Hidden && a.Name.ToLower()
                                                     .Contains(term.ToLower()))
                .Take(5)
                .Select(a => new {label = a.Name});

            return Json(tips, JsonRequestBehavior.AllowGet);
        }

       
    }
}