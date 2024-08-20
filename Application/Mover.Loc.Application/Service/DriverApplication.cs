using AutoMapper;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.Driver.Request;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.Service
{
    public class DriverApplication : BaseApplication, IDriverApplication
    {
        protected readonly IDriverService _service;
        public DriverApplication(INotify notify, IMapper mapper, IDriverService service) : base(notify, mapper)
        {
            _service = service;
        }

        public async Task<bool> Add(DriverAddRequest driver)
        {
            try
            {
                var driverDomain = _mapper.Map<Driver>(driver);

                await _service.Add(driverDomain);

                return _notify.IsValid();
            }
            catch (System.Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }
    }
}