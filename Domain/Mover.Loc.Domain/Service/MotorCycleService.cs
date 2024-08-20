using IET.Common.Extensions;
using IET.Common.Monitoring.Contract;
using IET.Common.Patterns.DomainDriver.Services.MongoDb;
using IET.Common.Patterns.DomainNotification.Interface;
using MongoDB.Bson;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Domain.Service
{
    public class MotorCycleService : ServiceBase<MotorCycle>, IMotorCycleService
    {
        private readonly IMotorCycleRepository _repository;
        private readonly IRentalService _rentalService;
        public MotorCycleService(IMotorCycleRepository repository, INotify notify, ITreatLogContract logContract, IRentalService rentalService) 
                : base(repository, notify, logContract)
        {
            _repository = repository;
            _rentalService = rentalService;
        }

        public override async Task<MotorCycle> Add(MotorCycle model)
        {
            try
            {
                model.ThrowIfNull();

                var motorCycleExist = await base.GetSingle(x=> x.Plate == model.Plate);
                if(motorCycleExist != null)
                {
                    _notify.NewNotification("Add Motorcycle", $"The plate {model.Plate} already exists");
                }
                else
                {
                    return await base.Add(model);
                }
            }
            catch (System.Exception ex)
            {                
                _notify.NewNotification("Add Motorcycle", "Internal Server Error");
                await _logContract.Fatal(IET.Common.Monitoring.Enums.LogType.Error, ex);
            }

            return default;

        }

        public async Task<MotorCycle> AlterPlate(string id, string plate) => await _repository.AlterPlate(ObjectId.Parse(id), plate);

        public async Task<MotorCycle> GetByPlate(string plate) => await _repository.GetByPlate(plate);

        public async Task<bool> Remove(string plate)
        {
            try
            {
                var existRental = await _rentalService.GetSingle(x=> x.MotorCycle.Plate == plate);
                if(existRental == null)
                {
                    await _repository.Remove(plate);
                }
                else
                {
                    _notify.NewNotification("Remove", "There is already a rental with this plate");
                }

                return _notify.IsValid();
            }
            catch (System.Exception ex)
            {
                await _logContract.Fatal(IET.Common.Monitoring.Enums.LogType.Error, ex);
                return default;
            }

        }
    }
}