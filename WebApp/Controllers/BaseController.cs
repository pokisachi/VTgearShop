
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BaseController:Controller{
    SiteProvider? provider;
    protected SiteProvider Provider => 
        provider ??= new(HttpContext.RequestServices.GetRequiredService<IConfiguration>());

}