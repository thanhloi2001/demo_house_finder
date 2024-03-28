using AutoMapper;
using Demo_Mock_House_Finder.Model;
using Demo_Mock_House_Finder.Model.DTO;

namespace Demo_Mock_House_Finder
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, AddressCreateDTO>().ReverseMap();
            CreateMap<Address, AddressUpdateDTO>().ReverseMap();
        } 
    }
}
