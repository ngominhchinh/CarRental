using System.Security.Claims;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers;
public class CarController : BaseController{

    // [Authorize]
    // public async Task<IActionResult> Index(){        
    //     string? token = User.FindFirstValue(ClaimTypes.Authentication);
    //     string? memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //     IEnumerable<Car>? cars = await Provider.Car.GetCars(token);
    //     return View(cars);
    // }
    [Authorize]
    public async Task<IActionResult> Index(){
        string? token = User.FindFirstValue(ClaimTypes.Authentication);
        if(string.IsNullOrEmpty(token)){
            return Redirect("/car");
        }
        return View(await Provider.Car.GetCars(token));
    }
    [Authorize]
    public async Task<IActionResult> Add(){        
        string? memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        ViewBag.MemberIdLogin = memberId;
        ViewBag.Categories = new SelectList(await Provider.Category.GetCategories(),"CategoryId","CategoryName");
        ViewBag.Manufacturers = new SelectList(await Provider.Manufacturer.GetManufacturers(),"ManufacturerId","ManufacturerName");
        ViewBag.Gearboxes = new SelectList(await Provider.Gearbox.GetGearboxes(),"GearboxId","GearboxName");
        ViewBag.Fuels = new SelectList(await Provider.Fuel.GetFuels(),"FuelId","FuelName");
        return View();
    }    
    [HttpPost,Authorize]
    public async Task<IActionResult> Add(Car obj){
        string? memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(string.IsNullOrEmpty(memberId)){
            return Redirect("/auth/login");
        }
        obj.MemberId = memberId;
        int ret  = await Provider.Car.Add(obj);
        if(ret >0){
            return Redirect("/car");
        }
        return View(obj);
    }
    
    public async Task<IActionResult> Edit(string id){        
        
        return View(await Provider.Car.GetCar(id));
    }
    [HttpPost,Authorize]
    public async Task<IActionResult> Edit(Car obj){
        
        int ret = await Provider.Car.Edit(obj);
        if(ret > 0){
            return Redirect("/car");
        }
        return View(obj);
    }
    
    [Authorize]
    public async Task<IActionResult> Delete(string id){
        int ret = await Provider.Car.Delete(id);
        if(ret > 0){
            return Redirect("/car");
        }
        return Redirect("/car/error");
    }
}