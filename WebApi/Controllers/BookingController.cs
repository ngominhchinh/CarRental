using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class BookingController : BaseController{
    [HttpPost]
    public int Add(Booking obj){
        return Provider.Booking.Add(obj);
    }
}