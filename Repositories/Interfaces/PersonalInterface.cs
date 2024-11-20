using api_personal.DTOS.OutputDTO;
using api_personal.Entities;

namespace api_personal.Repositories.Interfaces
{
    public interface IPersonal
    {
        Task<List<PersonalOutputDTO>> ListarPersonal();
        Task<PersonalOutputDTO> BuscarPersonal(PersonalEntity academia);
        Task<bool> CadastrarPersonal(PersonalEntity academia);
        Task<bool> EditarPersonal(PersonalEntity academia);
        Task<bool> DeletarPersonal(int id);
    }
}
