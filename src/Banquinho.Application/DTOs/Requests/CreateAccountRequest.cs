using Banquinho.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Application.DTOs.Requests;

public record CreateAccountRequest
(
    Guid? CustomerId,
    Guid? EnterpriseId,
    AccountType AccountType,
    decimal InitialDeposit = 0
);
