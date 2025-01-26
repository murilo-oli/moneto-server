using System;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(MonetoDbContext context) : base(context){}

    public async Task<List<Transfers>> GetReceivedTransfers(long accountId){
        return await _context.Set<Transfers>().Where(t=> t.AccountDestinationId == accountId).ToListAsync();
    }

    public async Task<List<Transfers>> GetSentTransfers(long accountId){
        return await _context.Set<Transfers>().Where(t=> t.AccountOriginId == accountId).ToListAsync();
    }
}
