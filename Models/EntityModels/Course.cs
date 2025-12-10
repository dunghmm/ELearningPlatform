using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
