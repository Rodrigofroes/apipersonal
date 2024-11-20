using System.ComponentModel.DataAnnotations;

namespace api_personal.DTOS.InputDTO
{
    public class PersonalInputDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O campo cpf é obrigatório")]
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "O campo CREF é obrigatório")]
        public string? CREF { get; set; }
        [Required(ErrorMessage = "O campo especialidade é obrigatório")]
        public string? Especialidade { get; set; }
        [Required(ErrorMessage = "O campo foto é obrigatório")]
        public string? Foto { get; set; }
        public bool Ativo { get; set; }

    }
}
