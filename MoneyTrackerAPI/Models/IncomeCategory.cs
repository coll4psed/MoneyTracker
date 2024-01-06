﻿using MoneyTrackerAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTrackerAPI.Models
{
    public class IncomeCategory : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Income> Incomes { get; set; } = new();
    }
}