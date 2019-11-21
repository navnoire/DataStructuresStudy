using System;
using DataStructures.LIB.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void EasyHashTableAddTest()
        {
            var table = new EasyHashTable<int>(10);

            table.Add(15);
            table.Add(1);
            table.Add(234);

            Assert.AreEqual("0 1 15 234 0 0 0 0 0 0", table.ToString());
        }

        [TestMethod]
        public void EasyHashTableSearchTest()
        {
            var table = new EasyHashTable<int>(10);

            table.Add(15);
            table.Add(1);
            table.Add(234);

            Assert.IsTrue(table.Search(15));
            Assert.IsFalse(table.Search(14));
        }
    }
}
