using Mover.Loc.Domain.Entities;

namespace Mover.Loc.Infra.Data.Migration.Seed
{
    public class PlanRentalSeed
    {
        public static PlanRental[] SeedData => 
        [ 
            new PlanRental { Name = "Plan 1", PeriodInDays = 7, ValueDay = 30, Assessment = 20  },
            new PlanRental { Name = "Plan 2", PeriodInDays = 15, ValueDay = 28, Assessment = 40  },
            new PlanRental { Name = "Plan 3", PeriodInDays = 30, ValueDay = 22, Assessment = 0  },
            new PlanRental { Name = "Plan 4", PeriodInDays = 45, ValueDay = 20, Assessment = 0  },
            new PlanRental { Name = "Plan 5", PeriodInDays = 50, ValueDay = 18, Assessment = 0  },
        ];
    }
}