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

using All.Collections.Arrays.Extensions;
using All.Collections.ByteCollections.Extensions;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace All.XUnitTests.Collections.ByteCollections.Extensions
{
    public class ByteEnumeratorExtensionsTests
    {
        [Fact]
        public void TestGetInt32MaxValue() => Test(ByteEnumeratorExtensions.GetInt32, BitConverter.GetBytes(int.MaxValue).GetEnumerator<byte>(), int.MaxValue);

        [Fact]
        public void TestGetInt32MinValue() => Test(ByteEnumeratorExtensions.GetInt32, BitConverter.GetBytes(int.MinValue).GetEnumerator<byte>(), int.MinValue);

        [Fact]
        public void TestGetInt64MaxValue() => Test(ByteEnumeratorExtensions.GetInt64, BitConverter.GetBytes(Int64.MaxValue).GetEnumerator<byte>(), Int64.MaxValue);

        [Fact]
        public void TestGetInt64MinValue() => Test(ByteEnumeratorExtensions.GetInt64, BitConverter.GetBytes(Int64.MinValue).GetEnumerator<byte>(), Int64.MinValue);

        [Fact]
        public void TestGetCharUtf16MaxValue() => Test(ByteEnumeratorExtensions.GetCharUtf16, BitConverter.GetBytes(char.MaxValue).GetEnumerator<byte>(), char.MaxValue);

        [Fact]
        public void TestGetCharUtf16MinValue() => Test(ByteEnumeratorExtensions.GetCharUtf16, BitConverter.GetBytes(char.MinValue).GetEnumerator<byte>(), char.MinValue);

        private static void Test<T>(Func<IEnumerator<byte>, T> funcToTest, IEnumerator<byte> bytesEnumerator, T shouldBe)
        {
            // Arrange
            bytesEnumerator.MoveNext().ShouldBe(true);

            // Act
            var funcValue = funcToTest(bytesEnumerator);

            // Assert
            funcValue.ShouldBe(shouldBe);
        }

    }
}
