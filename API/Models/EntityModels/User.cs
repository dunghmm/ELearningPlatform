using System;
using System.Collections.Generic;

namespace ELearningPlatform.API.Models.EntityModels;

public partial class User : EntityBaseModel
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? ForgotPasswordToken { get; set; }

    public DateTime? ForgotPasswordTokenExpire { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<LessonContentProgress> LessonContentProgresses { get; set; } = new List<LessonContentProgress>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
