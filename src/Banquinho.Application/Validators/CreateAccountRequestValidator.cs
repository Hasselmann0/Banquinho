using Banquinho.Application.DTOs.Requests;
using Banquinho.Domain.Enums;
using FluentValidation;

namespace Banquinho.Application.Validators
{
    public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator()
        {
            RuleFor(x => x)
                .Must(x => x.CustomerId.HasValue ^ x.EnterpriseId.HasValue)
                .WithMessage("A conta deve pertencer exclusivamente a um Cliente (PF) ou a uma Empresa (PJ).");

            RuleFor(x => x.AccountType)
                .IsInEnum()
                .WithMessage("O tipo de conta informado é inválido.");

            RuleFor(x => x.AccountType)
                .NotEqual(AccountType.Salario)
                .When(x => x.EnterpriseId.HasValue)
                .WithMessage("Contas jurídicas (Enterprise) não podem ser do tipo Salário.");

            RuleFor(x => x.InitialDeposit)
                .GreaterThanOrEqualTo(100)
                .When(x => x.AccountType == AccountType.Investimento)
                .WithMessage("Contas de investimento exigem um depósito inicial de no mínimo R$ 100,00.");

            RuleFor(x => x.InitialDeposit)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O depósito inicial não pode ser 0 ou um valor negativo.");


        }
    }
}
