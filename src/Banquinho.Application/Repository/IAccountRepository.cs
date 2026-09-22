using Banquinho.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Application.Repository
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> GetByAccountNumberAsync(Guid accountNumber);
        Task SaveChangesAsync();
    }
}
