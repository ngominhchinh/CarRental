namespace WebApp.Models;
public class SiteProvider{
    CategoryRepository category =null!;
    public CategoryRepository Category => category ??= new CategoryRepository();
    MemberRepository member =null!;
    public MemberRepository Member => member ??= new MemberRepository();
    RoleRepository role =null!;
    public RoleRepository Role => role ??= new RoleRepository();
    CarRepository car =null!;
    public CarRepository Car => car ??= new CarRepository();
    FuelRepository fuel =null!;
    public FuelRepository Fuel => fuel ??= new FuelRepository();
    ManufacturerRepository manufacturer =null!;
    public ManufacturerRepository Manufacturer => manufacturer ??= new ManufacturerRepository();
    GearboxRepository gearbox =null!;
    public GearboxRepository Gearbox => gearbox ??= new GearboxRepository();
    UploadRepository upload =null!;
    public UploadRepository Upload => upload ??= new UploadRepository();
}