using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController:BaseController
{
    public IActionResult Register(){
        return View();
    }
  
    [HttpPost]
    public IActionResult Register(Member obj)
    {
        obj.MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty);
        obj.Name = obj.GivenName + "" + obj.Surname;
        int ret = Provider.Member.Add(obj);
        if(ret > 0)
            return Redirect("/auth/login");
        return View(obj);
    }

     public IActionResult Login(){
        return View();
    }

      public IActionResult Denied(){
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj){
        Member? member = Provider.Member.Login(obj);
        if(member !=null){
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, member.MemberId),
                new Claim(ClaimTypes.Name, member.Name),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.GivenName, member.GivenName),
                new Claim(ClaimTypes.Surname, member.Surname),

                new Claim(ClaimTypes.Role, member.Role),
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties{
                    IsPersistent = obj.Rem
                });
            return Redirect("/auth");

        }
        ModelState.AddModelError("Error", "Login Failed");
        return View(obj);
    }

  IEmailSender sender;

    public AuthController(IEmailSender sender){
        this.sender = sender;
    }

   [Authorize]
    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/auth/login");
    }

    public IActionResult Forgot(){
        return View();
    }
    [HttpPost]

    public async Task<IActionResult> Forgot(string email){
        // string token = Guid.NewGuid().ToString().Replace("-", string.Empty);
        string? token = Provider.Member.GenerateToken(email);
        if(string.IsNullOrEmpty(token)){
            return View();
        }
           string? url = Url.Action("confirm", "auth", new {token}, protocol: Request.Scheme);
        if(string.IsNullOrEmpty(url)){
            return View();
        }
        string content = $"Please click <a href=\"{url}\">Link</a> a to Change Password";
        await sender.SendEmailAsync(email, "Forgot Password", content);
        TempData["Msg"] = $"Please Check your email: {email}";
        return Redirect("/auth/success");
    }
    public IActionResult Confirm(string token){
        return View();
    }
    [HttpPost]
     public IActionResult Confirm(string token, string password){
       int ret = Provider.Member.ChangePassword(password, token);
       if(ret > 0){
        TempData["Msg"] = "change password Success";
        return Redirect("/auth/logout");
       }
       ModelState.AddModelError("Error", "Change password failed");
        return View();
    }

    public IActionResult Success(){
        return View();
    }

    [Authorize]
    public IActionResult Index(){
        return View();
    }
   


    public IActionResult GoogleLogin(){
        string? uri = Url.Action("googleresponse","auth",null,protocol: Request.Scheme);
        if(string.IsNullOrEmpty(uri)){
            return Redirect("/auth/error");
        }
        AuthenticationProperties properties = new AuthenticationProperties{
            RedirectUri = uri
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
    public async Task<IActionResult> GoogleResponse(){
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    if(result != null && result.Principal != null){
        var claims = result.Principal.Claims;
        var member = new Member{
            MemberId = claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)!.Value,
            Name = claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)!.Value,
            Surname = claims.FirstOrDefault(p => p.Type == ClaimTypes.Surname)!.Value,
            GivenName = claims.FirstOrDefault(p => p.Type == ClaimTypes.GivenName)!.Value,
            Email = claims.FirstOrDefault(p => p.Type == ClaimTypes.Email)!.Value,
            Password = "dasdsassfaf"
        };
        Provider.Member.Add(member);
    }
    return Redirect("/auth");
    
}


}