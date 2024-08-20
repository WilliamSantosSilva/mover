using MongoDB.Driver;
using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Infra.Data.Migration
{
    public class SeedMigration : IMigration
    {
        public void Up(IMongoDatabase database)
        {
            InsertPlanRental(database);
        }

        private static void InsertPlanRental(IMongoDatabase database)
        {
            var planDataColletion = database.GetCollection<PlanRental>("PlanRental");

            var exists = planDataColletion.Find(Builders<PlanRental>.Filter.Empty).Limit(1).Any();

            if (!exists)
            {
                planDataColletion.InsertMany(Seed.PlanRentalSeed.SeedData);
            }
        }
    }
}