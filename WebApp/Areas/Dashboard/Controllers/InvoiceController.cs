using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;


namespace WebApp.Areas.Dashboard.Controllers;
[Area("Dashboard")]

public class InvoiceController:BaseController
{
    public IActionResult Index(){
    
        return View(Provider.Invoice.GetInvoices());
    }

     public IActionResult Delete(long id){
        int ret = Provider.Invoice.Delete(id);
        if(ret > 0){
            return Redirect("/dashboard/invoice");
        }
        return Redirect("/invoice/error");
    }

     public IActionResult Edit(long id){
        return View(Provider.Invoice.GetInvoice(id));
    }
 [HttpPost]
   public IActionResult Edit(long id, Invoice obj){
        obj.InvoiceId = id;
        int ret = Provider.Invoice.Edit(obj);
        if(ret > 0){
            return Redirect("/dashboard/invoice");
        }
        ModelState.AddModelError("Error","Update failed");
        return View(obj);
    }
}