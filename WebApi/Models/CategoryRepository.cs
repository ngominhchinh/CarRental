using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class CategoryRepository : BaseRepository
{
    public CategoryRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<Category> GetCategories(){
        return connection.Query<Category>("SELECT * FROM Category");
    }
    public int Add(Category obj){
        string sql = "INSERT INTO Category(CategoryName) VALUES(@CategoryName)";
        return connection.Execute(sql, new {
            obj.CategoryName
        });
    }
    public int Edit(Category obj){
        string sql = "UPDATE Category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM Category WHERE CategoryId = @CategoryId";
        return connection.Execute(sql,new{
            CategoryId = id
        });
    }
    public Category? GetCategory(byte id){
        string sql = "SELECT * FROM Category WHERE CategoryId = @Id";
        return connection.QuerySingleOrDefault<Category>(sql, new{Id = id});
    }
}