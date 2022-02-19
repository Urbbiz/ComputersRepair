using AutoMapper;
using ComputerRepair.Dtos;
using ComputerRepair.Enteties;

namespace ComputerRepair.Mapings
{
    public class MapingsProfile : Profile
    {
        public MapingsProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();

            CreateMap<ComputerDto, Computer>().ReverseMap();    

            CreateMap<MaintenanceDto, Maintenance>().ReverseMap();
        }
    }
}
