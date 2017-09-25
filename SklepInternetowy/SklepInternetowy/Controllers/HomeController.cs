using SklepInternetowy.Data_Access_Layer;
using SklepInternetowy.Infrastructure;
using SklepInternetowy.Models;
using SklepInternetowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SklepInternetowy.Controllers
{
    public class HomeController : Controller
    {
        private SupplementsContext db = new SupplementsContext();


        public ActionResult Index()
        {
            

            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;

            if (cache.IsSet(Consts.CategoriesCache))
            {
                categories = cache.Get(Consts.CategoriesCache) as List<Category>;
            }
            else
            {
                categories = db.Categories.ToList();
                cache.Set(Consts.CategoriesCache, categories, 60);
            }

            List<Supplement> newsupplements;

            if (cache.IsSet(Consts.NewSupplementCache))
            {
                newsupplements = cache.Get(Consts.NewSupplementCache) as List<Supplement>;
            }
            else
            {
                newsupplements = db.Supplements.Where(a => !a.Hidden).OrderByDescending(a => a.AddTime).Take(3).ToList();
                cache.Set(Consts.NewSupplementCache, newsupplements, 1);
            }

            List<Supplement> bestsellersupplements;

            if (cache.IsSet(Consts.BestsellerCache))
            {
                bestsellersupplements = cache.Get(Consts.BestsellerCache) as List<Supplement>;
            }
            else
            {
                bestsellersupplements =
                db.Supplements.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList(); //Guid - nadaje nowy identyfikator za kazdym razem gdy uruchamiamy aplikacje
                cache.Set(Consts.BestsellerCache, bestsellersupplements, 1);
            }

            

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