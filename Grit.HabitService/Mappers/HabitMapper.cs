using AutoMapper;

using Grit.HabitService.Dtos;
using Grit.Database.Entities;

namespace Grit.HabitService.Mappers;

public class HabitMapper : Profile
{
    public HabitMapper()
    {
        CreateMap<Habit, HabitDto>();
    }
}