using System;
using System.Collections.Generic;

namespace ELearningPlatform.API.Models.EntityModels;

public partial class LessonContentProgress : EntityBaseModel
{
    public int UserId { get; set; }

    public int LessonContentId { get; set; }

    public int? SecondsWatched { get; set; }

    public double? ScrollPercentage { get; set; }

    public byte Status { get; set; }

    public bool IsCurrent { get; set; }

    public virtual LessonContent LessonContent { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
