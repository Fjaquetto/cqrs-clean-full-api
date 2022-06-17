using FluentValidation;

namespace Teste.BancoMaster.Domain.Commands.Validations
{
    public abstract class RotaValidation<T> : AbstractValidator<T> where T : RotaCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id);

        }

        protected void ValidateOrigem()
        {
            RuleFor(c => c.Origem)
                .NotEmpty()
                .Length(3, 3).WithMessage("3 caracteres.");
        }

        protected void ValidateDestino()
        {
            RuleFor(c => c.Destino)
                .NotEmpty()
                .Length(3, 3).WithMessage("3 caracteres.");
        }

        protected void ValidateValor()
        {
            RuleFor(c => c.Origem)
                .NotEmpty();

        }
    }
}
