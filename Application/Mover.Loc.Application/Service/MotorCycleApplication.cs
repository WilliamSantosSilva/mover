using AutoMapper;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.MotorCycle;
using Mover.Loc.Application.Model.MotorCycle.Request;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;
using Mover.Loc.Infra.Cross.Interface;

namespace Mover.Loc.Application.Service
{
    public class MotorCycleApplication : BaseApplication, IMotorCycleApplication
    {
        private readonly IMotorCycleService _service;
        private readonly IQueueContract _queue;
        public MotorCycleApplication(INotify notify, IMapper mapper, IMotorCycleService service, IQueueContract queue) : base(notify, mapper)
        {
            _service = service;
            _queue = queue;
        }

        public async Task<bool> Add(MotorCycleAdd motorCycle)
        {
            try
            {
                var motorCycleDomain = _mapper.Map<MotorCycle>(motorCycle);

                var modelReturn = await _service.Add(motorCycleDomain);

                if(_notify.IsValid() && motorCycle.Year == 2024)
                {
                    await _queue.SendMotorAdd<MotorCycleAdd>(motorCycle);
                }

               return true;
            }
            catch (System.Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }

        public async Task<MotorCycleBaseDefault> AlterPlate(MotorCycleUpdatePlate motorCycle)
        {
            try
            {
                var motorCycleReturn = await _service.AlterPlate(motorCycle.Id, motorCycle.Plate);

                return _mapper.Map<MotorCycleBaseDefault>(motorCycleReturn);
            }
            catch (System.Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }

        public async Task<MotorCycleBaseDefault> GetByPlate(string plate)
        {
            try
            {
                var motorCyleDomain = await _service.GetByPlate(plate);

                return _mapper.Map<MotorCycleBaseDefault>(motorCyleDomain);
            }
            catch (System.Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}