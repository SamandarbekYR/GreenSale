using GreenSale.Data.Entities;

namespace GreenSale.Identity.Data.Entites;

public class UserOtp : Entity<Guid>
{
    public long UserId { get; set; }
    public User? User { get; set; }
    public string Provider { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string Purpose { get; set; } = string.Empty;
    public string? Otp { get; set; }
}