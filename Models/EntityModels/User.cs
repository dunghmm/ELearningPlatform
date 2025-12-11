using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class User : EntityBaseModel
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<LessonContentProgress> LessonContentProgresses { get; set; } = new List<LessonContentProgress>();
}
