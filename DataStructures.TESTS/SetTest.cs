using System;
using DataStructures_LIB.Set;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void EasySetAddTest()
        {
            var set = new EasySet<int>();

            set.Add(1);
            set.Add(2);

            Assert.AreEqual("1 2 ", set.ToString());

            set.Add(2);
            Assert.AreEqual("1 2 ", set.ToString());
        }

        [TestMethod]
        public void EasySetRemoveTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });

            set.Remove(2);
            set.Remove(4);

            Assert.AreEqual("1 3 5 ", set.ToString());
        }

        [TestMethod]
        public void EasySetUnionTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new EasySet<int>(new int[] { 4, 5, 6, 7, 8 });

            var result = set.Union(set2);

            Assert.AreEqual("1 2 3 4 5 6 7 8 ", result.ToString());

        }

        [TestMethod]
        public void EasySetIntersectTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new EasySet<int>(new int[] { 4, 5, 6, 7, 8 });

            var result = set.Intersect(set2);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("4 5 ", result.ToString());

            result = set2.Intersect(set);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("4 5 ", result.ToString());
        }

        [TestMethod]
        public void EasySetDifferenceTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new EasySet<int>(new int[] { 4, 5, 6, 7, 8 });

            var result = set.Difference(set2);

            Assert.AreEqual("1 2 3 ", result.ToString());

            result = set2.Difference(set);

            Assert.AreEqual("6 7 8 ", result.ToString());
        }

        [TestMethod]
        public void EasySetSymmetricDifferenceTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new EasySet<int>(new int[] { 4, 5, 6, 7, 8 });

            var result = set.SymmetricDifference(set2);

            Assert.AreEqual("1 2 3 6 7 8 ", result.ToString());
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void EasySetSubsetTest()
        {
            var set = new EasySet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new EasySet<int>(new int[] { 4, 5, 6, 7, 8 });
            var set3 = new EasySet<int>(new int[] { 1, 3, 2 });

            Assert.IsFalse(set.IsSubset(set3));
            Assert.IsFalse(set3.IsSubset(set2));
            Assert.IsTrue(set3.IsSubset(set));
        }
    }
}
