using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class FuelController : BaseController{
    public IEnumerable<Fuel> GetFuels() {
        return Provider.Fuel.GetFuels();
    }
    [HttpGet("{id}")]
    public Fuel? GetFuel(byte id){
        return Provider.Fuel.GetFuel(id);
    }
    [HttpPost]
    public int Add(Fuel obj){
        return Provider.Fuel.Add(obj);
    }
    [HttpPut]
    public int Edit(Fuel obj){
        return Provider.Fuel.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.Fuel.Delete(id);
    }
}