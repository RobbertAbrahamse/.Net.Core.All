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
using All.Collections.Conversions.ByteEncodedCollections;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace All.XUnitTests.Collections.Conversions.ByteEncodedCollections
{
    public class BytesWith32BitCountToIEnumerableTests
    {
        [Fact]
        public void TestConvertToIEnumerable3Bytes()
        {
            var items = new byte[] { 1, 2, 3 };
            Test(e => e.GetByte(), items, items, 0);
        }

        [Fact]
        public void TestConvertToIEnumerable3Ints()
        {
            var items = new[] { 1, 2, 3 };
            Test(e => e.GetInt32(), items.SelectMany(item => BitConverter.GetBytes(item)), items, 0);
        }

        [Fact]
        public void TestConvertToIEnumerable3IntsAnd3UnusedBytes()
        {
            var items = new[] { 1, 2, 3 };
            Test(e => e.GetInt32(), items.SelectMany(item => BitConverter.GetBytes(item)).Concat(new byte[] { 10, 11, 12 }), items, 3);
        }

        private static void Test<T>(Func<IEnumerator<byte>, T> getItemFromBytesFunc, IEnumerable<byte> itemBytes, T[] shouldBeItems, int shouldBeBytesLeftCount)
        {
            // Arrange
            var bytes = BitConverter.GetBytes(shouldBeItems.Length).Concat(itemBytes);
            var to = new BytesWith32BitCountToIEnumerable<T>(e => getItemFromBytesFunc(e));
            var enumerator = bytes.GetEnumerator();
            enumerator.MoveNext();

            // Act
            var items = to.ConvertToIEnumerable(enumerator).ToList();

            // Assert
            items.SequenceEqual(shouldBeItems).ShouldBe(true);
            for (var i = 0; i < shouldBeBytesLeftCount - 1; i++)
            {
                enumerator.MoveNext().ShouldBe(true);
            }
            enumerator.MoveNext().ShouldBeFalse();
        }
    }
}
