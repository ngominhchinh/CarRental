using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CarController : BaseController{
    public IEnumerable<Car> GetCars() {
        return Provider.Car.GetCars();
    }
    [HttpGet("{id}")]
    public Car? GetCar(string id){
        return Provider.Car.GetCar(id);
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
}