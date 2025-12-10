using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class LessonContentProgress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LessonContentId { get; set; }

    public int? SecondsWatched { get; set; }

    public double? ScrollPercentage { get; set; }

    public byte Status { get; set; }

    public bool IsCurrent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual LessonContent LessonContent { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
