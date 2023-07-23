using Microsoft.AspNetCore.Mvc;

using Grit.HabitService.Dtos;

namespace Grit.HabitService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
    private readonly IHabitService _habitService;

    public HabitsController(
        ILogger<HabitsController> logger,
        IHabitService habitsService
    )
    {
        _logger = logger;
        _habitService = habitsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id) =>
        Ok(await _habitService.GetById(id));

    [HttpGet]
    public async Task<IActionResult> GetAsync() =>
        Ok(await _habitService.GetAll());

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateHabitDto request) =>
        Ok(await _habitService.Create(request.Name, request.Description));    
}