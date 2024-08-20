using Mover.Loc.Application.Model.MotorCycle;
using Mover.Loc.Application.Model.MotorCycle.Request;

namespace Mover.Loc.Application.Contract
{
    public interface IMotorCycleApplication
    {
        Task<bool> Add(MotorCycleAdd motorCycle);
        Task<MotorCycleBaseDefault> GetByPlate(string plate);
        Task<MotorCycleBaseDefault> AlterPlate(MotorCycleUpdatePlate motorCycle);
        Task<bool> Remove(string id);
    }
}