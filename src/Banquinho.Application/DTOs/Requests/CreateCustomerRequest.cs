using System;
using System.Collections.Generic;
using System.Text;

namespace Banquinho.Application.DTOs.Requests;

public record CreateCustomerRequest
(
    string FullName,
    string CPF,
    string Email,
    string Password,
    string? CNPJ = null
);
