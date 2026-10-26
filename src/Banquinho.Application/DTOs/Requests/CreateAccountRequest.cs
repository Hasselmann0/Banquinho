using Banquinho.Domain.Enums;

namespace Banquinho.Application.DTOs.Requests;

public record CreateAccountRequest
(   
    Guid? CustomerId,
    Guid? EnterpriseId,
    AccountType AccountType,
    decimal InitialDeposit = 0
);
