using OpenMMO.Shared.Utils;
using System;

namespace OpenMMO.Shared.Responses
{
    public class LoginResponse
    {
        public const byte HeaderByte = 0x01;

        public bool Success { get; set; }

        public static LoginResponse FromPacket(byte[] packet)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToStringHelper.ToString(this);
        }
    }
}
