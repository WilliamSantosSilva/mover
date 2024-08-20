using IET.Common.Patterns.DomainDriver.Contracts.MongoDb.Repositories;
using MongoDB.Bson;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Domain.Contract.Repository
{
    public interface IMotorCycleRepository : IRepositoryBase<MotorCycle>
    {
        Task<MotorCycle> GetByPlate(string plate);
        Task<MotorCycle> AlterPlate(ObjectId id, string plate);
        Task<bool> Remove(string plate);
    }
}