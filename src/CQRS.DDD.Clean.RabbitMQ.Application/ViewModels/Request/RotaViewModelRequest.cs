using System.ComponentModel.DataAnnotations;

namespace Teste.BancoMaster.Application.ViewModels.Request
{
    public class RotaViewModelRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher a Origem.")]
        public string Origem { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Destino.")]
        public string Destino { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Valor.")]
        public decimal Valor { get; set; }
    }
}
