using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class UploadController : ControllerBase{
    [HttpPost]
    public string Upload(IFormFile f){
        string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");      
        string ext = Path.GetExtension(f.FileName);

        string fileName = Helper.RandomString(32 - ext.Length) + ext;
        string path = Path.Combine(root,fileName);

        using Stream stream = new FileStream(path,FileMode.Create);
        f.CopyTo(stream);
        return fileName;
    }
}