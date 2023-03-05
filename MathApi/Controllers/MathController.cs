using MathApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MathApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MathController : ControllerBase
{
    [HttpGet("add")]
    public async Task<IActionResult> AddAsync(
        [FromQuery] long a,
        [FromQuery] long b,
        [FromServices] IMathService mathService,
        CancellationToken cancellationToken = default)
        {
            var result = await mathService.AddAsync(a, b);

            return Ok(new { result = result });
        }
}