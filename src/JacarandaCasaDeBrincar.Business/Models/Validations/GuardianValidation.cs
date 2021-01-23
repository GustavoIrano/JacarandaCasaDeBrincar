using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class GuardianValidation : AbstractValidator<Guardian>
    {
        public GuardianValidation()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 250)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(g => g.Cpf)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 14)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(g => g.Rg)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 12)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(g => g.CompanyName)
              .Length(1, 250)
              .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(g => g.Kinship)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 50)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(g => g.Occupation)
                .Length(1, 150)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
