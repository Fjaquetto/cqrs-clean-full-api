using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.Domain.Commands.Validations;

namespace Teste.BancoMaster.Domain.Commands
{
    public class UpdateRotaCommand : RotaCommand
    {
        public UpdateRotaCommand(int id, string origem, string destino, decimal valor)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRotaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
