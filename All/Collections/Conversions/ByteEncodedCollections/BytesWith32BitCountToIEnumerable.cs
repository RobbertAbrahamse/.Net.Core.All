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

using All.Collections.ByteCollections.Extensions;
using System;
using System.Collections.Generic;

namespace All.Collections.Conversions.ByteEncodedCollections
{
    /// <summary>
    /// Conversion from bytes that has a 32 bit prefix that is the count of the items followed by the bytes of the items
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection</typeparam>
    public class BytesWith32BitCountToIEnumerable<T>
    {
        public delegate T GetItemFromBytesDelegate(IEnumerator<byte> itemBytes);

        public BytesWith32BitCountToIEnumerable()
        {
        }

        public BytesWith32BitCountToIEnumerable(GetItemFromBytesDelegate getItemFromBytesFunc)
        {
            GetItemFromBytesFunc = getItemFromBytesFunc;
        }

        /// <summary>
        /// A func that will get the bytes from the enumerator to build the next item in the collection
        /// </summary>
        public GetItemFromBytesDelegate GetItemFromBytesFunc { get; set; }

        public IEnumerable<T> ConvertToIEnumerable(IEnumerable<byte> bytesWith32BitCount)
        {
            var enumeratorBytesWith32BitCount = bytesWith32BitCount.GetEnumerator();
            return enumeratorBytesWith32BitCount.MoveNext()
                ? ConvertToIEnumerable(enumeratorBytesWith32BitCount)
                : new T[0];
        }

        public IEnumerable<T> ConvertToIEnumerable(IEnumerator<byte> enumeratorBytesWith32BitCount)
        {
            // get the count
            int itemCount;
            try
            {
                itemCount = enumeratorBytesWith32BitCount.GetInt32();
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to get the 32 bit collection item count.", exception);
            }

            // get the items
            for (var i = 0; i < itemCount; i++)
            {
                T item;
                try
                {
                    item = GetItemFromBytesFunc(enumeratorBytesWith32BitCount);
                }
                catch (Exception exception)
                {
                    throw new Exception($"Could not convert item {i} due to an conversion exception.", exception);
                }

                yield return item;
            }
        }
    }
}
