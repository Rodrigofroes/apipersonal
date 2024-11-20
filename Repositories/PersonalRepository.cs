using api_personal.Database;
using api_personal.DTOS.OutputDTO;
using api_personal.Entities;
using api_personal.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_personal.Repositories
{
    public class PersonalRepository : IPersonal
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PersonalRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PersonalOutputDTO>> ListarPersonal()
        {
            try
            {
                var personal = await _context.Personal.ToListAsync();
                return _mapper.Map<List<PersonalOutputDTO>>(personal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonalOutputDTO> BuscarPersonal(PersonalEntity personal)
        {
            try
            {
                var personalEntity = await _context.Personal.FirstOrDefaultAsync(x => x.Per_id == personal.Per_id);
                return _mapper.Map<PersonalOutputDTO>(personalEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CadastrarPersonal(PersonalEntity personal)
        {
            try
            {
                var registroExistente = await _context.Personal
                    .Where(x => x.Per_cpf == personal.Per_cpf || x.Per_cref == personal.Per_cref)
                    .FirstOrDefaultAsync();

                if (registroExistente != null)
                {
                    if (registroExistente.Per_cpf == personal.Per_cpf)
                    {
                        throw new ApplicationException("CPF já cadastrado.");
                    }

                    if (registroExistente.Per_cref == personal.Per_cref)
                    {
                        throw new ApplicationException("CREF já cadastrado.");
                    }
                }

                var usuario = await _context.Personal.AddAsync(personal);

                if (usuario == null)
                {
                    return false;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarPersonal(PersonalEntity personal)
        {
            try
            {
                var personalEntity = await _context.Personal.FirstOrDefaultAsync(x => x.Per_id == personal.Per_id);

                if (personalEntity == null)
                {
                    throw new KeyNotFoundException("Personal não encontrado.");
                }

                var cpfExistente = await _context.Personal
                    .Where(x => x.Per_cpf == personal.Per_cpf)
                    .FirstOrDefaultAsync();

                if (cpfExistente != null && cpfExistente.Per_id != personal.Per_id)
                {
                    throw new ApplicationException("CPF já cadastrado para outro Personal.");
                }

                personalEntity.Per_nome = personal.Per_nome;
                personalEntity.Per_cref = personal.Per_cref;
                personalEntity.Per_cpf = personal.Per_cpf;
                personalEntity.Per_especialidade = personal.Per_especialidade;
                personalEntity.Per_ativo = personal.Per_ativo;
                personalEntity.Per_telefone = personal.Per_telefone;
                personalEntity.Per_foto = personal.Per_foto;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public async Task<bool> DeletarPersonal(int id)
        {
            try
            {
                var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Per_id == id);

                if (personal == null)
                {
                    throw new KeyNotFoundException("Personal não encontrado.");
                }

                _context.Personal.Remove(personal);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
