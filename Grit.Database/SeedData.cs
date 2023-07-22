using Microsoft.EntityFrameworkCore;

using Grit.Database.Entities;

public static class SeedData 
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habit>().HasData(
            new Habit { Id = 100, Name = "Exercise", Description = "Lose some weight"  }
        );
    }
}

