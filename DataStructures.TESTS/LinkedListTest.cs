using System;
using DataStructures_LIB.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void AddTest()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //Assert
            Assert.AreEqual(5, list.Tail.Data);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(2);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(3, list.Head.Next.Data);

            list.Remove(72);
            Assert.AreEqual(4, list.Count);

            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        //[TestMethod]
        //public void InsertTest()
        //{

        //}
    }
}
