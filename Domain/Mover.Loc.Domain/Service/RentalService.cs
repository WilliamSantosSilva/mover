using IET.Common.Extensions;
using IET.Common.Monitoring.Contract;
using IET.Common.Patterns.DomainDriver.Services.MongoDb;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Domain.Service
{
    public class RentalService : ServiceBase<Rental>, IRentalService
    {
        public RentalService(IRentalRepository repository, INotify notify, ITreatLogContract logContract) : base(repository, notify, logContract)
        {
        }

        public override Task<Rental> Add(Rental model)
        {
            try
            {
                model.ThrowIfNull();

                model.SetDateStart();
                model.SetEstimateDate();

                Validations(model);

                CalcValEstimate(model);

                return base.Add(model);
            }
            catch (System.Exception ex)
            {                
                throw;
            }            
        }

        public void Validations(Rental model) 
        {
            if(model.Driver.CnhType != "A")
            {
                _notify.NewNotification("Add Rental", "The type of driver's license must be 'A'");
            }
        }

        public void CalcValEstimate(Rental rental)
        {
            if(rental.DtEnd < rental.EstimatedEndDate)
            {
                TimeSpan diferenceDaysNotUsed = rental.EstimatedEndDate - rental.DtEnd;
                TimeSpan diferenceDaysUsed = rental.DtStart - rental.DtEnd;

                var valDayDiffNotUsedValue = diferenceDaysNotUsed.Days * rental.PlanRental.ValueDay;
                var valueAssessment = (valDayDiffNotUsedValue/100) * rental.PlanRental.Assessment;

                var valDailyReal = diferenceDaysUsed.Days * rental.PlanRental.ValueDay;

                rental.ValueEstimated = (valueAssessment + valDailyReal);
            }
            else if(rental.DtEnd > rental.EstimatedEndDate)
            {
                TimeSpan valDailyAdd = rental.DtEnd - rental.EstimatedEndDate;

                var realValue = (rental.PlanRental.PeriodInDays + valDailyAdd.Days) * rental.PlanRental.ValueDay;

                var valueAssessment = valDailyAdd.Days * 50;

                rental.ValueEstimated = (realValue + valueAssessment);
            }
        }
    }
}