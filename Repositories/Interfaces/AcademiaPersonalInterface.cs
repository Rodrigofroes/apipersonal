using api_personal.DTOS.OutputDTO;
using api_personal.Entities;

namespace api_personal.Repositories.Interfaces
{
    public interface IAcademiaPersonal
    {
        Task<List<AcademiaPersonalOutputDTO>> ListarAcademiaPersonal();
        Task<AcademiaPersonalOutputDTO> BuscarAcademiaPersonal(AcademiaPersonalEntity academiapersonal);
        Task<bool> CadastrarAcademiaPersonal(AcademiaPersonalEntity academiapersonal);
        Task<bool> EditarAcademiaPersonal(AcademiaPersonalEntity academiapersonal);
        Task<bool> DeletarAcademiaPersonal(int id);
    }
}
