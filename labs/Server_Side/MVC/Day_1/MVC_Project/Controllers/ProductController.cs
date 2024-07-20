using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult All()
        {
            ProductBL productBL = new ProductBL();
            return View("AllProducts", productBL.GetAll());
        }

        public ViewResult Details(int id)
        {
            ProductBL productBL = new ProductBL();
            return View("ProductDetails", productBL.GetById(id));
        }
    }
}
