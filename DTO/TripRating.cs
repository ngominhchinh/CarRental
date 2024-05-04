namespace DTO;
public class TripRating{
    public int TripId { get; set; }
    public byte Rating { get; set; }
    public string Comment { get; set; } = null!;
    public string MemberId { get; set; } = null!;
}