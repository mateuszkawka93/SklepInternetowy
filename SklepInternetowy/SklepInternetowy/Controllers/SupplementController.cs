using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class SupplementController : Controller
    {
        // GET: Supplement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryname)
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            
            return View();
        }
    }
}