using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BancoMaster.Domain.Commands.Validations
{
    public class UpdateRotaCommandValidation : RotaValidation<UpdateRotaCommand>
    {
        public UpdateRotaCommandValidation()
        {
            ValidateId();
            ValidateOrigem();
            ValidateDestino();
            ValidateValor();
        }
    }
}
