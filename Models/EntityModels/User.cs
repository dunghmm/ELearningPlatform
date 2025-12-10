using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<LessonContentProgress> LessonContentProgresses { get; set; } = new List<LessonContentProgress>();
}
