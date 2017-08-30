using System.Linq;
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
            var supplementslist = db.Categories.ToList();
            return View();
        }
    }
}