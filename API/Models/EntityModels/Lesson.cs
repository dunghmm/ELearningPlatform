using System;
using System.Collections.Generic;

namespace ELearningPlatform.API.Models.EntityModels;

public partial class Lesson : EntityBaseModel
{
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int OrderIndex { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<LessonContent> LessonContents { get; set; } = new List<LessonContent>();
}
