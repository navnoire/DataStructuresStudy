using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;

namespace DataStructures.LIB.BinarySearchTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        // нужны нормальные проверки, не должно быть прямого доступа на запись в левый-правый
        private T _nodeData;
        public T NodeData
        {
            get => _nodeData;
            private set
            {
                _nodeData = value;
            }
        }

        public BinaryTreeNode<T> Left { get; private set; }
        public BinaryTreeNode<T> Right { get; private set; }

        public BinaryTreeNode(T data)
        {
            NodeData = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            NodeData = data;
            Left = left;
            Right = right;
        }

        public void Add(T data)
        {
            var node = new BinaryTreeNode<T>(data);
            if (node.NodeData.CompareTo(NodeData) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public override string ToString()
        {
            return NodeData.ToString();
        }
    }
}
