namespace Teste.BancoMaster.Domain.Models
{
    public class Rota
    {
        public int Id { get; set; }
        public string? Origem { get; set; }
        public string? Destino { get; set; }
        public decimal Valor { get; set; }

        public Rota() { }

        public Rota(string? origem, string? destino, decimal valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
    }
}
