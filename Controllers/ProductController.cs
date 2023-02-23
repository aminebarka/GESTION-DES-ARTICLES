using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Repositories;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        //injection de dépendance
        readonly IRepository<Product> ProductRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProductController(IRepository<Product> ProdRepository, IWebHostEnvironment hostingEnvironment)
        {
            ProductRepository = ProdRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
… // POST: ProductController/Create
[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.ImagePath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Product newProduct = new Product
                {
                    Désignation = model.Désignation,
                    Prix = model.Prix,
                    Quantite = model.Quantite,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Image = uniqueFileName
                };
                ProductRepository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.Id });
            }
            return View();
        }

    }
