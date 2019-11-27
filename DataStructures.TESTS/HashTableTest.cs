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

            Assert.IsTrue(table.Contains(15));
            Assert.IsFalse(table.Contains(14));

        }

        [TestMethod]
        public void SuperHashTableAddTest()
        {
            var table = new SuperHashTable<TestPerson>(10);
            var person = new TestPerson("Andrew", 12, 0);
            var person2 = new TestPerson("Alice", 45, 1);

            table.Add(person);

            Assert.IsTrue(table.Contains(person));
            Assert.IsFalse(table.Contains(person2));
        }

        [TestMethod]
        public void SuperHashTableGetDataTest()
        {
            var table = new SuperHashTable<TestPerson>(10);
            var person1 = new TestPerson("Andrew", 12, 0);
            var person2 = new TestPerson("Alice", 45, 1);
            var person3 = new TestPerson("Barbara", 45, 1);
            var person4 = new TestPerson("Colin", 25, 0);

            table.Add(person1);
            table.Add(person2);
            table.Add(person3);
            table.Add(person4);

            Assert.AreEqual(2, table.GetData((int)'A').Count);
            Assert.AreEqual(25, table.GetData((int)'C')[0].Age);
        }
    }
}
