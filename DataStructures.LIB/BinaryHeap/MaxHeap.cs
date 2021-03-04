using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataStructures.LIB.BinaryHeap
{
    public class MaxHeap<T> where T : IComparable
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;

        public T PeekRoot()
        {
            if (Count > 0)
            {
                return items[0];
            }
            throw new IndexOutOfRangeException("Heap is empty");
        }

        public void Add(T item)
        {
            if (!typeof(T).IsValueType && item == null)
            {
                throw new ArgumentNullException(nameof(item), "Argument can not be null");
            }

            items.Add(item);
            Swap(items.Count - 1);

        }


        public T GetMax()
        {
            var max = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);

            Sort(0);
            return max;
        }

        private void Swap(int index)
        {
            var current = index;
            int parent = GetParentIndex(current);

            while (current > 0 && items[current].CompareTo(items[parent]) == 1)
            {
                var temp = items[current];
                items[current] = items[parent];
                items[parent] = temp;
                current = parent;
                parent = GetParentIndex(current);
            }
        }

        private void Sort(int currentIndex)
        {
            var current = currentIndex;
            var left = GetLeftChildIndex(current);
            var right = GetRightChildIndex(current);

            if (left >= Count)
            {
                return;
            }

            int maxChildIndex;
            if (right >= Count)
            {
                maxChildIndex = left;
            }
            else
            {
                maxChildIndex = items[left].CompareTo(items[right]) == 1 ? left : right;
            }

            if (items[current].CompareTo(items[maxChildIndex]) == -1)
            {
                var temp = items[maxChildIndex];
                items[maxChildIndex] = items[current];
                items[current] = temp;
                Sort(maxChildIndex);

            }
        }

        private int GetParentIndex(int current)
        {
            return (current - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(',', items);
            return sb.ToString();
        }
    }
}
