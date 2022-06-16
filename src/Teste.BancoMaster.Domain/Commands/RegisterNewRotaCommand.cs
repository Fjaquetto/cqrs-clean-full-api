using Teste.BancoMaster.Domain.Commands.Validations;

namespace Teste.BancoMaster.Domain.Commands
{
    public class RegisterNewRotaCommand : RotaCommand
    {
        public RegisterNewRotaCommand(int id, string origem, string destino, decimal valor)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRotaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
