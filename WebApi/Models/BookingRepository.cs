using System.Data;
using Dapper;
using DTO;

namespace WebApi.Models;
public class BookingRepository : BaseRepository
{
    public BookingRepository(IDbConnection connection) : base(connection)
    {
    }
    public int Add(Booking obj){
        obj.BookingId = Helper.RandomString(32);
        string sql = "INSERT INTO Booking(BookingId, CarId, MemberId, BookingDate,StartDate,EndDate,Deposit,BookingStatusId) VALUES(@BookingId, @CarId, @MemberId, @BookingDate, @StartDate, @EndDate, @Deposit,@BookingStatusId)";
        return connection.Execute(sql, new {
            obj.BookingId,
            obj.CarId,
            obj.MemberId,
            obj.BookingDate,
            obj.StartDate,
            obj.EndDate,
            obj.Deposit,
            obj.BookingStatusId
        });
    }
}