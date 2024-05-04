using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class RoleRepository : BaseRepository
{
    public RoleRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Role> GetRoles(){
        return connection.Query<Role>("SELECT * FROM Role");
    }
    public int Add(Role obj){
        string sql = "INSERT INTO Role(RoleName) VALUES(@RoleName)";
        return connection.Execute(sql, new {
            obj.RoleName
        });
    }
    public int Edit(Role obj){
        string sql = "UPDATE Role SET RoleName = @RoleName WHERE RoleId = @RoleId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM Role WHERE RoleId = @RoleId";
        return connection.Execute(sql,new{
            RoleId = id
        });
    }
    public Role? GetRole(byte id){
        string sql = "SELECT * FROM Role WHERE RoleId = @Id";
        return connection.QuerySingleOrDefault<Role>(sql, new{Id = id});
    }
}