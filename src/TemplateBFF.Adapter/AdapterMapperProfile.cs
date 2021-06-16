using AutoMapper;
using TemplateBFF.DtiRoundAdapter.Clients.Users;
using TemplateBFF.Domain.Models.Users;

namespace TemplateBFF.DtiRoundAdapter
{
    public class AdapterMapperProfile : Profile
    {
        public AdapterMapperProfile()
        {
            CreateMap<UserGetResult, User>()
                .ForMember(destino => destino.Id, origem => origem.MapFrom(o => o._id));
        }
    }
}
