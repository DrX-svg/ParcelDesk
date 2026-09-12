using Microsoft.AspNetCore.Mvc;
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
}