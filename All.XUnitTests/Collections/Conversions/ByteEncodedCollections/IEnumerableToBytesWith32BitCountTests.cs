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

using All.Collections.Conversions.ByteEncodedCollections;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace All.XUnitTests.Collections.Conversions.ByteEncodedCollections
{
    public class IEnumerableToBytesWith32BitCountTests
    {
        [Fact]
        public void TestConvertToBytesWith32BitCount3Ints()
        {
            // Arrange
            var items = new[] { 1, 2, 3 };
            var to = new IEnumerableToBytesWith32BitCount<int>(item => BitConverter.GetBytes(item));

            // Act
            var bytes = to
                .ConvertToBytesWith32BitCount(items, items.Length)
                .ToArray();

            // Assert
            BitConverter.ToInt32(bytes, 0).ShouldBe(items.Length);
            BitConverter.ToInt32(bytes, 4).ShouldBe(1);
            BitConverter.ToInt32(bytes, 8).ShouldBe(2);
            BitConverter.ToInt32(bytes, 12).ShouldBe(3);
        }
    }
}
