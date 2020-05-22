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
            var key = "26";
            var node = new Node(key);

            Assert.True(node.isRoot());
            Assert.Equal(node.Key, key);
        }

        [Fact]
        public void SmallerLeafTest()
        {
            var root = new Node("26");

            var childNode = new Node("18");

            root.Add(childNode);

            Assert.True(childNode.IsLeaf);

        }

        [Fact]
        public void GreaterLeafTest()
        {
            var root = new Node("26");

            var childNode = new Node("43");

            root.Add(childNode);

            Assert.True(childNode.IsLeaf);
        }

        [Fact]
        public void Insert4Test()
        {
            // 26 -> 43 -> 18 -> 52
            var root = new Node("26");
            var n1 = new Node("18");
            var n2 = new Node("43");
            var n3 = new Node("52");

            root.Add(n1);
            root.Add(n2);
            root.Add(n3);

            Assert.True(n3.IsLeaf);
            Assert.False(n2.IsLeaf);
            Assert.True(n1.IsLeaf);
        }
    }
}