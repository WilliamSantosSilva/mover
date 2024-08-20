using IET.Common.ValueObjects.MongoDb;

namespace Mover.Loc.Domain.Entities
{
    public class PlanRental : Entity
    {
        public string Name { get; set; }
        public decimal ValueDay { get; set; }
        public decimal TotalValue { get { return ValueDay * PeriodInDays; } }

        public int PeriodInDays { get; set; }
        public decimal Assessment { get; set; }
    }
}