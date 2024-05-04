using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class GearboxController : BaseController{
    public IEnumerable<Gearbox> GetGearboxes() {
        return Provider.Gearbox.GetGearboxes();
    }
    [HttpGet("{id}")]
    public Gearbox? GetGearbox(byte id){
        return Provider.Gearbox.GetGearbox(id);
    }
    [HttpPost]
    public int Add(Gearbox obj){
        return Provider.Gearbox.Add(obj);
    }
    [HttpPut]
    public int Edit(Gearbox obj){
        return Provider.Gearbox.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.Gearbox.Delete(id);
    }
}