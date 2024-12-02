using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class CartController:BaseController
{
    const string cart = "cart";

    VnPaymentServices vnPayment;

    public CartController(VnPaymentServices vnPayment){
        this.vnPayment = vnPayment;
    }
    public IActionResult VnpaymentResponse(VnPaymentReponse obj){
    // return Json(obj);
    int ret = Provider.VnPayment.Add(obj);
    if(ret > 0){
        TempData["Msg"] = "Thanh toán thành công!";
        return Redirect("/cart/success");
    }
   return Redirect("/cart/error");

}
public IActionResult Success(){
    return View();
}

    public IActionResult Checkout(){
        string? code = Request.Cookies[cart];
        if(string.IsNullOrEmpty(code)){
            return Redirect("/");
        }
        return View(Provider.Cart.GetCarts(code));
    }
    public IActionResult Index(){
        string? code = Request.Cookies[cart];
        if(string.IsNullOrEmpty(code)){
            return Redirect("/");
        }
       return View(Provider.Cart.GetCarts(code));
    }
    [HttpPost]
       public IActionResult Checkout(Invoice obj){
        string? code = Request.Cookies[cart];
        if(string.IsNullOrEmpty(code)){
            return Redirect("/");
        }
        Random random = new Random();
        obj.InvoiceId = random.NextInt64(9999999, 99999999999);
        obj.CartCode = code;
        obj.InvoiceDate = DateTime.Now;
        int ret = Provider.Invoice.Add(obj);
        if( ret > 0){
            obj.Amount = Provider.Invoice.GetAmountInvoice(obj.InvoiceId)* 1000;//Do dang dung VND
            string url = vnPayment.ToUrl(obj);
            return Redirect(url);
            // return Redirect("/cart/success");
        }
        return Redirect("/cart/error");
    }

    public IActionResult Edit(Cart obj){
        string? code = Request.Cookies[cart];
        if(string.IsNullOrEmpty(code)){
            return Redirect("/");
        }
        obj.CartCode = code;
        return Json(Provider.Cart.Edit(obj));
    }

    public IActionResult Add(Cart obj){
        //cookie
        string? code = Request.Cookies[cart];
        if(string.IsNullOrEmpty(code)){
            code = Guid.NewGuid().ToString().Replace("-","");
            Response.Cookies.Append(cart, code);
        }
        obj.CartCode = code;
        int ret = Provider.Cart.Add(obj);
        if(ret > 0){
            return Redirect("/cart");

        }
        return Redirect("/cart/error");
    }

    public IActionResult Delete(int id){
        int ret = Provider.Cart.Delete(id);
        if(ret > 0){
            return Redirect("/cart");
        }
        return Redirect("/cart/error");
    }
}