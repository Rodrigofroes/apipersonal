using api_personal.Database;
using api_personal.DTOS.OutputDTO;
using api_personal.Entities;
using api_personal.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_personal.Repositories
{
    public class AcademiaPersonalRepository : IAcademiaPersonal
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AcademiaPersonalRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AcademiaPersonalOutputDTO>> ListarAcademiaPersonal()
        {
            try 
            {
                var lista = await _context.AcademiaPersonal.ToListAsync();
                return _mapper.Map<List<AcademiaPersonalOutputDTO>>(lista);

            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AcademiaPersonalOutputDTO> BuscarAcademiaPersonal(AcademiaPersonalEntity academiapersonal)
        {
            try
            {
                var academiapersonalEntity = await _context.AcademiaPersonal.FirstOrDefaultAsync(x => x.Acp_id == academiapersonal.Acp_id);
                return _mapper.Map<AcademiaPersonalOutputDTO>(academiapersonalEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CadastrarAcademiaPersonal(AcademiaPersonalEntity academiapersonal)
        {
            try
            {
                await _context.AcademiaPersonal.AddAsync(academiapersonal);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarAcademiaPersonal(AcademiaPersonalEntity academiapersonal)
        {
            try
            {
                _context.AcademiaPersonal.Update(academiapersonal);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarAcademiaPersonal(int id)
        {
            try
            {
                var EId = await _context.AcademiaPersonal.FindAsync(id);

                if (EId == null)
                {
                    throw new KeyNotFoundException("Academia não encontrada.");
                }

                _context.AcademiaPersonal.Remove(EId);
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
