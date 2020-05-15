using System;

namespace AHeil.AlgDat.RedBlackTree
{
    public enum Color
    {
        Red,
        Black
    }

    public class Node
    {
        private Node _left;
        private Node _right;
        private Node _parent;
        private Color _color;
        private object _key;

        public object Key
        {
            get { return getKey(); }
        }

        private object getKey()
        {
            return _key;
        }

        public Node()
        {
            _color = Color.Black;
        }

        public Node(object key) : this()
        {
            _key = key;
        }

        public bool isRoot()
        {
            return _parent == null && _color == Color.Black;
        }
    }
}