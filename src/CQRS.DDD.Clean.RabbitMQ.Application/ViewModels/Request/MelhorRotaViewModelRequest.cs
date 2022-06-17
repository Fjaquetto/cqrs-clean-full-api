using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BancoMaster.Application.ViewModels.Request
{
    public class MelhorRotaViewModelRequest
    {
        [Required(ErrorMessage = "É necessário preencher a Origem.")]
        [MinLength(3)]
        [MaxLength(3)]
        public string Origem { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Destino.")]
        [MinLength(3)]
        [MaxLength(3)]
        public string Destino { get; set; }
    }
}
