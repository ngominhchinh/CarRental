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
        return connection.Query<Car>("SELECT * FROM Car WHERE CarStatus = 0");
    }
    public IEnumerable<Car>? GetCarsByMemberId(string id){
        return connection.Query<Car>("SELECT * FROM Car WHERE MemberId = @Id", new{Id = id});
    }
    public int Add(Car obj){
        obj.CarId = Helper.RandomString(16);
        string sql = "INSERT INTO Car(CarId,MemberId,ManufacturerId,CategoryId,CarName,ProducedYear,Color,NumberPlate,PricePerDay,Location,FuelId,GearboxId) VALUES(@CarId,@MemberId,@ManufacturerId,@CategoryId,@CarName,@ProducedYear,@Color,@NumberPlate,@PricePerDay,@Location,@FuelId,@GearboxId)";
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
            obj.GearboxId
        });
    }
    public int Edit(Car obj){
        string sql = "UPDATE Car SET PricePerDay=@PricePerDay, Location=@Location WHERE CarId = @CarId";
        return connection.Execute(sql, obj);
    }
    public int Delete(string id){
        string sql = "DELETE FROM Car WHERE CarId = @CarId";
        return connection.Execute(sql,new{
            CarId = id
        });
    }
    public Car? GetCar(string id){
        string sql = "SELECT * FROM Car WHERE CarId = @Id";
        return connection.QuerySingleOrDefault<Car>(sql, new{Id = id});
    }
}