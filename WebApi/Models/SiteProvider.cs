using System.Data;
using System.Data.SqlClient;

namespace WebApi.Models;
public class SiteProvider
{
    IDbConnection connection = null!;
    string connectionString;
    protected IDbConnection Connection => connection ??= new SqlConnection(connectionString);
    public SiteProvider(IConfiguration configuration) => connectionString = configuration.GetConnectionString("CarRental") ?? throw new Exception("CarRental not found");

    CategoryRepository category = null!;
    public CategoryRepository Category => category ??= new CategoryRepository(Connection);
    ManufacturerRepository manufacturer = null!;
    public ManufacturerRepository Manufacturer => manufacturer ??= new ManufacturerRepository(Connection);
    BookingStatusRepository bookingStatus = null!;
    public BookingStatusRepository BookingStatus => bookingStatus ??= new BookingStatusRepository(Connection);
    RoleRepository role = null!;
    public RoleRepository Role => role ??= new RoleRepository(Connection);
    FuelRepository fuel = null!;
    public FuelRepository Fuel => fuel ??= new FuelRepository(Connection);
    GearboxRepository gearbox = null!;
    public GearboxRepository Gearbox => gearbox ??= new GearboxRepository(Connection);
    MemberRepository member = null!;
    public MemberRepository Member => member ??= new MemberRepository(Connection);
    CarRepository car = null!;
    public CarRepository Car => car ??= new CarRepository(Connection);
}