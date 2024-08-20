using System.Text;
using System.Text.Json;
using IET.Common.Helpers.Repositorio.Mongo;
using IET.Common.Queue.RabbitMQ;
using IET.Common.Queue.RabbitMQ.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Mover.Loc.Consumer.Listerners
{
    public class MotorCycleAddListener : BackgroundService
    {
        private readonly ILogger<MotorCycleAddListener> _logger;
        protected readonly string conn = Environment.GetEnvironmentVariable("MONGO_CONN");
        protected readonly string connDataBase = Environment.GetEnvironmentVariable("MONGO_DBNAME");

        protected PubSubAMQP _consumerQueue;
        public MotorCycleAddListener(ILogger<MotorCycleAddListener> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    _consumerQueue = new PubSubAMQP(MountConfig());

                    _consumerQueue.ConsumerExchangeFanout(async (s, eventArgs)=> {
                        try
                        {
                            byte[] body = eventArgs.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            var motorCycle = JsonSerializer.Deserialize<Application.Model.MotorCycle.Request.MotorCycleAdd>(message);
                            if(motorCycle != null)
                            {
                                RepositoryBase<Application.Model.MotorCycle.Request.MotorCycleAdd>.Instance().CreateConnection(conn, connDataBase);
                                RepositoryBase<Application.Model.MotorCycle.Request.MotorCycleAdd>.Instance().Add(motorCycle).GetAwaiter();

                            }
                        }
                        catch (System.Exception ex)
                        {               
                            Console.WriteLine($"Error. {ex.ToString()}");
                            throw new Exception(ex.ToString());
                        }
                    });
                }
            }

            return Task.CompletedTask;
        }

        public MessageQueueConfig MountConfig ()
        {
            var config = new MessageQueueConfig(
                Environment.GetEnvironmentVariable("RBT_HOST"), 
                int.Parse(Environment.GetEnvironmentVariable("RBT_PORT")), 
                Environment.GetEnvironmentVariable("RBT_USER"), Environment.GetEnvironmentVariable("RBT_PWD"),
                Environment.GetEnvironmentVariable("RBT_VIRTUAL_HOST"), false, string.Empty
            );

            config.Exchange = Environment.GetEnvironmentVariable("RBT_MOTOR_ADD");

            return config;
        }
    }
}