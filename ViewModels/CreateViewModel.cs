using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Repositories;
using WebApplication2.Models.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> ProductRepository;
        //injection de dépendance
        public ProductController(IRepository<Product> prodRepository)
        {
            ProductRepository = prodRepository;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var product = ProductRepository.GetAll();
            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = ProductRepository.Get(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                ProductRepository.Add(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = ProductRepository.Get(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product newproduct)
        {
            try
            {
                ProductRepository.Update(newproduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = ProductRepository.Get(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                ProductRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
