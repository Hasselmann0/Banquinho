using Banquinho.Application.DTOs.Requests;
using Banquinho.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Application.Services
{
    public interface IAccountService
    {
        Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request);
        Task<AccountResponse?> GetAccountByIdAsync(Guid id);

    }
}
