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
                .WithMessage("O campo {PropertyName} não pode ter mais de 250 caracteres!");
        }
    }
}
