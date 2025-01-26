using System;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<List<Transfers>> GetReceivedTransfers(long accountId);
    Task<List<Transfers>> GetSentTransfers(long accountId);
}
