using Banquinho.Application.DTOs.Requests;
using Banquinho.Application.DTOs.Responses;
using Banquinho.Application.Mappers;
using Banquinho.Application.Repository;
using Banquinho.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Banquinho.Application.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IValidator<CreateAccountRequest> _validator;

        public AccountService(IAccountRepository accountRepository, IValidator<CreateAccountRequest> validator)
        {
            _accountRepository = accountRepository;
            _validator = validator;
        }

        public async Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var account = request.ToEntity();

            await _accountRepository.AddAsync(account);

            return account.ToResponse();
        }

        public async Task<AccountResponse?> GetAccountByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id); 

            return account?.ToResponse();
        }
    }
}
