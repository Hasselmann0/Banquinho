namespace Banquinho.Application.DTOs.Requests;

public record CreateEnterpriseRequest(
    string Name,
    string CNPJ,
    Guid LegalRepresentativeId
);