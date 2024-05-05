using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers;
public class CarController : BaseController{
    [Authorize]
    public async Task<IActionResult> Index(){
        return View(await Provider.Car.GetCars());
    }
    [Authorize]
    public async Task<IActionResult> Add(){
        
        
        ViewBag.Categories = new SelectList(await Provider.Category.GetCategories(),"CategoryId","CategoryName");
        ViewBag.Manufacturers = new SelectList(await Provider.Manufacturer.GetManufacturers(),"ManufacturerId","ManufacturerName");
        ViewBag.Gearboxes = new SelectList(await Provider.Gearbox.GetGearboxes(),"GearboxId","GearboxName");
        ViewBag.Fuels = new SelectList(await Provider.Fuel.GetFuels(),"FuelId","FuelName");
        return View();
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(Car obj){
        int ret  = await Provider.Car.Add(obj);
        if(ret >0){
            return Redirect("/car");
        }
        return View(obj);
    }
    [Authorize]
    public async Task<IActionResult> Edit(string id){
        return View(await Provider.Car.GetCar(id));
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Edit(Car obj){
        int ret = await Provider.Car.Edit(obj);
        if(ret > 0){
            return Redirect("/car");
        }
        return View(obj);
    }
}