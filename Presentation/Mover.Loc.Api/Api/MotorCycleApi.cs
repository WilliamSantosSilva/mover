using IET.Common.Model;
using IET.Common.Patterns.DomainNotification.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Model.MotorCycle.Request;

namespace Mover.Loc.Api.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorCycleApi : ApiController
    {
        private readonly IMotorCycleApplication _service;
        public MotorCycleApi(INotificationHandler<DomainNotifications> notification, IMotorCycleApplication service) : base(notification)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromBody] MotorCycleAdd motorCycle) => CreatedHasNotification(await _service.Add(motorCycle));

        [HttpGet("getbyplate/{plate}")]
        public async Task<IActionResult> GetByPlate(string plate) => CreatedHasNotification( await _service.GetByPlate(plate));

        [HttpPatch("updateplate")]
        public async Task<IActionResult> UpdatePlate([FromBody] MotorCycleUpdatePlate motorCycle) => CreatedHasNotification(await _service.AlterPlate(motorCycle));

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Delete(string id) => CreatedHasNotification(await _service.Remove(id));
    }
}