namespace WebApp.Models;
public class UploadRepository : BaseRepository{
    public async Task<string?> Upload(IFormFile f){
        MultipartFormDataContent content = new MultipartFormDataContent();
        content.Add(new StreamContent(f.OpenReadStream()), "f", f.FileName);
        using HttpClient client = new HttpClient();
        client.BaseAddress = uri;
        HttpResponseMessage message = await client.PostAsync("upload",content);
        if(message.IsSuccessStatusCode){
            return await message.Content.ReadAsStringAsync();
        }
        return null;
    }
}