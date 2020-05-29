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

            Assert.True(node.IsRoot());
        }

        [Fact]
        public void RootKeyTest()
        {
            var key = "26";
            var node = new Node(key);

            Assert.True(node.IsRoot());
            Assert.Equal(node.Key, key);
        }

        [Fact]
        public void SmallerChildTest()
        {
            var root = new Node("26");

            var childNode = new Node("18");

            root.Add(childNode);

            Assert.True(childNode.IsLeaf());

        }

        [Fact]
        public void GreaterChildTest()
        {
            var root = new Node("26");

            var childNode = new Node("43");

            root.Add(childNode);

            Assert.True(childNode.IsLeaf());
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

            Assert.True(n3.IsLeaf());
            Assert.False(n2.IsLeaf());
            Assert.True(n1.IsLeaf());
        }

        [Fact]
        public void Colorize1Test()
        {
            // 35 --> 9 --> 50
            //       35: black
            //       /     \
            //  9: red     50:rot

            var root = new Node(35);
            var n1 = new Node(9);
            var n2 = new Node(50);

            root.Add(n1);
            root.Add(n2);

            Assert.True(root.IsBlack);
            Assert.False(n1.IsBlack);
            Assert.False(n2.IsBlack);

        }

        [Fact]
        public void GrandParentTest()
        {
            var root = new Node(35);
            var n1 = new Node(9);
            var n2 = new Node(3);

            root.Add(n1);
            root.Add(n2);

            Assert.Equal(n2.GrandParent, root);
        }

        [Fact]
        public void UncleTest()
        {
            var root = new Node(35);
            var n1 = new Node(9);
            var n2 = new Node(42);
            var n3 = new Node(5);

            root.Add(n1);
            root.Add(n2);
            root.Add(n3);

            Assert.Equal(n3.Uncle, n2);
        }

        // [Fact]
        // public void Colorize2Test()
        // {
        //     // 35 --> 9 --> 50
        //     //       35: black
        //     //       /     \
        //     //  9: black     50:black
        //     //                \
        //     //                 57:rot

        //     var root = new Node(35);
        //     var n1 = new Node(9);
        //     var n2 = new Node(50);
        //     var n3 = new Node(57);

        //     root.Add(n1);
        //     root.Add(n2);
        //     root.Add(n3);

        //     Assert.True(root.IsBlack);
        //     Assert.True(n1.IsBlack);
        //     Assert.True(n2.IsBlack);
        //     Assert.False(n3.IsBlack);
        // }

        // [Fact]
        // public void BlackNodesTest()
        // {
        //     // 35 --> 9 --> 50
        //     //       35: black
        //     //       /     \
        //     //  9: black     50:black
        //     //                \
        //     //                 57:rot

        //     var root = new Node(35);
        //     var n1 = new Node(9);
        //     var n2 = new Node(50);
        //     var n3 = new Node(57);

        //     root.Add(n1);
        //     root.Add(n2);
        //     root.Add(n3);

        //     Assert.True(n1.IsLeaf);
        //     Assert.True(n3.IsLeaf);

        //     Assert.Equal(n1.BlackNodes, n3.BlackNodes);
        // }
    }
}