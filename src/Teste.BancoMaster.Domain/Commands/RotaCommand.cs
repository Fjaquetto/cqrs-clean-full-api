using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.Domain.Core.Commands;

namespace Teste.BancoMaster.Domain.Commands
{
    public abstract class RotaCommand : Command
    {
        public int Id { get; protected set; }
        public string? Origem { get; protected set; }
        public string? Destino { get; protected set; }
        public decimal Valor { get; protected set; }
    }
}
