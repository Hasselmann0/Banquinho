namespace Banquinho.Application.DTOs.Responses;

public record CustomerResponse
(
    Guid CustomerId,
    string FullName,
    string CPF,
    string Email,
    bool IsActive,
    DateTime? LastLoginAt,
    DateTime CreatedAt
);