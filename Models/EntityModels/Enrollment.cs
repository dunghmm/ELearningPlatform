using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class Enrollment : EntityBaseModel
{
    public int UserId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
