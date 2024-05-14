using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class CarRepository : BaseRepository
{
    public CarRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Car> GetCars(){
        
        return connection.Query<Car>("GetCars",commandType:CommandType.StoredProcedure);
    }
    public IEnumerable<Car> GetCars(string memberId){
        string sql = "SELECT Car.*, ManufacturerName FROM Car JOIN Manufacturer ON Car.ManufacturerId = Manufacturer.ManufacturerId WHERE MemberId = @Id";
        return connection.Query<Car>(sql, new{Id = memberId});
    }
    public Car? GetCar(string id){
        string sql = "SELECT Car.* FROM Car WHERE CarId = @Id";
        return connection.QueryFirstOrDefault<Car>(sql, new{Id = id});
    }
    public IEnumerable<Car>? GetCarsByMemberId(string id){
        return connection.Query<Car>("SELECT * FROM Car WHERE MemberId = @Id", new{Id = id});
    }
    public int Add(Car obj){
        obj.CarId = Helper.RandomString(16);
        string sql = "INSERT INTO Car(CarId,MemberId,ManufacturerId,CategoryId,CarName,ProducedYear,Color,NumberPlate,PricePerDay,Location,FuelId,GearboxId,ImageUrl) VALUES(@CarId,@MemberId,@ManufacturerId,@CategoryId,@CarName,@ProducedYear,@Color,@NumberPlate,@PricePerDay,@Location,@FuelId,@GearboxId,@ImageUrl)";
        return connection.Execute(sql, new {
            obj.CarId,
            obj.MemberId,
            obj.ManufacturerId,
            obj.CategoryId,
            obj.CarName,
            obj.ProducedYear,
            obj.Color,
            obj.NumberPlate,
            obj.PricePerDay,
            obj.Location,
            obj.FuelId,
            obj.GearboxId,
            obj.ImageUrl
        });
    }
    public int Edit(Car obj){
        string sql = "UPDATE Car SET MemberId=@MemberId, ManufacturerId=@ManufacturerId, CategoryId=@CategoryId, CarName = @CarName, ProducedYear=@ProducedYear,Color=@Color,NumberPlate=@NumberPlate, PricePerDay = @PricePerDay, Location=@Location, FuelId=@FuelId,GearboxId = @GearboxId,ImageUrl=@ImageUrl WHERE CarId = @CarId";
        //string sql = "UPDATE Car SET CarName = @CarName, "
        return connection.Execute(sql, obj);
    }
    public int Delete(string id){
        string sql = "DELETE FROM Car WHERE CarId = @CarId";
        return connection.Execute(sql,new{
            CarId = id
        });
    }
    public Car? Detail(string id){
        string sql = "SELECT * FROM Car WHERE CarId = @Id";
        return connection.QuerySingleOrDefault<Car>(sql, new{Id = id});
    }
    
}