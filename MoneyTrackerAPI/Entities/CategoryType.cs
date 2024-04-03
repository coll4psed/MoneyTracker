using System;
using System.Collections.Generic;

namespace MoneyTrackerAPI.Entities;

public partial class CategoryType
{
    public long Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
