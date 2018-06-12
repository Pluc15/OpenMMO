using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using OpenMMO.Server.Configurations;
using OpenMMO.Server.Utils;
using OpenMMO.Shared.Requests;
using Serilog;

namespace OpenMMO.Server.Listeners
{
    public class MapListener
    {
        private readonly MapConfiguration _mapConfig;
        private readonly SocketHelper _socketHelper;

        public MapListener(MapConfiguration mapConfig, SocketHelper socketHelper)
        {
            _mapConfig = mapConfig;
            _socketHelper = socketHelper;
        }

        public async Task StartAsync()
        {
            LogInfo($"Starting on {_mapConfig.IpAddress}:{_mapConfig.Port}");
            var listener = _socketHelper.CreateListener(_mapConfig.IpAddress, _mapConfig.Port);
            while (true)
            {
                var handler = await listener.AcceptAsync();
                HandleMapRequest(handler);
            }
        }

        private void HandleMapRequest(Socket handler)
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
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        private void LogInfo(string msg)
        {
            Log.Information($"[{nameof(MapListener)}] {msg}");
        }

        private void LogWarn(string msg)
        {
            Log.Warning($"[{nameof(MapListener)}] {msg}");
        }
    }
}
