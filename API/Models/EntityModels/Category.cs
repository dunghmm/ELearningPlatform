using System;
using System.Collections.Generic;

namespace ELearningPlatform.API.Models.EntityModels;

public partial class Category : EntityBaseModel
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();
}
