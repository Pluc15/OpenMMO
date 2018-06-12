using OpenMMO.Shared.Requests;

namespace OpenMMO.Server.Services
{
    public class LoginService
    {
        public LoginService()
        {
        }

        public bool ValidateCredentials(LoginRequest payload)
        {
            return true;
        }
    }
}
