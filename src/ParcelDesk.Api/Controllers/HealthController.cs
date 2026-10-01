using Microsoft.AspNetCore.Mvc;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.DTOs;

namespace ParcelDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        var response = new HealthResponse
        {
            Status = "ok",
            TimestampUtc = DateTimeOffset.UtcNow
        };
        return Ok(response);
    }

    [HttpGet("database")]
    public async Task<IActionResult> GetDatabaseHealth(
        [FromServices] ParcelDbContext dbContext)
    {
        try
        {
            var canConnect = await dbContext.Database.CanConnectAsync();

            if(!canConnect)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    new
                    {
                        status = "unavailable"
                    });
            }
            return Ok(
                new
                {
                    status = "ok"
                });
        }
        catch
        {
            return StatusCode(
                StatusCodes.Status503ServiceUnavailable,
                new
                {
                    status = "unavailable"
                });
        }
    }
}