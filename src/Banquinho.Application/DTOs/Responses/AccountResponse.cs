using Banquinho.Domain.Enums;

namespace Banquinho.Application.DTOs.Responses;

public record AccountResponse
(
    Guid AccountId,
    Guid AccountNumber,
    AccountType AccountType,
    decimal Balance,
    bool IsActive,
    DateTime CreatedAt,
    Guid? CustomerId,
    Guid? EnterpriseId
);
