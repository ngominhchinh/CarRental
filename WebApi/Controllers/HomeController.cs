
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("/api/[controller]")]
public class HomeController : BaseController{
    public string Welcome(){
        return "Welcome";
    }
}