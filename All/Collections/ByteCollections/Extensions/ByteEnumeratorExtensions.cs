using All.Collections.Extensions;
using System;
using System.Collections.Generic;

namespace All.Collections.ByteCollections.Extensions
{
    public static class ByteEnumeratorExtensions
    {
        public static int GetInt32(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[4];
            enumerator.ToArray(bytes, 0, bytes.Length);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static Int64 GetInt64(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[8];
            enumerator.ToArray(bytes, 0, bytes.Length);
            return BitConverter.ToInt64(bytes, 0);
        }

        public static char GetCharUtf16(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[2];
            enumerator.ToArray(bytes, 0, bytes.Length);
            return BitConverter.ToChar(bytes, 0);
        }
    }
}
