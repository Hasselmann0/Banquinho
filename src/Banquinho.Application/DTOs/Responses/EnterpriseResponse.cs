namespace Banquinho.Application.DTOs.Responses;

public record EnterpriseResponse(
    Guid EnterpriseId,
    string Name,
    string CNPJ,
    bool IsActive,
    Guid LegalRepresentativeId,
    DateTime CreatedAt
);