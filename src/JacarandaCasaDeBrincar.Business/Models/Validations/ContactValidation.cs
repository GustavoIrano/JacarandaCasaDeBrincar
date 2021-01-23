using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 250)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(c => c.PhoneOne)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 14)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(c => c.PhoneTwo)
               .Length(1, 14)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
