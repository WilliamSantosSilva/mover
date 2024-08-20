using IET.Common.Model;
using IET.Common.Patterns.DomainNotification.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mover.Loc.Api.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanRentalApi : ApiController
    {        
        protected PlanRentalApi(INotificationHandler<DomainNotifications> notification) : base(notification)
        {
        }

        //TODO: Precisava de uma definição sobre as multas vs valores do plano
    }
}