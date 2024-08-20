using AutoMapper;
using Mover.Loc.Application.Model.MotorCycle;
using Mover.Loc.Application.Model.MotorCycle.Request;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.MapConfig
{
    public class MotorCycleConfig : Profile
    {
        public MotorCycleConfig()
        {
            CreateMap<MotorCycle, MotorCycleAdd>()
                .ReverseMap();

            CreateMap<MotorCycle, MotorCycleUpdatePlate>()
                .ForMember(map=> map.Id, map=> map.MapFrom(x=> x.Id))
                .ReverseMap();

            CreateMap<MotorCycle, MotorCycleBaseDefault>()
                .ForMember(map=> map.Id, map=> map.MapFrom(x=> x.Id))
                .ReverseMap();
        }
    }
}