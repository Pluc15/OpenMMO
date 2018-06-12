using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using OpenMMO.Server.Configurations;
using OpenMMO.Server.Handlers;
using OpenMMO.Server.Utils;
using OpenMMO.Shared.Requests;
using OpenMMO.Shared.Utils;
using Serilog;

namespace OpenMMO.Server.Listeners
{
    public class LoginListener
    {
        private readonly LoginConfiguration _loginConfig;
        private readonly SocketHelper _socketHelper;
        private readonly Dictionary<Type, IRequestHandler> _requestHandlers;

        public LoginListener(
            LoginConfiguration loginConfig,
            SocketHelper socketHelper,
            Dictionary<Type, IRequestHandler> requestHandlers)
        {
            _loginConfig = loginConfig;
            _socketHelper = socketHelper;
            _requestHandlers = requestHandlers;
        }

        public async Task StartAsync()
        {
            Log.Information($"Starting on {_loginConfig.IpAddress}:{_loginConfig.Port}");
            var listener = _socketHelper.CreateListener(_loginConfig.IpAddress, _loginConfig.Port);
            while (true)
            {
                var handler = await listener.AcceptAsync();
                var packet = GetPacket(handler);
                switch (packet[0])
                {
                    case LoginRequest.HeaderByte:
                        _requestHandlers[typeof(LoginRequest)].Handle(packet);
                        break;
                    case MapDataRequest.HeaderByte:
                        _requestHandlers[typeof(MapDataRequest)].Handle(packet);
                        break;
                    default:
                        Log.Warning("Unknown packet");
                        break;
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }

        private byte[] GetPacket(Socket handler)
        {
            var data = new List<byte>();
            var buffer = new byte[1024];
            while (true)
            {
                var bytesRec = handler.Receive(buffer);
                data.AddRange(buffer.Take(bytesRec));
                if (data.Skip(data.Count - 2).All(b => b == 0))
                    break;
            }
            return data.ToArray();
        }
    }
}
