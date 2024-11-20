using System.Text.RegularExpressions;

namespace api_personal.Utils
{
    public class ValidateUltis
    {
        public bool ValidacaoEmail(string email)
        {
            Regex exp = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|org|net|edu|gov|io|dev|tech|info|biz|co|me|com\.br|gov\.br|edu\.br)$");
            return exp.IsMatch(email);
        }
    }
}
