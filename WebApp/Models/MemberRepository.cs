using DTO;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WebApp.Models;
public class MemberRepository : BaseRepository{
    public async Task<int> Add (Member obj){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.PostAsJsonAsync<Member>("member",obj);
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadFromJsonAsync<int>();
        }
        return -1;
    }
    public async Task<string?> Login(LoginModel obj){
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.PostAsJsonAsync("member/login",obj);
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadAsStringAsync();
        }
        return null;
    }
}