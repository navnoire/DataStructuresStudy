using System;
using DataStructures.LIB.BinaryHeap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class BinaryHeapTest
    {
        [TestMethod]
        public void BinaryHeapAddTest()
        {
            var heap = new MaxHeap<int>();

            heap.Add(12);
            heap.Add(6);
            heap.Add(18);
            heap.Add(4);
            heap.Add(27);
            heap.Add(14);
            heap.Add(56);
            heap.Add(1);
            heap.Add(2);
            heap.Add(102);


            Assert.AreEqual(102, heap.PeekRoot());

        }

        [TestMethod]
        public void BinaryHeapExtractTest()
        {
            var heap = new MaxHeap<int>();

            heap.Add(12);
            heap.Add(6);
            heap.Add(18);
            heap.Add(4);
            heap.Add(27);
            heap.Add(14);
            heap.Add(56);
            heap.Add(1);
            heap.Add(2);
            heap.Add(102);

            heap.GetMax();

            Assert.AreEqual(56, heap.PeekRoot());
            Assert.AreEqual(9, heap.Count);
        }
    }
}
