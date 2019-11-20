using System;
using DataStructures.LIB.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.TESTS
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void ArrayStackPushPopTest()
        {
            //Arrange
            ArrayStack<int> arrayStack = new ArrayStack<int>(5);

            //Act
            arrayStack.Push(21);
            arrayStack.Push(18);
            arrayStack.Push(79);
            arrayStack.Push(11);
            arrayStack.Push(40);

            //Assert
            Assert.ThrowsException<StackOverflowException>(() => arrayStack.Push(34));
            Assert.AreEqual(40, arrayStack.Pop());
            Assert.AreEqual(11, arrayStack.Pop());
            Assert.AreEqual(79, arrayStack.Pop());
            Assert.AreEqual(18, arrayStack.Pop());
            Assert.AreEqual(21, arrayStack.Pop());
            Assert.ThrowsException<NullReferenceException>(() => arrayStack.Pop());

        }

        [TestMethod]
        public void ArrayStackPeekTest()
        {
            //Arrange
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(11);
            arrayStack.Push(568);
            arrayStack.Push(3);

            //Act
            var onTop = arrayStack.Peek();

            //Assert
            Assert.AreEqual(3, onTop);
            arrayStack.Pop();
            Assert.AreEqual(568, arrayStack.Peek());

            arrayStack.Pop();
            arrayStack.Pop();
            Assert.ThrowsException<NullReferenceException>(() => arrayStack.Peek());

        }
    }
}
