using DTO;

namespace WebApp.Models;
public class CategoryRepository : BaseRepository
{
    public async Task<IEnumerable<Category>?> GetCategories()
    {

        return await FetchAll<Category>("category");
    }
    public async Task<int> Add(Category obj)
    {
        return await Add("category", obj);
    }
    public async Task<int> Edit(Category obj)
    {        
        return await FetchEdit("category", obj);
    }
    public async Task<int> Delete(byte id)
    {
        return await Delete<Category>("category", id);
    }
    public async Task<Category?> GetCategory(byte id)
    {
        return await Fetch<Category>("category", id);
    }

}