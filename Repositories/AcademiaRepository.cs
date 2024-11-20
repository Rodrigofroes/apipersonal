using api_personal.Database;
using api_personal.DTOS.OutputDTO;
using api_personal.Entities;
using api_personal.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_personal.Repositories
{
    public class AcademiaRepository : IAcademia
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AcademiaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AcademiaOutputDTO>> ListarAcademias()
        {
            try
            {
                var academias = await _context.Academia.ToListAsync();  
                return _mapper.Map<List<AcademiaOutputDTO>>(academias);  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);  
            }
        }

        public async Task<AcademiaOutputDTO> BuscarAcademia(AcademiaEntity academia)
        {
            try
            {
               var academiaEntity = await _context.Academia.FirstOrDefaultAsync(x => x.Aca_id == academia.Aca_id);
                return _mapper.Map<AcademiaOutputDTO>(academiaEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CadastrarAcademia(AcademiaEntity academia)
        {
            try
            {
                await _context.Academia.AddAsync(academia);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarAcademia(AcademiaEntity academia)
        {
            try
            {
                var academiaEntity = await _context.Academia.FirstOrDefaultAsync(x => x.Aca_id == academia.Aca_id);

                if (academiaEntity == null)
                {
                    throw new KeyNotFoundException("Academia não encontrada.");
                }

                academiaEntity.Aca_nome = academia.Aca_nome;
                academiaEntity.Aca_latitude = academia.Aca_latitude;
                academiaEntity.Aca_longitude = academia.Aca_longitude;
                academiaEntity.Aca_endereco = academia.Aca_endereco;
                academiaEntity.Aca_telefone = academia.Aca_telefone;
                academiaEntity.Aca_email = academia.Aca_email;
                academiaEntity.Aca_logo = academia.Aca_logo;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarAcademia(int id)
        {
            try
            {
                var EId = await _context.Academia.FindAsync(id);  

                if (EId == null)
                {
                    throw new KeyNotFoundException("Academia não encontrada.");
                }

                _context.Academia.Remove(EId);  
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
