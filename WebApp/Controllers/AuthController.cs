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
        if (token != null){
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);
            
            ClaimsIdentity identity = new ClaimsIdentity(securityToken.Claims,CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties{
                
            });
            return Redirect("/auth");
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