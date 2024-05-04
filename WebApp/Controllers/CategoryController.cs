using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class CategoryController : BaseController{
    public async Task<IActionResult> Index(){
        return View(await Provider.Category.GetCategories());
    }
    public IActionResult Add(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Category obj){
        int ret  = await Provider.Category.Add(obj);
        if(ret >0){
            return Redirect("/category");
        }
        return View(obj);
    }
    public async Task<IActionResult> Edit(byte id){
        return View(await Provider.Category.GetCategory(id));
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Category obj){
        int ret = await Provider.Category.Edit(obj);
        if(ret > 0){
            return Redirect("/category");
        }
        return View(obj);
    }
    
}