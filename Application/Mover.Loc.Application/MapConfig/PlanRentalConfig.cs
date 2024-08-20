using AutoMapper;
using Mover.Loc.Application.Model.PlanRental.Response;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.MapConfig
{
    public class PlanRentalConfig : Profile
    {
        public PlanRentalConfig()
        {
            CreateMap<PlanRental, PlanRentalDefaultResponse>()
                .ReverseMap();
        }
    }
}