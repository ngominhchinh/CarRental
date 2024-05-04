using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class RoleController : BaseController{
    public IEnumerable<Role> GetRoles() {
        return Provider.Role.GetRoles();
    }
    [HttpGet("{id}")]
    public Role? GetRole(byte id){
        return Provider.Role.GetRole(id);
    }
    [HttpPost]
    public int Add(Role obj){
        return Provider.Role.Add(obj);
    }
    [HttpPut]
    public int Edit(Role obj){
        return Provider.Role.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.Role.Delete(id);
    }
}