using Banquinho.Application.DTOs.Requests;
using FluentValidation;

namespace Banquinho.Application.Validators;

public class CreateEnterpriseRequestValidator : AbstractValidator<CreateEnterpriseRequest>
{
    public CreateEnterpriseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome da empresa é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
            .MaximumLength(150).WithMessage("O nome não pode passar de 150 caracteres.");

        RuleFor(x => x.CNPJ)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter exatamente 14 números (somente dígitos).")
            .Must(ValidarCnpj).WithMessage("O CNPJ informado é inválido.");

        RuleFor(x => x.LegalRepresentativeId)
            .NotEqual(Guid.Empty).WithMessage("O representante legal é obrigatório.");
    }

    private static bool ValidarCnpj(string? cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) return false;
        if (!cnpj.All(char.IsDigit)) return false;
        if (new string(cnpj[0], 14) == cnpj) return false;

        int[] peso1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] peso2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        int d1 = CalcularDigito(cnpj[..12], peso1);
        int d2 = CalcularDigito(cnpj[..12] + d1, peso2);

        return cnpj.EndsWith($"{d1}{d2}");
    }

    private static int CalcularDigito(string baseNumerica, int[] pesos)
    {
        int soma = 0;
        for (int i = 0; i < pesos.Length; i++)
            soma += (baseNumerica[i] - '0') * pesos[i];

        int resto = soma % 11;
        return resto < 2 ? 0 : 11 - resto;
    }
}
