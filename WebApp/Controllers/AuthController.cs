using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers;
public class AuthController : BaseController{
    public async Task<IActionResult> Register(){
        ViewBag.Roles = new SelectList(await Provider.Role.GetRoles(),"RoleId","RoleName");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(Member obj)
    {
        int ret = await Provider.Member.Add(obj);
        if (ret > 0)
        {
            return Redirect("/auth/login");
        }
        return View(obj);
    }
    public IActionResult Login(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj){
        string? token = await Provider.Member.Login(obj);
        if (!string.IsNullOrEmpty(token)){
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);
            List<Claim> claims = securityToken.Claims.ToList();

            claims.Add(new Claim(ClaimTypes.Authentication,token));
            
            ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties{
                
            });
            return Redirect("/");
        }
        ModelState.AddModelError("Message", "Login failed");

        return View(obj);
    }
    [Authorize]
    public IActionResult Index(){
        return View();
    }
    [Authorize]
    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/auth/login");
    }
}