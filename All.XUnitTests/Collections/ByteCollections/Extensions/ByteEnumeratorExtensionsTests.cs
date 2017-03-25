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
    }
}
