using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BancoMaster.Domain.Commands.Validations
{
    public class RemoveRotaCommandValidation : RotaValidation<RemoveRotaCommand>
    {
        public RemoveRotaCommandValidation()
        {
            ValidateId();
            ValidateOrigem();
            ValidateDestino();
            ValidateValor();
        }
    }
}
