using IET.Common.Patterns.DomainDriver.Contracts.MongoDb.Configuration;
using IET.Common.Patterns.DomainDriver.Repositories.MongoDb;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Infra.Data
{
    public class MotorCycleRepository : RepositoryBase<MotorCycle>, IMotorCycleRepository
    {
        public MotorCycleRepository(IBookstoreDatabaseSettings settings, IHttpContextAccessor httpContextAccessor) : base(settings, httpContextAccessor)
        {
        }

        public async Task<MotorCycle> AlterPlate(ObjectId id, string plate)
        {
            try
            {
                MotorCycle motorCycle = await base.GetSingle(x=> x.Plate == plate);
                if(motorCycle == null)
                {
                    throw new ArgumentNullException($"Motorcycle is not found plate:{plate}");
                }
                else
                {
                    motorCycle.Plate = plate;
                    await base.Update(x=> x._id == motorCycle._id, motorCycle);                    
                }

                return motorCycle;
            }
            catch (System.Exception ex)
            {                
                throw new Exception(ex.ToString());
            }
        }

        public async Task<MotorCycle> GetByPlate(string plate) => await base.GetSingle(x=> x.Plate == plate);

        public async Task<bool> Remove(string plate)
        {
            try
            {
                MotorCycle motorCycle = await base.GetSingle(x=> x.Plate == plate);
                await base.Remove(x=> x._id == motorCycle._id, CancellationToken.None);
                return true;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}