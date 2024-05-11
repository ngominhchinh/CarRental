using System.Security.Claims;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CarController : BaseController{
    public IEnumerable<Car> GetCars() {
        return Provider.Car.GetCars();
    }
    [HttpGet("cars"),Authorize]    
    public IEnumerable<Car>? GetCarsByMember() {
        string? memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(!string.IsNullOrEmpty(memberId)){
            return Provider.Car.GetCars(memberId);
        }
        return null;
    }
    [HttpGet("{id}")]
    public IEnumerable<Car>? GetCars(string memberId){
        return Provider.Car.GetCars(memberId);
    }
    [HttpPost]
    public int Add(Car obj){
        return Provider.Car.Add(obj);
    }
    [HttpPut]
    public int Edit(Car obj){
        return Provider.Car.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(string id){
        return Provider.Car.Delete(id);
    }    
    // public string? GetManufacturerByCarId(string id){
    //     return Provider.Car.GetManufacturerByCarId(id);
    // }
}