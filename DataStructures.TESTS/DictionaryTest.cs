using System;
using DataStructures.LIB.MapDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void EasyDictionaryAddTest()
        {
            var dictionary = new EasyDictionary<int, string>();

            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(2, "Two"));
            dictionary.Add(new Item<int, string>(3, "Three"));
            dictionary.Add(new Item<int, string>(4, "Four"));
            dictionary.Add(new Item<int, string>(5, "Five"));

            Assert.AreEqual("Four", dictionary.GetValue(4));
        }

        [TestMethod]
        public void EasyDictionaryRemoveTest()
        {
            var dictionary = new EasyDictionary<int, string>();

            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(2, "Two"));
            dictionary.Add(new Item<int, string>(3, "Three"));
            dictionary.Add(new Item<int, string>(4, "Four"));
            dictionary.Add(new Item<int, string>(5, "Five"));

            Assert.AreEqual("Two", dictionary.GetValue(2));
            dictionary.Remove(2);
            Assert.IsNull(dictionary.GetValue(2));


        }

        [TestMethod]
        public void DictionaryAddTest()
        {
            var dictionary = new Dictionary<int, string>();

            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(2, "Two"));
            dictionary.Add(new Item<int, string>(3, "Three"));
            dictionary.Add(new Item<int, string>(4, "Four"));
            dictionary.Add(new Item<int, string>(5, "Five"));

            Assert.AreEqual("Four", dictionary.GetValue(4));
        }

        [TestMethod]
        public void DictionaryRemoveTest()
        {
            var dictionary = new Dictionary<int, string>();

            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(2, "Two"));
            dictionary.Add(new Item<int, string>(3, "Three"));
            dictionary.Add(new Item<int, string>(4, "Four"));
            dictionary.Add(new Item<int, string>(5, "Five"));

            Assert.AreEqual("Two", dictionary.GetValue(2));
            dictionary.Remove(2);
            Assert.IsNull(dictionary.GetValue(2));
        }

        [TestMethod]
        public void DictionaryCollisionTest()
        {
            var dictionary = new Dictionary<int, string>();

            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(1, "One"));
            dictionary.Add(new Item<int, string>(2, "Two"));
            dictionary.Add(new Item<int, string>(3, "Three"));
            dictionary.Add(new Item<int, string>(4, "Four"));
            dictionary.Add(new Item<int, string>(5, "Five"));
            dictionary.Add(new Item<int, string>(101, "One-O-One"));

            Assert.AreNotEqual(dictionary.GetValue(1), dictionary.GetValue(101));
        }
    }
}
