using OpenMMO.Shared.Requests;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace OpenMMO.Client.Core.Clients
{
    public class LoginClient
    {
        private readonly int _port;

        public LoginClient(int port)
        {
            _port = port;
        }

        public async Task LoginAsync(LoginRequest loginPayload)
        {
            var packet = loginPayload.ToPacket().ToArray();
            using (var client = new TcpClient(IPAddress.Loopback.ToString(), _port))
            using (var stream = client.GetStream())
            {
                await stream.WriteAsync(packet, 0, packet.Length);
                stream.Close();
                client.Close();
            }
        }
    }
}
