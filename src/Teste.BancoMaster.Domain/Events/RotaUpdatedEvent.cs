using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.Domain.Core.Events;

namespace Teste.BancoMaster.Domain.Events
{
    public class RotaUpdatedEvent : Event
    {
        public RotaUpdatedEvent(int id, string origem, string destino, decimal valor)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
        public int Id { get; set; }
        public string? Origem { get; private set; }
        public string? Destino { get; private set; }
        public decimal Valor { get; private set; }
    }
}
