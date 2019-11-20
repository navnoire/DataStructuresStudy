using System;
using DataStructures_LIB.Deque;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class DequeTest
    {
        [TestMethod]
        public void EasyDequeTest()
        {
            var deQ = new EasyDeque<int>();
            deQ.AddToHead(1);
            deQ.AddToTail(2);
            deQ.AddToHead(3);
            deQ.AddToTail(4);

            Assert.AreEqual(3, deQ.GetFromHead());
            Assert.AreEqual(4, deQ.GetFromTail());

            deQ.GetFromTail();
            deQ.GetFromTail();
            Assert.ThrowsException<InvalidOperationException>(() => deQ.GetFromHead());

        }

        [TestMethod]
        public void DoublyLinkedDequeTest()
        {
            var deQ = new DoublyLinkedDeque<int>();
            deQ.PushToHead(1);
            deQ.PushToTail(2);
            deQ.PushToHead(3);
            deQ.PushToTail(4);

            Assert.AreEqual(3, deQ.PopFromHead());
            Assert.AreEqual(4, deQ.PopFromTail());

            deQ.PopFromHead();
            deQ.PopFromHead();
            Assert.ThrowsException<InvalidOperationException>(() => deQ.PopFromHead());
        }
    }
}
