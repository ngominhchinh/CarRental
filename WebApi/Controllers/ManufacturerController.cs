using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class ManufacturerController : BaseController{
    public IEnumerable<Manufacturer> GetManufacturers() {
        return Provider.Manufacturer.GetManufacturers();
    }
    [HttpGet("{id}")]
    public Manufacturer? GetManufacturer(byte id){
        return Provider.Manufacturer.GetManufacturer(id);
    }
    [HttpPost]
    public int Add(Manufacturer obj){
        return Provider.Manufacturer.Add(obj);
    }
    [HttpPut]
    public int Edit(Manufacturer obj){
        return Provider.Manufacturer.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.Manufacturer.Delete(id);
    }
}