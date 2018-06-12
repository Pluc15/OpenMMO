using OpenMMO.Shared.Utils;
using System;

namespace OpenMMO.Shared.Responses
{
    public class MapDataResponse
    {
        public const byte HeaderByte = 0x02;

        public static MapDataResponse FromPacket(byte[] packet)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToStringHelper.ToString(this);
        }
    }
}