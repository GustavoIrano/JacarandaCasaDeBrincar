using FluentValidation;

namespace JacarandaCasaDeBrincar.Business.Models.Validations
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 250)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(s => s.Cpf)
                .Length(1, 14)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(s => s.Rg)                
                .Length(1, 12)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(s => s.BloodType)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 3)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
