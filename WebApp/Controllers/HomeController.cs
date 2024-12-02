
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers;

public class HomeController :BaseController
{

   public IActionResult Index(string? searchString)
{
    ViewBag.Categories = Provider.Category.GetCategories();

    if (!string.IsNullOrEmpty(searchString))
    {
        var products = Provider.Product.SearchProducts(searchString);
        return View(products);
    }

    return View(Provider.Product.GetProducts());

    
}
    
 
  
    public IActionResult Category(short id)
        {
            ViewBag.Categories = Provider.Category.GetCategories();
            ViewBag.Category = Provider.Category.GetCategory(id);
            return View(Provider.Product.GetProductsByCategory(id));
        }
       public IActionResult Details(int id){
        ViewBag.Categories = Provider.Category.GetCategories();
        Product? obj = Provider.Product.GetProduct(id);
        if(obj is null){
            return Redirect("/");
        }
        ViewBag.Product = obj;
        return View(Provider.Product.GetProductsRelation(obj.CategoryId, id));
        }


}
