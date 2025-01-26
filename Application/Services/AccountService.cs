using System;
using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    // Obtém uma conta por ID
    public async Task<AccountDto> GetAccountByIdAsync(long accountId)
    {
        var account = await _accountRepository.Get(a => a.Id == accountId);
        if (account == null) return null!; // Handle not found

        // Conversão manual de Account para AccountDto
        return new AccountDto
        {
            Id = account.Id,
            CurrentBalance = account.CurrentBalance,
            IsActive = account.IsActive
        };
    }

    // Obtém todas as contas
    public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
    {
        var accounts = await _accountRepository.GetAll();
        
        // Conversão manual de lista de Account para lista de AccountDto
        return accounts.Select(account => new AccountDto
        {
            Id = account.Id,
            CurrentBalance = account.CurrentBalance,
            IsActive = account.IsActive
        }).ToList();
    }

    // Cria uma nova conta
    public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
    {
        var account = new Account
        {
            IsActive = dto.IsActive
        };
        
        var createdAccount = await _accountRepository.Create(account);

        // Conversão manual de Account para AccountDto
        return new AccountDto
        {
            Id = createdAccount.Id,
            CurrentBalance = createdAccount.CurrentBalance,
            IsActive = createdAccount.IsActive
        };
    }

    // Atualiza uma conta existente
    public async Task<AccountDto> UpdateAccountAsync(long accountId, UpdateAccountDto dto)
    {
        var account = await _accountRepository.Get(a => a.Id == accountId);
        if (account == null) return null!; // Handle not found

        if (dto.IsActive.HasValue)
            account.IsActive = dto.IsActive.Value;

        var updatedAccount = await _accountRepository.Update(account);

        // Conversão manual de Account para AccountDto
        return new AccountDto
        {
            Id = updatedAccount.Id,
            CurrentBalance = updatedAccount.CurrentBalance,
            IsActive = updatedAccount.IsActive
        };
    }

    // Remove uma conta
    public async Task<bool> DeleteAccountAsync(long accountId)
    {
        var account = await _accountRepository.Get(a => a.Id == accountId);
        if (account == null) return false; // Handle not found

        await _accountRepository.Remove(account);
        return true;
    }

    // Obtém transferências recebidas
    public async Task<IEnumerable<TransfersDto>> GetReceivedTransfers(long accountId)
    {
        var transfers = await _accountRepository.GetReceivedTransfers(accountId);

        // Conversão manual de Transferências para TransfersDto
        return transfers.Select(transfer => new TransfersDto
        {
            Id = transfer.Id,
            Value = transfer.Value,
            Type = transfer.Type,
            AccountOriginId = transfer.AccountOriginId,
            AccountDestinationId = transfer.AccountDestinationId
        }).ToList();
    }

    // Obtém transferências enviadas
    public async Task<IEnumerable<TransfersDto>> GetSentTransfers(long accountId)
    {
        var transfers = await _accountRepository.GetSentTransfers(accountId);

        // Conversão manual de Transferências para TransfersDto
        return transfers.Select(transfer => new TransfersDto
        {
            Id = transfer.Id,
            Value = transfer.Value,
            Type = transfer.Type,
            AccountOriginId = transfer.AccountOriginId,
            AccountDestinationId = transfer.AccountDestinationId
        }).ToList();
    }
}