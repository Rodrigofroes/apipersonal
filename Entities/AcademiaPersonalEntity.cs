using System.ComponentModel.DataAnnotations;
namespace api_personal.Entities
{
    public class AcademiaPersonalEntity
    {
        [Key]
        public int Acp_id { get; set; }
        public int Acp_aca_id { get; set; }
        public int Acp_per_id { get; set; }
        public DateTime Acp_data_inicio { get; set; } = DateTime.Now;
        public decimal Acp_valor { get; set; }
        public AcademiaEntity? Academia { get; set; }
        public PersonalEntity? Personal { get; set; }
    }
}
