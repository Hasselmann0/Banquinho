namespace Banquinho.Application.DTOs.Requests;

public record CreateCustomerRequest
(
    string FullName,
    string CPF,
    string Email,
    string Password
);
