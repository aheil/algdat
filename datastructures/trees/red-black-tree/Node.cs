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
        private Node _left; //black if not set
        private Node _right; // black if not set
        private Node _parent;
        private Color _color;
        private IComparable _key;

        public Node Parent
        {
            get { return _parent; }
        }

        public Node GrandParent
        {
            get { return Parent.Parent; }
        }

        public Node Uncle
        {
            get { return GetUncle(); }
        }

        private Node GetUncle()
        {
            var grandparent = GrandParent;
            var left = grandparent._left;
            var right = grandparent._right;

            if (left == _parent)
            {
                return right;
            }
            else
            {
                return left;
            }
        }

        public bool IsBlack
        {
            get { return _color == Color.Black; }
        }

        public bool IsLeaf()
        {
            return (_left == null && _right == null); // && _color == Color.Black);
        }

        public IComparable Key
        {
            get { return GetKey(); }
        }

        private IComparable GetKey()
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

        public bool IsRoot()
        {
            return _parent == null && _color == Color.Black;
        }

        private int CountBlack()
        {
            if (!this.IsRoot())
            {
                var c = _parent.CountBlack();
                if (this.IsBlack)
                    return ++c;
                else
                    return c;
            }
            else
            {
                if (this.IsBlack)
                    return 1;
                else
                    return 0;
            }
        }


        public void Add(Node node)
        {
            if (this.IsRoot())
                node._color = Color.Red;

            if (node.Key.CompareTo(_key) < 0)
            {
                if (_left == null)
                {
                    _left = node;
                    _left._parent = this; // TODO: check if this is a smart idea
                    if (this.IsBlack == false && node.IsBlack == false)
                        _color = Color.Black;
                }
                else
                {
                    _left.Add(node);
                }
            }
            else if (node.Key.CompareTo(_key) > 0)
            {
                if (_right == null)
                {
                    _right = node;
                    _right._parent = this; // TODO: check if this is smart idea
                    if (this.IsBlack == false && node.IsBlack == false)
                        _color = Color.Black;
                }
                else
                {
                    _right.Add(node);
                }
            }
            else if (node.Key.CompareTo(_key) == 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}