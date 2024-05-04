using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class FuelRepository : BaseRepository
{
    public FuelRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Fuel> GetFuels(){
        return connection.Query<Fuel>("SELECT * FROM Fuel");
    }
    public int Add(Fuel obj){
        string sql = "INSERT INTO Fuel(FuelName) VALUES(@FuelName)";
        return connection.Execute(sql, new {
            obj.FuelName
        });
    }
    public int Edit(Fuel obj){
        string sql = "UPDATE Fuel SET FuelName = @FuelName WHERE FuelId = @FuelId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM Fuel WHERE FuelId = @FuelId";
        return connection.Execute(sql,new{
            FuelId = id
        });
    }
    public Fuel? GetFuel(byte id){
        string sql = "SELECT * FROM Fuel WHERE FuelId = @Id";
        return connection.QuerySingleOrDefault<Fuel>(sql, new{Id = id});
    }
}