using System.Net;
using System.Net.Sockets;

namespace OpenMMO.Server.Utils
{
    public class SocketHelper
    {
        public Socket CreateListener(string ipAddressStr, int port)
        {
            var ipAddress = IPAddress.Parse(ipAddressStr);
            var ipEndPoint = new IPEndPoint(ipAddress, port);
            var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipEndPoint);
            listener.Listen(100);
            return listener;
        }
    }
}
