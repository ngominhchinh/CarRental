namespace WebApp.Models;
public abstract class BaseRepository{
    protected Uri uri = new Uri("http://localhost:5235/api/");
    // protected async Task<IEnumerable<T>?> FetchAll<T>(string url){
    //     using HttpClient client = new HttpClient();
    //     client.BaseAddress = uri;
    //     return await client.GetFromJsonAsync<IEnumerable<T>>(url);
    // }
    protected async Task<IEnumerable<T>?> FetchAll<T>(string url, string? token=null){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        if(!string.IsNullOrEmpty(token)){
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        return await client.GetFromJsonAsync<IEnumerable<T>>(url);
    }
    public async  Task<int> Add<T>(string url, T obj){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.PostAsJsonAsync<T>(url,obj);
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadFromJsonAsync<int>();
        }
        return -1;
    }
    public async Task<int> FetchEdit<T>(string url,T obj){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.PutAsJsonAsync<T>(url,obj);
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadFromJsonAsync<int>();
        }
        return -1;
    }
    public async Task<int> Delete<T>(string url, byte id){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.DeleteAsync($"{url}/{id}");
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadFromJsonAsync<int>();
        }
        return -1;
    }
    public async Task<int> Delete<T>(string url, string id){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.DeleteAsync($"{url}/{id}");
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadFromJsonAsync<int>();
        }
        return -1;
    }
    public async Task<T?> Fetch<T>(string url, byte id){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        return await client.GetFromJsonAsync<T>($"{url}/{id}");
    }
    public async Task<T?> Fetch<T>(string url, string id){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        return await client.GetFromJsonAsync<T>($"{url}/{id}");
    }
}

