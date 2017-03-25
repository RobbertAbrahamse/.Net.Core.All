using All.Collections.Arrays.Extensions;
using All.Collections.ByteCollections.Extensions;
using Shouldly;
using System;
using Xunit;

namespace All.XUnitTests.Collections.ByteCollections.Extensions
{
    public class ByteEnumeratorExtensionsTests
    {
        [Fact]
        public void TestGetInt32MaxValue()
        {
            var bytes = BitConverter.GetBytes(int.MaxValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetInt32().ShouldBe(int.MaxValue);
        }

        [Fact]
        public void TestGetInt32MinValue()
        {
            var bytes = BitConverter.GetBytes(int.MinValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetInt32().ShouldBe(int.MinValue);
        }

        [Fact]
        public void TestGetInt64MaxValue()
        {
            var bytes = BitConverter.GetBytes(Int64.MaxValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetInt64().ShouldBe(Int64.MaxValue);
        }

        [Fact]
        public void TestGetInt64MinValue()
        {
            var bytes = BitConverter.GetBytes(Int64.MinValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetInt64().ShouldBe(Int64.MinValue);
        }

        [Fact]
        public void TestGetCharUtf16MaxValue()
        {
            var bytes = BitConverter.GetBytes(char.MaxValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetCharUtf16().ShouldBe(char.MaxValue);
        }

        [Fact]
        public void TestGetCharUtf16MinValue()
        {
            var bytes = BitConverter.GetBytes(char.MinValue);
            var e = bytes.GetEnumerator<byte>();
            e.MoveNext().ShouldBe(true);
            e.GetCharUtf16().ShouldBe(char.MinValue);
        }
    }
}
