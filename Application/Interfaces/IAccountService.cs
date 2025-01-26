using System;
using Application.DTO;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<AccountDto> GetAccountByIdAsync(long accountId);
    Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
    Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
    Task<AccountDto> UpdateAccountAsync(long accountId, UpdateAccountDto dto);
    Task<bool> DeleteAccountAsync(long accountId);
    Task<IEnumerable<TransfersDto>> GetReceivedTransfers(long accountId);
    Task<IEnumerable<TransfersDto>> GetSentTransfers(long accountId);
}
