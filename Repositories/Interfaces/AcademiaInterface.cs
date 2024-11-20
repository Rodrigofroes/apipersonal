using api_personal.DTOS.OutputDTO;
using api_personal.Entities;
namespace api_personal.Repositories.Interfaces
{
    public interface IAcademia
    {
        Task<List<AcademiaOutputDTO>> ListarAcademias();  
        Task<AcademiaOutputDTO> BuscarAcademia(AcademiaEntity academia);
        Task<bool> CadastrarAcademia(AcademiaEntity academia);
        Task<bool> EditarAcademia(AcademiaEntity academia);
        Task<bool> DeletarAcademia(int id);  
    }
}
