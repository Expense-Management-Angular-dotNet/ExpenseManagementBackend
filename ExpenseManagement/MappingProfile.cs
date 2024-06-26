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

        CreateMap<UserRequestDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Only map non-null values
        CreateMap<User, UserResponseDto>();

        CreateMap<Expense, ExpenseDTO>().ReverseMap();
        CreateMap<ExpenseDTO, Expense>();

        // Map from SalaryDto to SalaryRecord
        CreateMap<SalaryDto, SalaryRecord>()
            .ForMember(dest => dest.LastChangedDate, opt => opt.MapFrom(src => src.year.HasValue && src.month.HasValue
                ? new DateTime(src.year.Value, src.month.Value, 1, 0, 0, 0, DateTimeKind.Utc)
                : DateTime.MinValue))
            .ForMember(dest => dest.SalaryRecordID, opt => opt.Condition(src => !string.IsNullOrEmpty(src.SalaryRecordID)))
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

        // Map from SalaryRecord to SalaryDto
        CreateMap<SalaryRecord, SalaryDto>()
            .ForMember(dest => dest.month, opt => opt.MapFrom(src => src.LastChangedDate.Month))
            .ForMember(dest => dest.year, opt => opt.MapFrom(src => src.LastChangedDate.Year))
            .ForMember(dest => dest.SalaryRecordID, opt => opt.MapFrom(src => src.SalaryRecordID))
            .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        // Add other mappings here
    }
}
