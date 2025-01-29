using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities;

public class Reminders : Base
{
    public decimal Value { get; set; }
    [StringLength(100)]
    public string Description { get; set; } = "";
    public TransferType Type {get;set;}

    public long AccountId {get;set;}
    public Account Account {get;set;} = default!;
}
