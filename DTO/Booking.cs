namespace DTO;
public class Booking{
    public string BookingId { get; set; } =null!;
    public string CarId { get; set; } = null!;
    public string MemberId { get; set; } = null!;
    public DateTime BookingDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Deposit { get; set; }
    public byte BookingStatusId { get; set; }
}