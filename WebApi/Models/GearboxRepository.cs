using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class GearboxRepository : BaseRepository
{
    public GearboxRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Gearbox> GetGearboxes(){
        return connection.Query<Gearbox>("SELECT * FROM Gearbox");
    }
    public int Add(Gearbox obj){
        string sql = "INSERT INTO Gearbox(GearboxName) VALUES(@GearboxName)";
        return connection.Execute(sql, new {
            obj.GearboxName
        });
    }
    public int Edit(Gearbox obj){
        string sql = "UPDATE Gearbox SET GearboxName = @GearboxName WHERE GearboxId = @GearboxId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM Gearbox WHERE GearboxId = @GearboxId";
        return connection.Execute(sql,new{
            GearboxId = id
        });
    }
    public Gearbox? GetGearbox(byte id){
        string sql = "SELECT * FROM Gearbox WHERE GearboxId = @Id";
        return connection.QuerySingleOrDefault<Gearbox>(sql, new{Id = id});
    }
}