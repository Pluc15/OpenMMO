using OpenMMO.Server.Configurations;
using OpenMMO.Server.Handlers;
using OpenMMO.Server.Listeners;
using OpenMMO.Server.Services;
using OpenMMO.Server.Utils;
using OpenMMO.Shared.Requests;
using OpenMMO.Shared.Utils;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenMMO.Server
{
    public class Server
    {
        private LoginListener _loginListener;

        public Server(BaseConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var loginService = new LoginService();
            var socketHelper = new SocketHelper();
            var requestHandlers = new Dictionary<Type, IRequestHandler>
            {
                { typeof(LoginRequest), new LoginRequestHandler(loginService) }
            };

            _loginListener = new LoginListener(
                configuration.Login,
                socketHelper,
                requestHandlers);
        }

        public void Start()
        {
            Log.Information("Starting Server...");

            var loginTask = _loginListener.StartAsync();

            Task.WhenAny(loginTask)
                .GetAwaiter()
                .GetResult();
        }
    }
}
