using Microsoft.EntityFramewrokCore;

using Grit.Database.Entities;
using Grit.Database;

namespace GoodHabits.HabitService.Services;

public class HabitService : IHabitService
{
    private readonly GritDbContext _dbContext;

    public HabitService(GritDbContext dbContext) => _dbContext = dbContext;

    public async Task<Habit> Create(string name, string description)
    {
        var habit = _dbContext.Habits!.Add(new HabitService {
            Name = name,
            Description = description
        }).Entity;

        await _dbContext.SaveChangesAsync();

        return habit;
    }

    public async Task<IReadOnlyList<Habit>> GetAll() => 
        await _dbContext.Habits!.ToListAsync();

    public async Task<HabitService> GetById(int id) => 
        await _dbContext.Habits.FindAsync(id);
}