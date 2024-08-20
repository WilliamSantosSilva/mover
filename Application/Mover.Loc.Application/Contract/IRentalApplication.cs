using Mover.Loc.Application.Model.Rental.Request;

namespace Mover.Loc.Application.Contract
{
    public interface IRentalApplication
    {
        Task<bool> Add(RentalAddRequest rental);        
    }
}