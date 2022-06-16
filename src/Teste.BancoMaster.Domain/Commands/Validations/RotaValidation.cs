using FluentValidation;

namespace Teste.BancoMaster.Domain.Commands.Validations
{
    public abstract class RotaValidation<T> : AbstractValidator<T> where T : RotaCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }

        protected void ValidateOrigem()
        {
            RuleFor(c => c.Origem)
                .NotEmpty().WithMessage("")
                .Length(3, 3).WithMessage("");
        }

        protected void ValidateDestino()
        {
            RuleFor(c => c.Destino)
                .NotEmpty().WithMessage("")
                .Length(3, 3).WithMessage("");
        }

        protected void ValidateValor()
        {
            RuleFor(c => c.Origem)
                .NotEmpty();

        }
    }
}
