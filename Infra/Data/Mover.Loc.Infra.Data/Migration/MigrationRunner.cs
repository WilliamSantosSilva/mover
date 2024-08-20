using MongoDB.Driver;

namespace Mover.Loc.Infra.Data.Migration
{
    public class MigrationRunner
    {
        private readonly IMongoDatabase _database;
        private readonly IMigration _migrations;
        private readonly IMongoClient _client;

        public MigrationRunner(string conn, string db)
        {
            _client = new MongoClient(conn);
            _database = _client.GetDatabase(db);
            _migrations = new SeedMigration();            
        }

        public void Migrate()
        {
            _migrations.Up(_database);
        }
    }
}