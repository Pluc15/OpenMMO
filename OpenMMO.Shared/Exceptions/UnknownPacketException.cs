using System;
using System.Runtime.Serialization;

namespace OpenMMO.Shared.Exceptions
{
    [Serializable]
    public class UnknownPacketException : Exception
    {
        private byte[] packet;

        public UnknownPacketException()
        {
        }

        public UnknownPacketException(byte[] packet)
        {
            this.packet = packet;
        }

        public UnknownPacketException(string message) : base(message)
        {
        }

        public UnknownPacketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownPacketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}