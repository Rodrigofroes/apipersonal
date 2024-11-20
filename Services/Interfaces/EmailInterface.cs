namespace api_personal.Services.Interfaces
{
    public interface IEmail
    {
        void EnviarEmail(string email, string subject, string body);
    }
}
