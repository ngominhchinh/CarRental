using DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CategoryController : BaseController{
    public IEnumerable<Category> GetCategories() {
        return Provider.Category.GetCategories();
    }
    [HttpGet("{id}")]
    public Category? GetCategory(byte id){
        return Provider.Category.GetCategory(id);
    }
    [HttpPost]
    public int Add(Category obj){
        return Provider.Category.Add(obj);
    }
    [HttpPut]
    public int Edit(Category obj){
        return Provider.Category.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.Category.Delete(id);
    }
}