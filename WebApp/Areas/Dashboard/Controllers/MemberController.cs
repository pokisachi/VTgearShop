using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controllers;
[Area("dashboard")]

public class MemberController:BaseController
{
    public IActionResult Index(){
        return View(Provider.Member.GetMembers());
    }

    public IActionResult UpdateRole(string id){
        List<string> list = new List<string>{
            Role.Admin.ToString(),
            Role.Customer.ToString()
        };
        Member? member = Provider.Member.GetMember(id);
            if(member !=null){
                ViewBag.Roles = new SelectList(list, member.Role);
            }
            return View(member);
        }
    [HttpPost]
    public IActionResult UpdateRole(string id, string role){
        int ret = Provider.Member.UpdateRole(id, role);
        if(ret > 0){
            TempData["Msg"] = "Update Role success";
            return Redirect("/dashboard/member");
        }
        return View();
    }
        public IActionResult Delete(string id){
        int ret = Provider.Member.Delete(id);
        if(ret > 0){
            return Redirect("/dashboard/member");
        }
        return Redirect("/dashboard/member/error");
    }
    
}