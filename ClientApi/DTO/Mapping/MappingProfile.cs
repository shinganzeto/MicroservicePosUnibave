using AutoMapper;
using ClientApi.Models;

namespace ClientApi.DTO.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
    }
}
