using System;
using System.Collections.Generic;

namespace DataStructures.LIB.HashTable
{
    public class HashTable<TKey, TValue>
    {
        private List<TValue>[] items;

        public HashTable(int size)
        {
            items = new List<TValue>[size];
        }

        public void Add(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (items[k] == null)
            {
                items[k] = new List<TValue>();
            }
            items[k].Add(value);
        }

        public bool Contains(TKey key, TValue value)
        {
            var k = GetHash(key);
            return items[k]?.Contains(value) ?? false;
        }

        public bool Contains(TKey key)
        {
            return items[GetHash(key)] != null;
        }

        private int GetHash(TKey key)
        {
            return key.ToString().Length % items.Length;
        }
    }
}
