using api_personal.DTOS.InputDTO;
using api_personal.Entities;
using api_personal.Repositories.Interfaces;
using api_personal.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api_personal.Controllers
{
    [ApiController]
    [Route("api/personal")]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonal _personalRepository;
        private readonly ValidateUltis _validateUltis;

        public PersonalController(IPersonal personal, ValidateUltis validate)
        {
            _personalRepository = personal;
            _validateUltis = validate;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPersonalAsync()
        {
            try
            {
                var personal = await _personalRepository.ListarPersonal();
                if (!personal.Any())
                {
                    return NotFound(new
                    {
                        Mensagem = "Nenhum personal encontrado"
                    });
                }
                return Ok(personal);
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
        public async Task<IActionResult> BuscarPersonalAsync([FromRoute] int id)
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

                var Epersonal = new PersonalEntity
                {
                    Per_id = id
                };

                var personal = await _personalRepository.BuscarPersonal(Epersonal);
                if (personal == null)
                {
                    return NotFound(new
                    {
                        Mensagem = "Personal não encontrado"
                    });
                }
                return Ok(personal);
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
        public async Task<IActionResult> CadastrarPersonalAsync([FromBody] PersonalInputDTO personal)
        {
            try
            {
                if (!_validateUltis.ValidacaoEmail(personal.Email!))
                {
                    return BadRequest(new
                    {
                        Mensagem = "Email inválido"
                    });
                }

                    var Epersonal = new PersonalEntity
                {
                    Per_nome = personal.Nome,
                    Per_cref = personal.CREF,
                    Per_telefone = personal.Telefone,
                    Per_especialidade = personal.Especialidade,
                    Per_foto = personal.Foto,
                    Per_cpf = personal.Cpf
                };

                var result = await _personalRepository.CadastrarPersonal(Epersonal);

                if (!result)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao cadastrar personal"
                    });
                }

                return Ok(new
                {
                    Mensagem = "Personal cadastrado com sucesso"
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
        public async Task<IActionResult> EditarPersonalAsync([FromBody] PersonalInputDTO personal)
        {
            try
            {
                if (personal.Id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Id inválido"
                    });
                }

                if (!_validateUltis.ValidacaoEmail(personal.Email!))
                {
                    return BadRequest(new
                    {
                        Mensagem = "Email inválido"
                    });
                }

                var Epersonal = new PersonalEntity
                {
                    Per_id = personal.Id,
                    Per_nome = personal.Nome,
                    Per_cref = personal.CREF,
                    Per_telefone = personal.Telefone,
                    Per_especialidade = personal.Especialidade,
                    Per_foto = personal.Foto,
                    Per_cpf = personal.Cpf,
                    Per_ativo = personal.Ativo
                };

                var result = await _personalRepository.EditarPersonal(Epersonal);
                if (!result)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao editar personal"
                    });
                }
                return Ok(new
                {
                    Mensagem = "Personal editado com sucesso"
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
        public async Task<IActionResult> DeletePersonalAsync([FromRoute] int id)
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

                var result = await _personalRepository.DeletarPersonal(id);
                if (!result)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao deletar personal"
                    });
                }
                return Ok(new
                {
                    Mensagem = "Personal deletado com sucesso"
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
