using Mover.Loc.Application.Model.Driver;
using Mover.Loc.Application.Model.MotorCycle;
using Mover.Loc.Application.Model.PlanRental.Response;

namespace Mover.Loc.Application.Model.Rental.Request
{
    public class RentalAddRequest
    {
        public DateTime DtStart { get; internal set; }
        public DateTime DtEnd { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public MotorCycleBaseDefault MotorCycle { get; set; }
        public PlanRentalDefaultResponse PlanRental { get; set; }
        public DriverBaseDefault Driver { get; set; }
    }
}