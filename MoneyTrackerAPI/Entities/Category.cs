using System;
using System.Collections.Generic;

namespace MoneyTrackerAPI.Entities;

public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long CategoryTypeId { get; set; }

    public virtual CategoryType CategoryType { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
