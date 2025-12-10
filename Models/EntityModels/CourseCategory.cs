using System;
using System.Collections.Generic;

namespace ELearningPlatform.Models.EntityModels;

public partial class CourseCategory
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
