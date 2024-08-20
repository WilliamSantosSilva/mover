using Microsoft.Extensions.DependencyInjection;
using Mover.Loc.Application.Contract;
using Mover.Loc.Application.Service;

namespace Mover.Loc.Application
{
    public static class RegisterApplication
    {
        public static IServiceCollection RegisterApplicationService(this IServiceCollection service)
        {
            service.AddTransient<IDriverApplication, DriverApplication>();
            service.AddTransient<IMotorCycleApplication, MotorCycleApplication>();
            service.AddTransient<IRentalApplication, RentalApplication>();

            return service;
        }
    }
}