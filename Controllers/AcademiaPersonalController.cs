using api_personal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_personal.Controllers
{
    [ApiController]
    [Route("api/academiapersonal")]
    public class AcademiaPersonalController : ControllerBase
    {
        private readonly IAcademiaPersonal _academiaPersonalRepository;

        public AcademiaPersonalController(IAcademiaPersonal academiaPersonal)
        {
            _academiaPersonalRepository = academiaPersonal;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetAcademiaPersonalAsync()
        {
            try
            {
                var academiaPersonal = await _academiaPersonalRepository.ListarAcademiaPersonal();
                if (!academiaPersonal.Any())
                {
                    return NotFound(new
                    {
                        Mensagem = "Nenhuma academia personal encontrada"
                    });
                }
                return Ok(academiaPersonal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar academia personal: {ex.Message}");
            }
        }
    }
}
