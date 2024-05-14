using DTO;

namespace WebApp.Models;
public class GearboxRepository : BaseRepository{
    public async Task<IEnumerable<Gearbox>?> GetGearboxes(){
        
        return await FetchAll<Gearbox>("gearbox");
    }    
    public async Task<int> Add (Gearbox obj){
        return await FetchAdd("gearbox",obj);
    }
    public async Task<int> Edit(Gearbox obj){
       return await FetchEdit("gearbox",obj);
    }
    public async Task<int> Delete(string id){
        return await Delete<Gearbox>("gearbox",id);
    }
    public async Task<Gearbox?> GetGearbox(string id){
        return await Fetch<Gearbox>("gearbox",id);
    }
}