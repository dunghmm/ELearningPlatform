using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class Course : EntityBaseModel
{
    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
