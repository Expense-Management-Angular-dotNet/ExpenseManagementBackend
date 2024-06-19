using AutoMapper;
using ExpenseManagement.Entities;

using ExpenseManagement.Shared;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
        // Add other mappings here
    }
}
