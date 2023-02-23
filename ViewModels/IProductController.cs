using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public interface IProductController
    {
        ActionResult Create();
        ActionResult Create(CreateViewModel model);
        ActionResult Create(Product p);
        ActionResult Delete(int id);
        ActionResult Delete(int id, Product p);
        ActionResult Details(int id);
        ActionResult Edit(int id);
        ActionResult Edit(int id, Product newproduct);
        ActionResult Index();
    }
}