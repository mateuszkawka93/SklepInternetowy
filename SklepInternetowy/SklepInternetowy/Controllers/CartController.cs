using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Infrastructure;
using SklepInternetowy.ViewModels;
using System.Web.Mvc;


namespace SklepInternetowy.Controllers
{
    public class CartController : Controller
    {
        private CartManager _cartManager;
        private ISessionManager _sessionManager { get; set; }
        private readonly SupplementsContext _db;

        public CartController()
        {
            _db = new SupplementsContext();
            _sessionManager = new SessionManager();
            _cartManager = new CartManager(_sessionManager, _db);
        }

        public ActionResult Index()
        {

            var cartPosition = _cartManager.GetCart();
            var totalPrice = _cartManager.GetCartValue();
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartPositions = cartPosition,
                TotalPrice = totalPrice
            };
            return View(cartViewModel);
        }

        public ActionResult AddToCart(int id)
        {

            _cartManager.AddToCart(id);


            return RedirectToAction("Index");
        }
    }
}