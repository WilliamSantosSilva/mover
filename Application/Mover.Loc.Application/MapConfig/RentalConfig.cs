using AutoMapper;
using Mover.Loc.Application.Model.Rental.Request;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.MapConfig
{
    public class RentalConfig : Profile
    {
        public RentalConfig()
        {
            CreateMap<Rental, RentalAddRequest>()
                .ReverseMap();
        }
    }
}