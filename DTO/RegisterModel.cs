namespace DTO;
public class RegisterModel{    
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public byte RoleId { get; set; }
}