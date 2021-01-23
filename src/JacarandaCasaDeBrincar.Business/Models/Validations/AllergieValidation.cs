using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class AllergieValidation : AbstractValidator<Allergie>
    {
        public AllergieValidation()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 250)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
