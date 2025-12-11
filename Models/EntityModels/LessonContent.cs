using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class LessonContent : EntityBaseModel
{
    public int LessonId { get; set; }

    public string ContentType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int OrderIndex { get; set; }

    public string ContentUrl { get; set; } = null!;

    public int DurationSeconds { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual ICollection<LessonContentProgress> LessonContentProgresses { get; set; } = new List<LessonContentProgress>();
}
