using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ControllerProduct : Controller
    {
        readonly IRepository<Product> ProductRepository;
        //private readonly IWebHostEnvironment hostingEnvironment;
        public ControllerProduct(IRepository<Product> ProdRepository)//, IWebHostEnvironment hostingEnvironment)
        {
            ProductRepository = ProdRepository;
           // this.hostingEnvironment = hostingEnvironment;
        }
        // GET: ControllerProduct
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }

        // GET: ControllerProduct/Details/5
        public ActionResult Details(int id)
        {
            var p = ProductRepository.Get(id);
            return View(p);
        }

        // GET: ControllerProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControllerProduct/Create
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

        // GET: ControllerProduct/Edit/5
        public ActionResult Edit(int id)
        {
            var p = ProductRepository.Get(id);
            return View(p);
        }

        // POST: ControllerProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                ProductRepository.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ControllerProduct/Delete/5
        public ActionResult Delete(int id)
        {
            var p = ProductRepository.Get(id);
            return View(p);
        }

        // POST: ControllerProduct/Delete/5
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
