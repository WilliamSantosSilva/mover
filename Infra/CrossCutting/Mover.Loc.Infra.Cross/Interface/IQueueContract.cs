namespace Mover.Loc.Infra.Cross.Interface
{
    public interface IQueueContract
    {
        Task<bool> SendMotorAdd<TEntity>(TEntity motorCycle) where TEntity : class;
    }
}