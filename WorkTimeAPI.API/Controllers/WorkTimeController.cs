using Microsoft.AspNetCore.Mvc;
using WorkTimeAPI.Repository.Models;
using WorkTimeAPI.Service.Interfaces;

namespace WorkTimeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkTimeController(IWorkTimeService workTimeService) : ControllerBase
{
    private readonly IWorkTimeService _workTimeService = workTimeService;

    [HttpGet("current-month/{userId:long}")]
    public async Task<IActionResult> GetCurrentMonth(int userId)
    {
        List<DailyWorkLog>? dailyWorkLogs = await _workTimeService.GetCurrentMonthAsync(userId);
        return Ok(dailyWorkLogs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDetails(int id)
    {
        DailyWorkLog? dailyWorkLog = await _workTimeService.GetByIdAsync(id);
        if (dailyWorkLog == null)
        {
            return NotFound($"Worl log with ID {id} not found.");
        }
        return Ok(dailyWorkLog);
    }
}
