using OpenMMO.Shared.Utils;
using System;

namespace OpenMMO.Shared.Requests
{
    public class MapDataRequest
    {
        public const byte HeaderByte = 0x02;

        public static MapDataRequest FromPacket(byte[] packet)
        {
            throw new NotImplementedException();
        }

        public byte[] ToPacket()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToStringHelper.ToString(this);
        }
    }
}