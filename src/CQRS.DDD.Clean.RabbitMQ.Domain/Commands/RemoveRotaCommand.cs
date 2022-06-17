using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.Domain.Commands.Validations;

namespace Teste.BancoMaster.Domain.Commands
{
    public class RemoveRotaCommand : RotaCommand
    {
        public RemoveRotaCommand(int id, string origem, string destino, decimal valor)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveRotaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
