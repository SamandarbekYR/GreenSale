using GreenSale.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenSale.Identity.Data.Entites
{
    public class Device : Entity<Guid>
    {
        public long UserId { get; set; }
        public User? User { get; set; }
        public DeviceType Type { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsTrusted { get; set; }
        public string? IPAddress { get; set; }
        public DateTime LastActive { get; set; }
        public bool IsActive { get; set; }
        public string? FireBaseToken { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum DeviceType
    {
        Other = 0,
        Android = 1,
        Ios = 2,
    }
}