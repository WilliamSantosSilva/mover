using Mover.Loc.Application.Model.Driver.Request;

namespace Mover.Loc.Application.Contract
{
    public interface IDriverApplication
    {
        Task<bool> Add(DriverAddRequest driver);
        
    }
}