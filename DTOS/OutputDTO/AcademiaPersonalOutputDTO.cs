namespace api_personal.DTOS.OutputDTO
{
    public class AcademiaPersonalOutputDTO
    {
        public int Id { get; set; }
        public int AcademiaId { get; set; }
        public int PersonalId { get; set; }
        public DateTime DataInicio { get; set; }
        public decimal Valor { get; set; }

    }
}