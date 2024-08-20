using IET.Common.ValueObjects.MongoDb;

namespace Mover.Loc.Domain.Entities
{
    public class Rental : Entity
    {
        public DateTime DtStart { get; internal set; }
        public DateTime DtEnd { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public bool Active { get; set; }
        public MotorCycle MotorCycle { get; set; }
        public Driver Driver { get; set; }
        public PlanRental PlanRental { get; set; }
        public decimal ValueEstimated { get; set; }

        public void SetDateStart ()
        {
            DtStart = DtInclude.AddDays(1);
        }

        public void SetEstimateDate()
        {
            EstimatedEndDate = DtStart.Date.AddDays(PlanRental.PeriodInDays);
        }
    }
}