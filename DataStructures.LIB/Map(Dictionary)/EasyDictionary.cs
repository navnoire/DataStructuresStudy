using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.LIB.MapDictionary
{
    /// <summary>
    /// Easy dictionary on List<T>. Not optimal search
    /// </summary>
    public class EasyDictionary<TKey, TValue>
    {
        private List<Item<TKey, TValue>> items = new List<Item<TKey, TValue>>();
        private List<TKey> keys = new List<TKey>();



        public void Add(Item<TKey, TValue> item)
        {
            if (!keys.Contains(item.Key))
            {
                keys.Add(item.Key);
                items.Add(item);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public TValue GetValue(TKey key)
        {
            if (keys.Contains(key))
            {
                return items.Single(i => i.Key.Equals(key)).Value;
            }
            return default(TValue);
        }

        public void Remove(TKey key)
        {
            if (keys.Contains(key))
            {
                keys.Remove(key);
                items.Remove(items.Single(i => i.Key.Equals(key)));
            }
        }
    }
}
