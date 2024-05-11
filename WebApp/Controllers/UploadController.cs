using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;
public class UploadController : BaseController{
    public IActionResult Index() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(IFormFile f){
        return Json(await Provider.Upload.Upload(f));
    }
}