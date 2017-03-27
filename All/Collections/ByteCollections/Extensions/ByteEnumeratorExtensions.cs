// Copyright 2017 Robbert Abrahamse
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using All.Collections.Copying;
using System;
using System.Collections.Generic;

namespace All.Collections.ByteCollections.Extensions
{
    public static class ByteEnumeratorExtensions
    {
        public static int GetInt32(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[4];
            enumerator.CopyTo(bytes, 0, bytes.Length);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static Int64 GetInt64(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[8];
            enumerator.CopyTo(bytes, 0, bytes.Length);
            return BitConverter.ToInt64(bytes, 0);
        }

        public static char GetCharUtf16(this IEnumerator<byte> enumerator)
        {
            var bytes = new byte[2];
            enumerator.CopyTo(bytes, 0, bytes.Length);
            return BitConverter.ToChar(bytes, 0);
        }

        public static byte GetByte(this IEnumerator<byte> enumerator)
        {
            var b = enumerator.Current;
            enumerator.MoveNext();
            return b;
        }
    }
}
