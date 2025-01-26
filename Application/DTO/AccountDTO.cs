using System;

namespace Application.DTO;

public class AccountDto
{
    public long Id { get; set; }
    public decimal CurrentBalance { get; set; }
    public bool IsActive { get; set; }
}

public class CreateAccountDto
{
    public decimal InitialBalance { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateAccountDto
{
    public decimal? NewBalance { get; set; }
    public bool? IsActive { get; set; }
}
