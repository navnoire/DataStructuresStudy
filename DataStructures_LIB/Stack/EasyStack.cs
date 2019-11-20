using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_LIB.Stack
{
    public class EasyStack<T> : ICloneable
    {
        private List<T> items = new List<T>();

        public bool IsEmpty => items.Count == 0;

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                var i = items.Last();
                items.RemoveAt(items.Count - 1);
                return i;
            }
            else
            {
                throw new InvalidOperationException("Attempt to get value from an empty stack.");
            }

        }

        public T Peek()
        {
            if (!IsEmpty)
            {
                return items.Last();
            }
            else
            {
                throw new InvalidOperationException("Attempt to get value from an empty stack.");
            }
        }

        public void Clear()
        {
            items.Clear();
        }

        public override string ToString()
        {
            return $"Stack {items.Count} elements long.";
        }

        public object Clone()
        {
            var newStack = new EasyStack<T>();
            newStack.items = new List<T>(items);
            return newStack;
        }
    }
}
