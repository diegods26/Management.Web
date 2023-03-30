using AutoMapper;
using Management.Web.Data;
using Management.Web.Models;

namespace Management.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MyControlType, MyControlTypeVM>().ReverseMap();
        }
    }
}
