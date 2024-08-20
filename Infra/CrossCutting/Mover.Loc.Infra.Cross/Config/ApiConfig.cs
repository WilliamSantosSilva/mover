using IET.Common.Patterns.ApiDefaultRegisters;
using IET.Common.Patterns.LogApplication;
using Microsoft.Extensions.DependencyInjection;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Service;
using Mover.Loc.Infra.Cross.Interface;
using Mover.Loc.Infra.Cross.Service;
using Mover.Loc.Infra.Data;
using Mover.Loc.Infra.Data.Migration;

namespace Mover.Loc.Infra.Cross.Config
{
    public static class ApiConfig
    {
        public static IServiceCollection RegisterInterfaces(this IServiceCollection service)
        {
            service
                .RegisterDefault()
                .RegisterDabaseMongoDb()
                .RegisterSeedMigration()
                .RegisterMapper()
                .RegisterValidator()
                .RegisterLogApi()
                .RegisterDomainServiceApi()
                .RegisterRepositoryApi();

            service.AddTransient<IQueueContract, QueueContract>();

            return service;
        }

        private static IServiceCollection RegisterDomainServiceApi(this IServiceCollection service)
        {
            service.AddTransient<IDriverService, DriverService>();
            service.AddTransient<IMotorCycleService, MotorCycleService>();
            service.AddTransient<IPlanRentalService, PlanRentalService>();
            service.AddTransient<IRentalService, RentalService>();

            return service;
        }

        private static IServiceCollection RegisterRepositoryApi(this IServiceCollection service)
        {
            service.AddTransient<IDriverRepository, DriverRepository>();
            service.AddTransient<IMotorCycleRepository, MotorCycleRepository>();
            service.AddTransient<IPlanRentalRepository, PlanRentalRepository>();
            service.AddTransient<IRentalRepository, RentalRepository>();

            return service;
        }

        /// <summary>
        /// Create seed data in database
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        private static IServiceCollection RegisterSeedMigration(this IServiceCollection service)
        {            
            var migration = new MigrationRunner(Environment.GetEnvironmentVariable("MONGO_CONN"), Environment.GetEnvironmentVariable("MONGO_DBNAME"));
            migration.Migrate();
            return service;
        }
    }
}