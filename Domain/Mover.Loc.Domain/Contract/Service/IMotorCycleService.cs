using IET.Common.Patterns.DomainDriver.Contracts.MongoDb.Services;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Domain.Contract.Service
{
    public interface IMotorCycleService : IServiceBase<MotorCycle>
    {
        Task<MotorCycle> GetByPlate(string plate);
        Task<MotorCycle> AlterPlate(string id, string plate);
        Task<bool> Remove(string plate);
    }
}