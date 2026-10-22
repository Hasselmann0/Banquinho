using Banquinho.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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
