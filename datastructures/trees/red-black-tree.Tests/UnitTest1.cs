using System;
using Xunit;
using AHeil.AlgDat.RedBlackTree;

namespace red_black_tree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void RootTest()
        {
            var node = new Node();

            Assert.True(node.isRoot());
        }

        [Fact]
        public void RootKeyTest()
        {
            var key = "42";
            var node = new Node(key);

            Assert.True(node.isRoot());
            //Assert.Equal(node.Key, key);
        }
    }
}