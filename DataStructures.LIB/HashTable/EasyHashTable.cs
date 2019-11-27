using System;
using System.Text;

namespace DataStructures.LIB.HashTable
{
    /// <summary>
    /// Easy impl. Сollisions are not correctly resolved.
    /// </summary>
    public class EasyHashTable<T>
    {
        public T[] items;

        public EasyHashTable(int size)
        {
            items = new T[size];
        }

        public void Add(T item)
        {
            var key = GetHash(item);
            items[key] = item;
        }

        public bool Contains(T item)
        {
            var key = GetHash(item);
            return items[key].Equals(item);
        }

        private int GetHash(T item)
        {
            return item.ToString().Length % items.Length;
        }

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();
            return sbuilder.AppendJoin(' ', items).ToString();
        }
    }
}
