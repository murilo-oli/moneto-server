using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities;

public class User : Base
{
    [StringLength(20)]
    public string FirstName { get; set; } = default!;
    [StringLength(20)]
    public string? LastName { get; set; }
    [StringLength(15)]
    public string? Phone { get; set; }
    [StringLength(100)]
    public string? Email { get; set; }
    [StringLength(20)]
    public string Password { get; set; } = default!;
    public string? Avatar {get; set;}
    public AuthType AuthType {get;set;} = 0;

    public long AccountId { get; set; }
    public Account Account { get; set; } = default!;
}
