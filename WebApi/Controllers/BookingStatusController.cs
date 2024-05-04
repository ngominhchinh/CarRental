using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class BookingStatusController : BaseController{
    public IEnumerable<BookingStatus> GetBookingStatuss() {
        return Provider.BookingStatus.GetBookingStatuses();
    }
    [HttpGet("{id}")]
    public BookingStatus? GetBookingStatus(byte id){
        return Provider.BookingStatus.GetBookingStatus(id);
    }
    [HttpPost]
    public int Add(BookingStatus obj){
        return Provider.BookingStatus.Add(obj);
    }
    [HttpPut]
    public int Edit(BookingStatus obj){
        return Provider.BookingStatus.Edit(obj);
    }
    [HttpDelete("{id}")]
    public int Delete(byte id){
        return Provider.BookingStatus.Delete(id);
    }
}