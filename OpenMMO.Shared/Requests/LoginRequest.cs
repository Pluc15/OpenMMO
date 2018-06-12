using OpenMMO.Shared.Exceptions;
using OpenMMO.Shared.Extentions;
using OpenMMO.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMMO.Shared.Requests
{
    public class LoginRequest
    {
        public const byte HeaderByte = 0x01;
        public string Username { get; set; }
        public string Password { get; set; }

        public static LoginRequest FromPacket(byte[] packet)
        {
            var parts = packet.Split(0).ToArray();
            if (parts.First().Equals(new[] { HeaderByte }) || parts.Count() != 4)
                throw new InvalidPacketException(packet.ToArray(), typeof(LoginRequest));
            return new LoginRequest
            {
                Username = Encoding.ASCII.GetString(parts[1].ToArray()),
                Password = Encoding.ASCII.GetString(parts[2].ToArray())
            };
        }

        public byte[] ToPacket()
        {
            var packet = new List<byte>();
            packet.Add(HeaderByte);
            packet.Add(0);
            packet.AddRange(Encoding.ASCII.GetBytes(Username));
            packet.Add(0);
            packet.AddRange(Encoding.ASCII.GetBytes(Password));
            packet.Add(0);
            packet.Add(0);
            return packet.ToArray();
        }

        public override string ToString()
        {
            return ToStringHelper.ToString(this);
        }
    }
}
