using System;
using DataStructures_LIB.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class CircularListTest
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            var list = new CircularLinkedList<int>();

            //Act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(2, list.Head.NextCell.Data);
            Assert.AreEqual(3, list.Head.PrevCell.Data);
        }

        [TestMethod]
        public void RemoveTest()
        {
            //Arrange
            var list = new CircularLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //Act
            list.Remove(2);

            //Assert
            Assert.AreEqual("1 3 4 5 ", list.ToString());
            list.Remove(1);
            Assert.AreEqual("3 4 5 ", list.ToString());
        }
    }
}
