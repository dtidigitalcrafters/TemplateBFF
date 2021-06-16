using AutoMapper;
using TemplateBFF.Domain.Models.Users;
using TemplateBFF.WebApi.Dtos.Users;

namespace TemplateBFF.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
