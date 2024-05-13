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
        // using HttpClient client = new HttpClient();
        // client.BaseAddress = uri;
        // HttpResponseMessage message = await client.PutAsJsonAsync<Category>("category", obj);
        // if (message.IsSuccessStatusCode)
        // {
        //     return await message.Content.ReadFromJsonAsync<int>();
        // }
        // return -1;
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