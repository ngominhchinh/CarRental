using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi;
public static class Helper{
    public static string RandomString(int len){
        string pattern = "qwertyuiopasdfghjklzxcvbnm1234567890";
        Random rand = new Random();
        char[] arr = new char[len];
        for(int i = 0; i < len; i++){
            arr[i] = pattern[rand.Next(pattern.Length)];
        }
        return string.Join("",arr);
    }
    public static string Hash (string plaintext){
        using HashAlgorithm hash =  SHA512.Create();
        return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(plaintext)));
    }
    public static string GenerateToken(IEnumerable<Claim> claims, string secretKey)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: "cse.net.vn", 
            audience: "cse.net.vn", 
            claims: claims, 
            signingCredentials: credentials, 
            expires: DateTime.Now.AddDays(30));
        return handler.WriteToken(token);
    }
}