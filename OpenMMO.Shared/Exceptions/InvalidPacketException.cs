using System;

namespace OpenMMO.Shared.Exceptions
{
    public class InvalidPacketException : Exception
    {
        public InvalidPacketException(byte[] packet, Type type)
            : base("Invalid packet")
        {
            Packet = packet;
            Type = type;
        }

        public byte[] Packet { get; }
        public Type Type { get; }
    }
}