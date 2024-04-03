using System;
using System.Collections.Generic;

namespace MoneyTrackerAPI.Entities;

public partial class Account
{
    public long Id { get; set; }

    public decimal Value { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
