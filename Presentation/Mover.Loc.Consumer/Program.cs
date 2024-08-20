using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mover.Loc.Consumer.Listerners;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<MotorCycleAddListener>();

var host = builder.Build();
host.Run();
