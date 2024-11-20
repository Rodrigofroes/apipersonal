using System.ComponentModel.DataAnnotations;
namespace api_personal.Entities
{
    public class AcademiaEntity
    {
        [Key]
        public int Aca_id { get; set; }
        [StringLength(255)]
        public string? Aca_nome { get; set; }
        [StringLength(255)]
        public string? Aca_latitude { get; set; }
        [StringLength(255)]
        public string? Aca_longitude { get; set; }
        [StringLength(255)]
        public string? Aca_endereco { get; set; }
        [StringLength(255)]
        public string? Aca_telefone { get; set; }
        [StringLength(255)]
        public string? Aca_email { get; set; }
        [StringLength(255)]
        public string? Aca_logo { get; set; }

        public ICollection<AcademiaPersonalEntity>? AcademiaPersonals { get; set; }
    }
}
