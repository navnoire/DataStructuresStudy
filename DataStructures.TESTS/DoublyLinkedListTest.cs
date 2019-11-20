using System;
using DataStructures.LIB.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            var doublyList = new DoublyLinkedList<int>();

            //Act
            doublyList.Add(11);
            doublyList.Add(12);

            //Assert
            Assert.AreEqual(2, doublyList.Count);
            Assert.AreEqual(11, doublyList.Head.Data);
            Assert.AreEqual(12, doublyList.Tail.Data);

        }

        [TestMethod]
        public void RemoveTest()
        {
            //Arrange
            var doublyList = new DoublyLinkedList<int>();
            doublyList.Add(11);
            doublyList.Add(12);
            doublyList.Add(13);
            doublyList.Add(14);

            //Act
            doublyList.Remove(14);
            doublyList.Remove(11);

            //Assert
            Assert.AreEqual(13, doublyList.Tail.Data);
            Assert.AreEqual(2, doublyList.Count);
            Assert.AreEqual(12, doublyList.Head.Data);
            Assert.AreEqual(null, doublyList.Head.PrevCell);
        }

        [TestMethod]
        public void ReverseTest()
        {
            //Arrange
            var doublyList = new DoublyLinkedList<int>();
            doublyList.Add(11);
            doublyList.Add(12);
            doublyList.Add(13);
            doublyList.Add(14);

            //Act
            var doublyList2 = doublyList.Reverse();

            //Assert
            Assert.AreEqual(doublyList.Count, doublyList2.Count);
            Assert.AreEqual(doublyList.Head.Data, doublyList2.Tail.Data);

        }

        [TestMethod]
        public void CloneTest()
        {
            //Arrange
            var list = new DoublyLinkedList<int>();
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);

            //Act
            var list2 = list.Clone();
            list.Add(18);

            //Assert
            Assert.AreNotEqual(list.Count, list2.Count);
            Assert.AreEqual(list.Head.Data, list2.Head.Data);
            Assert.AreNotEqual(list.Head, list2.Head);

        }
    }
}
