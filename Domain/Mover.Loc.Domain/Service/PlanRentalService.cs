using IET.Common.Monitoring.Contract;
using IET.Common.Patterns.DomainDriver.Services.MongoDb;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Domain.Service
{
    public class PlanRentalService : ServiceBase<PlanRental>, IPlanRentalService
    {
        public PlanRentalService(IPlanRentalRepository repository, INotify notify, ITreatLogContract logContract) : base(repository, notify, logContract)
        {
        }
    }
}