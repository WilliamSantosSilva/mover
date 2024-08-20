using IET.Common.Queue.RabbitMQ;
using IET.Common.Queue.RabbitMQ.Model;
using Mover.Loc.Infra.Cross.Interface;

namespace Mover.Loc.Infra.Cross.Service
{
    public class QueueContract : IQueueContract
    {
        public MessageQueueConfig MountConfig()
        {
            return new MessageQueueConfig(Environment.GetEnvironmentVariable("RBT_HOST"), 
                                        int.Parse(Environment.GetEnvironmentVariable("RBT_PORT")), 
                                        Environment.GetEnvironmentVariable("RBT_USER"), Environment.GetEnvironmentVariable("RBT_PWD"),
                                        Environment.GetEnvironmentVariable("RBT_VIRTUAL_HOST"), false, string.Empty);
        }
        
        public Task<bool> SendMotorAdd<TEntity>(TEntity motorCycle) where TEntity : class
        {
            try
            {
                var messageQueueConfig = MountConfig();

                messageQueueConfig.Exchange = Environment.GetEnvironmentVariable("RBT_MOTOR_ADD");

                using(var consumerQueue = new PubSubAMQP(messageQueueConfig))
                {
                    consumerQueue.PublishExchangeFanout(motorCycle);
                }
                
                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            } 
        }
    }
}