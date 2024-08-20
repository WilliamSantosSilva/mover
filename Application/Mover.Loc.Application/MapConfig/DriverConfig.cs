using AutoMapper;
using Mover.Loc.Application.Model.Driver;
using Mover.Loc.Application.Model.Driver.Request;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.MapConfig
{
    public class DriverConfig : Profile
    {
        public DriverConfig()
        {
            CreateMap<Driver, DriverAddRequest>()
                .ForMember(map=> map.CnhPhoto, map=> map.MapFrom(x=> x.CnhImageByte))
                .ReverseMap();

            CreateMap<Driver, DriverBaseDefault>()
                .ReverseMap();
        }
    }
}