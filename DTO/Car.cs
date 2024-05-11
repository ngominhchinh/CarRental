namespace DTO;
public class Car{
    public string? CarId { get; set; } = null!;
    public string MemberId { get; set; } = null!;
    public byte ManufacturerId { get; set; }
    public byte CategoryId { get; set; }
    public string CarName { get; set; } = null!;
    public short ProducedYear { get; set; }
    public string Color { get; set; } = null!;
    public string NumberPlate { get; set; } = null!;
    public int PricePerDay { get; set; }
    public string Location { get; set; } = null!;
    public byte FuelId { get; set; }
    public byte GearboxId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool CarStatus { get; set; }
    public IEnumerable<CarImage>? CarImages {get; set;}
}