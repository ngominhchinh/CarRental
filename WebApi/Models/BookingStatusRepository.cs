using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class BookingStatusRepository : BaseRepository
{
    public BookingStatusRepository(IDbConnection connection) : base(connection)
    {
    }
    public IEnumerable<BookingStatus> GetBookingStatuses(){
        return connection.Query<BookingStatus>("SELECT * FROM BookingStatus");
    }
    public int Add(BookingStatus obj){
        string sql = "INSERT INTO BookingStatus(BookingStatusDescription) VALUES(@BookingStatusDescription)";
        return connection.Execute(sql, new {
            obj.BookingStatusDescription
        });
    }
    public int Edit(BookingStatus obj){
        string sql = "UPDATE BookingStatus SET BookingStatusDescription = @BookingStatusDescription WHERE BookingStatusId = @BookingStatusId";
        return connection.Execute(sql, obj);
    }
    public int Delete(byte id){
        string sql = "DELETE FROM BookingStatus WHERE BookingStatusId = @BookingStatusId";
        return connection.Execute(sql,new{
            BookingStatusId = id
        });
    }
    public BookingStatus? GetBookingStatus(byte id){
        string sql = "SELECT * FROM BookingStatus WHERE BookingStatusId = @Id";
        return connection.QuerySingleOrDefault<BookingStatus>(sql, new{Id = id});
    }
}