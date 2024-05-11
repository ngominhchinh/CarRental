using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p =>{
        p.LoginPath = "/auth/login";
    });
builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
