using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SuplierController:BaseController
{
      
      public IActionResult Index()
    {
            ViewBag.Suppliers = Provider.Supplier.GetSuppliers(); // Lấy danh sách danh mục
            return View(Provider.Supplier.GetSuppliers()); // Trả về danh sách sản phẩm
    }

      public IActionResult SupplierDetails(string id)
    {
        ViewBag.Suppliers = Provider.Supplier.GetSuppliers();
        ViewBag.Supplier = Provider.Supplier.GetSupplier(id);
        return View();
    }
}