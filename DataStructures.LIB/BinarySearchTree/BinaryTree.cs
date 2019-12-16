using System;
using System.Collections.Generic;

namespace DataStructures.LIB.BinarySearchTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            var node = new BinaryTreeNode<T>(data);

            if (Root == null)
            {
                Root = node;
                Count++;
                return;
            }
            Root.Add(data);
            Count++;
        }

        public IEnumerable<T> Preorder_CLR()
        {
            return Preorder_CLR(Root);
        }

        public IEnumerable<T> Postorder_LRC()
        {
            return Postorder_LRC(Root);
        }

        public IEnumerable<T> Inorder_LCR()
        {
            return Inorder_LCR(Root);
        }

        // breadth-first search, BFS
        public IEnumerable<T> LevelOrder_BFS()
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            var list = new List<T>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                list.Add(node.NodeData);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return list;
        }

        private IEnumerable<T> Preorder_CLR(BinaryTreeNode<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.NodeData);
                list.AddRange(Preorder_CLR(node.Left));
                list.AddRange(Preorder_CLR(node.Right));
            }

            return list;
        }

        private IEnumerable<T> Postorder_LRC(BinaryTreeNode<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.AddRange(Postorder_LRC(node.Left));
                list.AddRange(Postorder_LRC(node.Right));
                list.Add(node.NodeData);
            }

            return list;
        }

        private IEnumerable<T> Inorder_LCR(BinaryTreeNode<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.AddRange(Inorder_LCR(node.Left));
                list.Add(node.NodeData);
                list.AddRange(Inorder_LCR(node.Right));
            }

            return list;
        }

        //TODO: изучить самостоятельно удаление узла из бинарного дерева.
    }
}
