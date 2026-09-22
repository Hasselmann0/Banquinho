using Banquinho.Application.Repository;
using Banquinho.Domain.Entities;
using Banquinho.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BanquinhoDbContext _context;
        public AccountRepository(BanquinhoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account?> GetByAccountNumberAsync(Guid accountNumber)
        {
            return await _context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
