using AutoMapper;
using TemplateBFF.Adapter.Clients.Users;
using TemplateBFF.Domain.Models.Users;

namespace TemplateBFF.Adapter
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
