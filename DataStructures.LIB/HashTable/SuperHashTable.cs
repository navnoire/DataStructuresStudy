using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LIB.HashTable
{
    public class SuperHashTable<T>
    {
        private Item<T>[] items;

        public SuperHashTable(int capacity)
        {
            items = new Item<T>[capacity];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }

        public void Add(T data)
        {
            var key = GetHash(data);
            items[key].Nodes.Add(data);
        }

        public bool Contains(T data)
        {
            var key = GetHash(data);
            return items[key]?.Nodes.Contains(data) ?? false;
        }

        public List<T> GetData(int key)
        {
            var index = key % items.Length;
            return items[index].Nodes;
        }

        private int GetHash(T item)
        {
            return item.GetHashCode() % items.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(nameof(items).ToUpper()).AppendLine();

            foreach (var item in items)
            {
                sb.AppendFormat($"{item.Key} : ({item.Nodes.Count}) : {item.ToString()}").AppendLine();
            }

            return sb.ToString();
        }
    }
}
