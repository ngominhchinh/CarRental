using DTO;

namespace WebApp.Models;
public class CarRepository : BaseRepository{
    public async Task<IEnumerable<Car>?> GetCars(){
        
        return await FetchAll<Car>("car");
    }    
    public async Task<int> Add (Car obj){
        return await Add("car",obj);
    }
    public async Task<int> Edit(Car obj){
       return await Edit("car",obj);
    }
    public async Task<int> Delete(string id){
        return await Delete<Car>("car",id);
    }
    public async Task<Car?> GetCar(string id){
        return await Fetch<Car>("car",id);
    }
}