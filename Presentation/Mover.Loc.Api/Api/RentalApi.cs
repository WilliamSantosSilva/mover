using IET.Common.Model;
using IET.Common.Patterns.DomainNotification.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.Rental.Request;

namespace Mover.Loc.Api.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalApi : ApiController
    {
        protected readonly IRentalApplication _service;
        public RentalApi(INotificationHandler<DomainNotifications> notification, IRentalApplication service) : base(notification)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromBody] RentalAddRequest rental) => CreatedHasNotification(await _service.Add(rental));
    }
}