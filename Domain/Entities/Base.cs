using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public abstract class Base
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id {get;set;}
    public bool IsActive {get;set;} = true;
    public DateTime RegisteredDate {get; private set;} = DateTime.Now;
}
