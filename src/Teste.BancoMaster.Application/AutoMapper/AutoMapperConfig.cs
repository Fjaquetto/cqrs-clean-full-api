using AutoMapper;
using Teste.BancoMaster.Application.ViewModels.Request;
using Teste.BancoMaster.Domain.Commands;
using Teste.BancoMaster.Domain.Models;

namespace Teste.BancoMaster.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Rota, RotaViewModelRequest>().ReverseMap();

            CreateMap<RotaViewModelRequest, RegisterNewRotaCommand>()
                .ConstructUsing(x => new RegisterNewRotaCommand(0, x.Origem, x.Destino, x.Valor));

            CreateMap<RotaViewModelRequest, RegisterNewRotaCommand>()
                .ConstructUsing(x => new RegisterNewRotaCommand(x.Id, x.Origem, x.Destino, x.Valor));
        }
    }
}
