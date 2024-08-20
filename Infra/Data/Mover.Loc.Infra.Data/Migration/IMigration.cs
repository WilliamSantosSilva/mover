using MongoDB.Driver;

namespace Mover.Loc.Infra.Data.Migration
{
    public interface IMigration
    {
        void Up(IMongoDatabase database);
    }
}