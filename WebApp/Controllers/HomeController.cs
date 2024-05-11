using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class HomeController : BaseController{
    
    public async Task<IActionResult> Index(){
        ViewBag.Categories = await Provider.Category.GetCategories();
        
        IEnumerable<Car>? list = await Provider.Car.GetCars();
        return View(list);
    }
}