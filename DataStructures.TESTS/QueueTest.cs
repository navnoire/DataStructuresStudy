using System;
using DataStructures_LIB.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void EasyQueueTest()
        {
            var queue = new EasyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(3, queue.Count);

            var result = queue.Dequeue();

            Assert.AreEqual(1, result);
            Assert.AreEqual(2, queue.Count);

            result = queue.Peek();
            Assert.AreEqual(2, result);

            queue.Dequeue();
            queue.Dequeue();
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

        }

        [TestMethod]
        public void ArrayQueueTest()
        {
            var queue = new ArrayQueue<int>(5);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Peek());

            queue.Enqueue(11);

            Assert.ThrowsException<OverflowException>(() => queue.Enqueue(12));

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void LinkedQueueTest()
        {
            var linkedQ = new LinkedQueue<int>();
            linkedQ.Enqueue(1);
            linkedQ.Enqueue(2);
            linkedQ.Enqueue(3);
            linkedQ.Enqueue(4);
            linkedQ.Enqueue(5);

            Assert.AreEqual(5, linkedQ.Count);
            Assert.AreEqual(1, linkedQ.Dequeue());
            Assert.AreNotEqual(1, linkedQ.Dequeue());

            linkedQ.Dequeue();
            linkedQ.Dequeue();
            Assert.AreEqual(5, linkedQ.Dequeue());
            Assert.ThrowsException<InvalidOperationException>(() => linkedQ.Dequeue());
        }
    }
}
