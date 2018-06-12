using System.Collections.Generic;

namespace OpenMMO.Shared.Extentions
{
    public static class ByteArrayExtentions
    {
        public static IEnumerable<byte[]> Split(this IEnumerable<byte> bytes, byte seperator)
        {
            var section = new List<byte>();
            foreach (var b in bytes)
            {
                if (b != seperator)
                {
                    section.Add(b);
                    continue;
                }
                yield return section.ToArray();
                section = new List<byte>();
            }
        }
    }
}
