using OpenMMO.Server.Services;
using OpenMMO.Shared.Requests;
using Serilog;

namespace OpenMMO.Server.Handlers
{
    public class LoginRequestHandler : IRequestHandler
    {
        private readonly LoginService _loginService;

        public LoginRequestHandler(LoginService loginService)
        {
            _loginService = loginService;
        }

        public void Handle(byte[] packet)
        {
            var request = LoginRequest.FromPacket(packet);
            if (_loginService.ValidateCredentials(request))
                Log.Information($"User logged in: {request.Username}");
            else
                Log.Warning($"User login failed: {request.Username}");
        }
    }
}
