using Banquinho.Application.DTOs.Requests;
using Banquinho.Application.DTOs.Responses;
using Banquinho.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Application.Mappers
{
    public static class AccountMapper
    {
        public static Account ToEntity(this CreateAccountRequest request)
        {
            return new Account
            {
                CustomerId = request.CustomerId,
                EnterpriseId = request.EnterpriseId,
                AccountType = request.AccountType,
                Balance = request.InitialDeposit,
                Status = true,
                CreatedAt = DateTime.UtcNow
            };
        }
      
        public static AccountResponse ToResponse(this Account account)
        {
            return new AccountResponse(
                account.AccountId,
                account.AccountNumber,
                account.AccountType,
                account.Balance,
                account.Status,
                account.CreatedAt,
                account.CustomerId,
                account.EnterpriseId
            );
        }


    }
}
