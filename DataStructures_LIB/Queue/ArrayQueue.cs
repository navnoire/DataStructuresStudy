using System;
namespace DataStructures_LIB.Queue
{
    public class ArrayQueue<T>
    {
        private readonly T[] items;
        private int index;

        public ArrayQueue(int capacity)
        {
            items = new T[capacity];
        }

        public ArrayQueue(int capacity, T firstElement) : this(capacity)
        {
            Enqueue(firstElement);
        }

        public void Enqueue(T data)
        {
            if (index < items.Length)
            {
                items[index] = data;
                index++;
            }
            else
            {
                throw new OverflowException("Queue is full.");
            }
        }

        public T Dequeue()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var result = items[0];
            for (int i = 0; i < index - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[index - 1] = default(T);
            index--;
            return result;

        }

        public T Peek()
        {
            return items[0];
        }
    }
}
