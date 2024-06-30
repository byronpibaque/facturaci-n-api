using Microsoft.AspNetCore.Mvc;

namespace FacturacionSriApi.Controllers
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "Connection successful" });
        }
    }
}