using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(p => {
    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p => {
    p.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("zxcvbnmasdfghjklqwertyuiop12345678980asdfghjklpoiuytrewq")),
        ValidIssuer = "cse.net.vn",
        ValidAudience = "cse.net.vn",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddControllers();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
