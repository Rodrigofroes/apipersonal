using api_personal.DTOS.InputDTO;
using api_personal.Entities;
using api_personal.Repositories.Interfaces;
using api_personal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_personal.Controllers
{
    [ApiController]
    [Route("api/academia")]
    public class AcademiaController : ControllerBase
    {
        private readonly IAcademia _academiaRepository;
        private readonly IEmail _email;

        public AcademiaController(IAcademia academia, IEmail email)
        {
            _academiaRepository = academia;
            _email = email;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarAcademiaAsync()
        {
            try
            {
                var academias = await _academiaRepository.ListarAcademias();

                if (!academias.Any())
                {
                    return NotFound(new
                    {
                        Mensagem = "Nenhuma academia encontrada"
                    });
                }

                return Ok(academias);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("listar/{id}")]
        public async Task<IActionResult> ListarAcademiaPorIdAsync([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Id inválido"
                    });
                }

                var academiaEntity = new AcademiaEntity
                {
                    Aca_id = id
                };

                var academia = await _academiaRepository.BuscarAcademia(academiaEntity);

                if (academia == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Academia não encontrada"
                    });
                }

                return Ok(academia);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = ex.Message,
                });
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarAcademiaAsync([FromBody] AcademiaInputDTO academia)
        {
            try
            {
                if (academia == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Dados inválidos"
                    });
                }
                _email.EnviarEmail(academia.Email!, "Seja Bem-vindo!", "Obrigado por se cadastrar em nosso APP!");
                var academiaEntity = new AcademiaEntity
                {
                    Aca_nome = academia.Nome,
                    Aca_latitude = academia.Latitude,
                    Aca_longitude = academia.Longitude,
                    Aca_endereco = academia.Endereco,
                    Aca_telefone = academia.Telefone,
                    Aca_email = academia.Email,
                    Aca_logo = academia.Logo
                };

                var RAcademia = await _academiaRepository.CadastrarAcademia(academiaEntity);
                if (RAcademia)
                {
                    _email.EnviarEmail(academia.Email!, "Seja Bem-vindo!", "Obrigado por se cadastrar em nosso APP!");
                    return Ok(new
                    {
                        Mensagem = "Academia cadastrada com sucesso"
                    });
                }
                return BadRequest(new
                {
                    Mensagem = "Erro ao cadastrar academia"
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = ex.Message,
                });
            }
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> EditarAcademiaAsync([FromBody] AcademiaInputDTO academia)
        {
            try
            {
                if (academia == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Dados inválidos"
                    });
                }
                var academiaEntity = new AcademiaEntity
                {
                    Aca_id = academia.Id,
                    Aca_nome = academia.Nome,
                    Aca_latitude = academia.Latitude,
                    Aca_longitude = academia.Longitude,
                    Aca_endereco = academia.Endereco,
                    Aca_telefone = academia.Telefone,
                    Aca_email = academia.Email,
                    Aca_logo = academia.Logo
                };
                await _academiaRepository.EditarAcademia(academiaEntity);
                return Ok(new
                {
                    Mensagem = "Academia editada com sucesso"
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = ex.Message,
                });
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeletarAcademiaAsync([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Dados inválidos"
                    });
                }
               
                await _academiaRepository.DeletarAcademia(id);
                return Ok(new
                {
                    Mensagem = "Academia deletada com sucesso"
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Mensagem = ex.Message,
                });
            }
        }
    }
}
