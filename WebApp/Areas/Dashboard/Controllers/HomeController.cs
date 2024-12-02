using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers;

[Authorize(Roles ="Admin")]
[Area("dashboard")]

public class HomeController:BaseController
{
    public IActionResult Index(){
        ViewBag.CategoryProducts = Provider.Category.GetCategoryAndProducts();
        IEnumerable<SalesByAge> list = Provider.Invoice.GetSalesByAges();
        ViewBag.MinMax = new{
            AgeMin = list.Min(p => p.Age),
            AgeMax = list.Max(p => p.Age),
            SalesMin = list.Min(p => p.Sales),
            SalesMax = list.Max(p => p.Sales)
        };
        ViewBag.GetSalesByAge = list;
        
        ViewBag.Employees = Provider.Employee.GetEmployeesAndParent();
        return View();
    }
}