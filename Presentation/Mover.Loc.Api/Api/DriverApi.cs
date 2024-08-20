using IET.Common.Model;
using IET.Common.Patterns.DomainNotification.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.Driver.Request;

namespace Mover.Loc.Api.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverApi : ApiController
    {
        protected readonly IDriverApplication _service;
        public DriverApi(INotificationHandler<DomainNotifications> notification, IDriverApplication service) : base(notification)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromBody] DriverAddRequest driverAddRequest) => CreatedHasNotification(await _service.Add(driverAddRequest));
    }
}