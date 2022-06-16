using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BancoMaster.Domain.Commands.Validations
{
    public class RegisterNewRotaCommandValidation : RotaValidation<RegisterNewRotaCommand>
    {
        public RegisterNewRotaCommandValidation()
        {
            ValidateId();
            ValidateOrigem();
            ValidateDestino();
            ValidateValor();
        }
    }
}
