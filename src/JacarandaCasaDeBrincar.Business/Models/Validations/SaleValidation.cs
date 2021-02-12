using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class SaleValidation : AbstractValidator<Sale>
    {
        public SaleValidation()
        {
            RuleFor(sv => sv.CustomerName)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 250)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(sv => sv.CustomerCpf)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 14)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(sv => sv.CustomerRg)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 12)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(sv => sv.ServicesProducts)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 250)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
