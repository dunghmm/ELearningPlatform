using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class CourseCategory : EntityBaseModel
{
    public int CourseId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
