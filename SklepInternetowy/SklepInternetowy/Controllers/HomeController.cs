using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class HomeController : Controller
    {
        private SupplementsContext db = new SupplementsContext();


        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            var newsupplements = db.Supplements.Where(a => !a.Hidden).OrderByDescending(a => a.AddTime).Take(3).ToList();
            var bestsellersupplements =
                db.Supplements.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();

            var viewmodel = new HomeViewModel()
            {
                Categories = categories,
                NewSupplements = newsupplements,
                BestsellerSupplements = bestsellersupplements
            };

            return View(viewmodel);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}