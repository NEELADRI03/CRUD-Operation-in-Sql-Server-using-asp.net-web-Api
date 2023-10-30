using AutoMapper;
using SqlApiDemo.Entities;
using SqlApiDemo.Models;

namespace SqlApiDemo.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee,EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
