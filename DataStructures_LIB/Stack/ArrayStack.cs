using System;
namespace DataStructures_LIB.Stack
{
    public class ArrayStack<T>
    {
        public bool isEmpty => nextIndex == 0;

        T[] items;
        private int nextIndex;



        public ArrayStack(int capacity = 10)
        {
            items = new T[capacity];
            nextIndex = 0;
        }

        public ArrayStack(T data, int capacity = 10) : this(capacity)
        {
            items[nextIndex] = data;
            nextIndex++;
        }

        public void Push(T data)
        {
            if (nextIndex < items.Length)
            {
                items[nextIndex] = data;
                nextIndex++;
            }
            else
            {
                throw new StackOverflowException("The stack is full.");
            }
        }

        public T Pop()
        {
            if (!isEmpty)
            {
                nextIndex--;
                var item = items[nextIndex];
                items.SetValue(default(T), nextIndex);
                return item;
            }

            throw new NullReferenceException("Stack is empty.");

        }

        public T Peek()
        {
            if (!isEmpty)
            {
                return items[nextIndex - 1];
            }
            throw new NullReferenceException("Stack is empty");
        }
    }
}
