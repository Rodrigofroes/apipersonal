namespace api_personal.DTOS.InputDTO;
using System.ComponentModel.DataAnnotations;

public class AcademiaInputDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome da academia é obrigatório.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Latitude é obrigatória.")]
    public string? Latitude { get; set; }

    [Required(ErrorMessage = "Longitude é obrigatória.")]
    public string? Longitude { get; set; }

    [Required(ErrorMessage = "Endereço é obrigatório.")]
    public string? Endereco { get; set; }

    [Phone(ErrorMessage = "Telefone inválido.")]
    public string? Telefone { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string? Email { get; set; }

    public string? Logo { get; set; }
}

