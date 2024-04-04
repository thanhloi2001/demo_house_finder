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
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<House, HouseUpdateDTO>().ReverseMap();
            CreateMap<House, HouseCreateDTO>().ReverseMap();
            CreateMap<Rate, RateDTO>().ReverseMap();
            CreateMap<Rate, RateCreateDTO>().ReverseMap();
            CreateMap<Rate, RateUpdateDTO>().ReverseMap();
            CreateMap<User, LandlordDTO>().ReverseMap();
            CreateMap<User, LandlordCreateDTO>().ReverseMap();
            CreateMap<User, LandlordUpdateDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, RoomCreateDTO>().ReverseMap();
            CreateMap<Room, RoomUpdateDTO>().ReverseMap();
        } 
    }
}
