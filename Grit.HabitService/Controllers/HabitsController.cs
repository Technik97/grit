using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Grit.HabitService.Dtos;
using Grit.HabitService.Interfaces;

namespace Grit.HabitService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
    private readonly IHabitService _habitService;
    private readonly IMapper _mapper;

    public HabitsController(
        ILogger<HabitsController> logger,
        IHabitService habitsService,
        IMapper mapper
    )
    {
        _logger = logger;
        _habitService = habitsService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id) 
    {
        var habit = await _habitService.GetById(id);
        if (habit == null) return NotFound();

        return Ok(_mapper.Map<HabitDto>(habit));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync() =>
        Ok(_mapper.Map<ICollection<HabitDto>>(await _habitService.GetAll()));

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> CreateAsync([FromForm]CreateHabitDto request)
    {
        var habit = await _habitService.Create(request.Name, request.Description);  
        var habitDto = _mapper.Map<HabitDto>(habit);

        return CreatedAtAction("Get", "Habits", new { id = habitDto.Id}, habitDto);
    }  
}