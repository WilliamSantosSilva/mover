using IET.Common.ValueObjects.MongoDb;

namespace Mover.Loc.Domain.Entities
{
    public class MotorCycle : Entity
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}