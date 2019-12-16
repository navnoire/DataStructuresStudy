using System;
using System.Text;
using DataStructures.LIB.BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreePreorderTest()
        {
            //Arrange
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);
            tree.Add(4);
            tree.Add(8);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);

            // Act
            var preorder = new StringBuilder();
            foreach (var item in tree.Preorder_CLR())
            {
                preorder.Append(item + " ");
            }

            //Assert
            Assert.AreEqual("5 3 1 2 4 8 7 6 9 ", preorder.ToString());
        }

        [TestMethod]
        public void BinaryTreePostorderTest()
        {
            //Arrange
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);
            tree.Add(4);
            tree.Add(8);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);

            // Act
            var postorder = new StringBuilder();
            foreach (var item in tree.Postorder_LRC())
            {
                postorder.Append(item + " ");
            }

            //Assert
            Assert.AreEqual("2 1 4 3 6 7 9 8 5 ", postorder.ToString());
        }

        [TestMethod]
        public void BinaryTreeInorderTest()
        {
            //Arrange
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);
            tree.Add(4);
            tree.Add(8);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);

            // Act
            var inorder = new StringBuilder();
            foreach (var item in tree.Inorder_LCR())
            {
                inorder.Append(item + " ");
            }

            //Assert
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 ", inorder.ToString());
        }

        [TestMethod]
        public void BinaryTreeLevelorderTest()
        {
            //Arrange
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(1);
            tree.Add(2);
            tree.Add(4);
            tree.Add(8);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);

            // Act
            var levelorder = new StringBuilder();
            foreach (var item in tree.LevelOrder_BFS())
            {
                levelorder.Append(item + " ");
            }

            //Assert
            Assert.AreEqual("5 3 8 1 4 7 9 2 6 ", levelorder.ToString());
        }
    }
}
