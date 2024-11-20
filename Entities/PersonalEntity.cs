using System.ComponentModel.DataAnnotations;
namespace api_personal.Entities
{
    public class PersonalEntity
    {
        [Key]
        public int Per_id { get; set; }
        [StringLength(255)]
        public string? Per_nome { get; set; }
        [StringLength(255)]
        public string? Per_cref { get; set; }
        [StringLength(255)]
        public string? Per_telefone { get; set; }
        [StringLength(255)]
        public string? Per_especialidade { get; set; }
        [StringLength(255)]
        public string? Per_foto { get; set; }
        [StringLength(255)]
        public string? Per_cpf { get; set; }
        public bool Per_ativo { get; set; } = true;
        public bool Per_confirmado { get; set; } = false;
        [StringLength(255)]
        public string? Per_email { get; set; }
        public ICollection<AcademiaPersonalEntity>? AcademiaPersonals { get; set; }
    }
}
