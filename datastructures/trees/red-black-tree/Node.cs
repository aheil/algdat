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
        private IComparable _key;

        public bool IsLeaf
        {
            get { return isLeaf(); }
        }

        private bool isLeaf()
        {
            return (_left == null && _right == null && _color == Color.Black);
        }

        public IComparable Key
        {
            get { return getKey(); }
        }

        private IComparable getKey()
        {
            return _key;
        }

        public Node()
        {
            _color = Color.Black;
        }

        public Node(IComparable key) : this()
        {
            _key = key;
        }

        public bool isRoot()
        {
            return _parent == null && _color == Color.Black;
        }

        public void Add(Node node)
        {
            if (this.isRoot())
                node._color = Color.Red;

            if (node.Key.CompareTo(_key) < 0)
            {
                if (_left == null)
                {
                    _left = node;
                    node._color = Color.Black;
                }
                else
                    _left.Add(node);
            }
            else if (node.Key.CompareTo(_key) > 0)
            {
                if (_right == null)
                {
                    _right = node;
                    node._color = Color.Black;
                }
                else
                    _right.Add(node);
            }
            else if (node.Key.CompareTo(_key) == 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}