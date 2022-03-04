using AutoMapper;
using StatesTest.Data.Models;
using StatesTestWeb.Models;

namespace StatesTestWeb
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CreateTestResultInputDto, TestResult>();
        }
    }
}
