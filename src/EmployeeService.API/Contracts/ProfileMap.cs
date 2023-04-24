using AutoMapper;

namespace EmployeeService.API.Contracts;
public class ProfileMap : Profile
{
    public ProfileMap()
    {
        CreateMap<Position, PositionDetailDto>();
    }
}
