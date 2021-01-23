using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Cep)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 9)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.City)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 150)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.Complement)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 150)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.Neighborhood)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 150)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.State)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 50)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.Street)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 150)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(a => a.Number)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!");
        }
    }
}
