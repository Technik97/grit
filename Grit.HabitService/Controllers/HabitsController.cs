using Microsoft.AspNetCore.Mvc;

using Grit.HabitService.Dtos;
using Grit.HabitService.Interfaces;

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
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> CreateAsync([FromForm]CreateHabitDto request) =>
        Ok(await _habitService.Create(request.Name, request.Description));    
}