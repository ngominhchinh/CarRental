using System.Security.Claims;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class HomeController : BaseController{
    
    public async Task<IActionResult> Index(){
        ViewBag.Categories = await Provider.Category.GetCategories();
        string? memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(!string.IsNullOrEmpty(memberId)){
            ViewBag.MemberId =memberId;
        }
        IEnumerable<Car>? list = await Provider.Car.GetCars();
        return View(list);
    }
}