using DTO;

namespace WebApp.Models;
public class RoleRepository : BaseRepository{
    public async Task<IEnumerable<Role>?> GetRoles(){        
        return await FetchAll<Role>("role");
    }    
    public async Task<int> Add (Role obj){
        return await FetchAdd("Role",obj);
    }
    public async Task<int> Edit(Role obj){
       return await FetchEdit("role",obj);
    }
    public async Task<int> Delete(byte id){
        return await Delete<Role>("role",id);
    }
    public async Task<Role?> GetRole(byte id){
        return await Fetch<Role>("role",id);
    }
}