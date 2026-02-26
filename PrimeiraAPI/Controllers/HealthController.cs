using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraAPI.Controllers
{
    // Rota base: /api/health.
    [Route("api/statusAPI")]

    // Ativa validação automática e outras funcionalidades de API.
    [ApiController]

    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna uma mensagem simples 200 OK.
            return Ok(new
            {
                status = "UP",
                service = "PrimeiraAPI",
                date = DateTime.Now
            });
        }
    }
}
