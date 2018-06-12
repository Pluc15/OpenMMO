using OpenMMO.Shared.Requests;
using OpenMMO.Shared.Responses;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace OpenMMO.Client.Core.Clients
{
    public class MapClient
    {
        private readonly int _port;

        public MapClient(int port)
        {
            _port = port;
        }

        public async Task<MapDataResponse> GetMapDataAsync(MapDataRequest mapDataRequest)
        {
            var packet = mapDataRequest.ToPacket();
            using (var client = new TcpClient(IPAddress.Loopback.ToString(), _port))
            using (var stream = client.GetStream())
            {
                await stream.WriteAsync(packet, 0, packet.Length);
                client.
                stream.Close();
                client.Close();
            }
        }
    }
}
