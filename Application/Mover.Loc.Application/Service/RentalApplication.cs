using AutoMapper;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.Rental.Request;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Application.Service
{
    public class RentalApplication : BaseApplication, IRentalApplication
    {
        protected readonly IRentalService _service;
        public RentalApplication(INotify notify, IMapper mapper, IRentalService service) : base(notify, mapper)
        {
            _service = service;
        }

        public async Task<bool> Add(RentalAddRequest rental)
        {
            try
            {
                var rentalDomain = _mapper.Map<Rental>(rental);
                await _service.Add(rentalDomain);

                return _notify.IsValid();
            }
            catch (System.Exception ex)
            {             
                throw new Exception(ex.Message);
            }
        }
    }
}