using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class Lesson
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int OrderIndex { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<LessonContent> LessonContents { get; set; } = new List<LessonContent>();
}
