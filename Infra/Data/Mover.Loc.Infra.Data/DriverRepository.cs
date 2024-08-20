using IET.Common.Patterns.DomainDriver.Contracts.MongoDb.Configuration;
using IET.Common.Patterns.DomainDriver.Repositories.MongoDb;
using Microsoft.AspNetCore.Http;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Infra.Data
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(IBookstoreDatabaseSettings settings, IHttpContextAccessor httpContextAccessor) : base(settings, httpContextAccessor)
        {
        }
    }
}