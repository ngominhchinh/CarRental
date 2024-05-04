using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class RoleController : BaseController{
    public async Task<IActionResult> Index(){
        return View(await Provider.Role.GetRoles());
    }
    public IActionResult Add(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Role obj){
        int ret  = await Provider.Role.Add(obj);
        if(ret >0){
            return Redirect("/role");
        }
        return View(obj);
    }
    public async Task<IActionResult> Edit(byte id){
        return View(await Provider.Role.GetRole(id));
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Role obj){
        int ret = await Provider.Role.Edit(obj);
        if(ret > 0){
            return Redirect("/role");
        }
        return View(obj);
    }
}