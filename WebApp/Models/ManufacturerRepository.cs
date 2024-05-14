using DTO;

namespace WebApp.Models;
public class ManufacturerRepository : BaseRepository{
    public async Task<IEnumerable<Manufacturer>?> GetManufacturers(){
        
        return await FetchAll<Manufacturer>("Manufacturer");
    }    
    public async Task<int> Add (Manufacturer obj){
        return await FetchAdd("manufacturer",obj);
    }
    public async Task<int> Edit(Manufacturer obj){
       return await FetchEdit("manufacturer",obj);
    }
    public async Task<int> Delete(byte id){
        return await Delete<Manufacturer>("manufacturer",id);
    }
    public async Task<Manufacturer?> GetManufacturer(byte id){
        return await Fetch<Manufacturer>("manufacturer",id);
    }
}