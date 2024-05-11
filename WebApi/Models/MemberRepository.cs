using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class MemberRepository : BaseRepository
{
    public MemberRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Member> GetMembers(){
        return connection.Query<Member>("SELECT * FROM Member");
    }
    public Member? GetMember(string id){
        string sql = "SELECT * FROM Member WHERE MemberId = @Id";
        return connection.QuerySingleOrDefault<Member>(sql, new{Id = id});
    }
    public int Add(Member obj){
        obj.MemberId = Helper.RandomString(32);
        obj.Password = Helper.Hash(obj.Password);
        string sql = "INSERT INTO Member(MemberId,Email,Phone,Password,FullName,Gender,RoleId) VALUES (@MemberId,@Email, @Phone, @Password,@FullName,@Gender,@RoleId)";
        return connection.Execute(sql, obj);
    }
    public int Edit(Member obj){
        string sql = "UPDATE Member SET  Email=@Email, Phone=@Phone, Password=@Password, FullName = @FullName, Gender = @Gender WHERE MemberId=@MemberId";
        return connection.Execute(sql, obj);
    }

    public Member? Login(LoginModel obj){
        obj.Password = Helper.Hash(obj.Password);
        string sql = "SELECT MemberId,Email,Phone,FullName,Gender,RoleId FROM Member WHERE Email = @Email AND Password =@Password";
        return connection.QuerySingleOrDefault<Member>(sql, obj);
    }

}