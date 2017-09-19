using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(string id)
        {
            return View();
        }
    }
}