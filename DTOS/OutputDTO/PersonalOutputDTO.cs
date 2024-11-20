using api_personal.Entities;
using System.ComponentModel.DataAnnotations;

namespace api_personal.DTOS.OutputDTO
{
    public class PersonalOutputDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? CREF { get; set; }
        public string? Especialidade { get; set; }
        public string? Foto { get; set; }
        public bool Ativo { get; set; }
        public bool Confirmado { get; set; }
    }

}
