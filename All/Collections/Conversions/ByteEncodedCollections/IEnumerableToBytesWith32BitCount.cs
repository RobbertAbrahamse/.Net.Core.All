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

using System;
using System.Collections.Generic;

namespace All.Collections.Conversions.ByteEncodedCollections
{
    public class IEnumerableToBytesWith32BitCount<T>
    {
        public delegate IEnumerable<byte> ConvertItemToBytesDelegate(T item);

        public IEnumerableToBytesWith32BitCount()
        {
        }

        public IEnumerableToBytesWith32BitCount(ConvertItemToBytesDelegate convertItemToBytesFunc)
        {
            ConvertItemToBytesFunc = convertItemToBytesFunc;
        }

        public ConvertItemToBytesDelegate ConvertItemToBytesFunc { get; set; }

        public IEnumerable<byte> ConvertToBytesWith32BitCount(IEnumerable<T> items, int count)
        {
            // put the count into the bytes
            var countBytes = BitConverter.GetBytes(count);
            foreach (var countByte in countBytes)
            {
                yield return countByte;
            }

            // convert the items into bytes
            foreach (var item in items)
            {
                IEnumerable<byte> itemBytes;
                try
                {
                    itemBytes = ConvertItemToBytesFunc(item);
                }
                catch (Exception exception)
                {
                    throw new Exception($"Unable to convert the item {item} to bytes.", exception);
                }

                foreach (var itemByte in itemBytes)
                {
                    yield return itemByte;
                }
            }
        }
    }
}
