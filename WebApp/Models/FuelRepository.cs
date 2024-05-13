using DTO;

namespace WebApp.Models;
public class FuelRepository : BaseRepository{
    public async Task<IEnumerable<Fuel>?> GetFuels(){
        
        return await FetchAll<Fuel>("fuel");
    }    
    public async Task<int> Add (Fuel obj){
        return await Add("fuel",obj);
    }
    public async Task<int> Edit(Fuel obj){
       return await FetchEdit("fuel",obj);
    }
    public async Task<int> Delete(string id){
        return await Delete<Fuel>("fuel",id);
    }
    public async Task<Fuel?> GetFuel(string id){
        return await Fetch<Fuel>("fuel",id);
    }
}