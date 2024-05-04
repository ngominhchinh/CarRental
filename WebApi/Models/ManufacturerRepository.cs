using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class ManufacturerRepository : BaseRepository
{
    public ManufacturerRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Manufacturer> GetManufacturers(){
        return connection.Query<Manufacturer>("SELECT * FROM Manufacturer");
    }
    public int Add(Manufacturer obj){
        string sql = "INSERT INTO Manufacturer(ManufacturerName) VALUES(@ManufacturerName)";
        return connection.Execute(sql, new {
            obj.ManufacturerName
        });
    }
    public int Edit(Manufacturer obj){
        string sql = "UPDATE Manufacturer SET ManufacturerName = @ManufacturerName WHERE ManufacturerId = @ManufacturerId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM Manufacturer WHERE ManufacturerId = @ManufacturerId";
        return connection.Execute(sql,new{
            ManufacturerId = id
        });
    }
    public Manufacturer? GetManufacturer(byte id){
        string sql = "SELECT * FROM Manufacturer WHERE ManufacturerId = @Id";
        return connection.QuerySingleOrDefault<Manufacturer>(sql, new{Id = id});
    }
}