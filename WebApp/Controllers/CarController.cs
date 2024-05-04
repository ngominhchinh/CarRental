using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers;
public class CarController : BaseController{
    public async Task<IActionResult> Index(){
        return View(await Provider.Car.GetCars());
    }
    public async Task<IActionResult> Add(){
        ViewBag.Categories = new SelectList(await Provider.Category.GetCategories(),"CategoryId","CategoryName");
        ViewBag.Manufacturers = new SelectList(await Provider.Manufacturer.GetManufacturers(),"ManufacturerId","ManufacturerName");
        ViewBag.Gearboxes = new SelectList(await Provider.Gearbox.GetGearboxes(),"GearboxId","GearboxName");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(Car obj){
        int ret  = await Provider.Car.Add(obj);
        if(ret >0){
            return Redirect("/car");
        }
        return View(obj);
    }
    public async Task<IActionResult> Edit(string id){
        return View(await Provider.Car.GetCar(id));
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Car obj){
        int ret = await Provider.Car.Edit(obj);
        if(ret > 0){
            return Redirect("/car");
        }
        return View(obj);
    }
}