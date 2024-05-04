using System.Security.Claims;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class MemberController : BaseController{
    public IEnumerable<Member> GetMembers() {
        return Provider.Member.GetMembers();
    }
    [HttpPost]
    public int Add(Member obj){
        return Provider.Member.Add(obj);
    }
    [HttpPost("login")]
    public string? Login(LoginModel obj){
        //return Provider.Member.Login(obj);
        Member? member = Provider.Member.Login(obj);
        if(member != null && member.MemberId != null){
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, member.MemberId),
                new Claim(ClaimTypes.Name, member.FullName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role, member.RoleId.ToString())      
            };
            return Helper.GenerateToken(claims, "zxcvbnmasdfghjklqwertyuiop12345678980asdfghjklpoiuytrewq");
        }
        return null;
    }
    [Authorize]
    public string Welcome(){
        return "Welcome";
    }
}