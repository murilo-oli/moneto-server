using System;
using Domain.Enum;

namespace Domain.Entities;

public class Account : Base
{
    public decimal CurrentBalance {get;private set;}

    public ICollection<Transfers> TransfersSent { get; set; } = new HashSet<Transfers>();
    public ICollection<Transfers> TransfersReceived { get; set; } = new HashSet<Transfers>();
    public ICollection<Reminders> Reminders {get;set;} = new HashSet<Reminders>();

    public decimal UpdateCurrentBalance(decimal value, TransferType type){
        if(type == TransferType.In) this.CurrentBalance += value;
        else if(type == TransferType.Out) this.CurrentBalance -= value;

        return this.CurrentBalance;
    }
}
