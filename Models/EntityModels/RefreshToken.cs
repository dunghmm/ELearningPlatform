using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class RefreshToken : EntityBaseModel
{
    public int UserId { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime? RevokedAt { get; set; }

    public string? ReplacedBy { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public virtual User User { get; set; } = null!;
}
