using System;
using System.Collections.Generic;

namespace MoneyTrackerAPI.Entities;

public partial class Operation
{
    public long Id { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }

    public string? Comment { get; set; }

    public long CategoryId { get; set; }

    public long AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
