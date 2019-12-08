using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LIB.MapDictionary
{
    public class Dictionary<TKey, TValue> : IEnumerable
    {
        private int size = 100;
        private Item<TKey, TValue>[] items;
        private List<TKey> keys = new List<TKey>();

        public Dictionary()
        {
            items = new Item<TKey, TValue>[size];
        }

        public Dictionary(int capacity)
        {
            size = capacity;
            items = new Item<TKey, TValue>[capacity];
        }

        public void Add(Item<TKey, TValue> item)
        {
            if (keys.Contains(item.Key))
            {
                return;
            }

            var hash = GetHash(item.Key);
            if (items[hash] == null)
            {
                keys.Add(item.Key);
                items[hash] = item;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item;
                        keys.Add(item.Key);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    for (int i = 0; i < hash; i++)
                    {
                        if (items[i] == null)
                        {
                            items[i] = item;
                            keys.Add(item.Key);
                            placed = true;
                            break;
                        }
                    }
                }

                if (!placed)
                {
                    throw new Exception("Dictionary is full. Can not add new Item " + item);
                }
            }
        }

        public void Remove(TKey key)
        {
            if (!keys.Contains(key))
            {
                return;
            }

            var hash = GetHash(key);
            if (items[hash] != null && items[hash].Key.Equals(key))
            {
                items[hash] = null;
                keys.Remove(key);
            }
            else
            {
                for (int i = hash + 1; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        return;
                    }

                    if (items[i].Key.Equals(key))
                    {
                        keys.Remove(key);
                        items[i] = null;
                        return;
                    }
                }

                for (int i = 0; i < hash; i++)
                {
                    if (items[i] == null)
                    {
                        return;
                    }

                    if (items[i].Key.Equals(key))
                    {
                        keys.Remove(key);
                        items[i] = null;
                        return;
                    }
                }
            }
        }

        public TValue GetValue(TKey key)
        {
            if (!keys.Contains(key))
            {
                return default;
            }

            var hash = GetHash(key);
            if (items[hash] != null && items[hash].Key.Equals(key))
            {
                return items[hash].Value;
            }

            for (int i = hash + 1; i < size; i++)
            {
                if (items[i] == null)
                {
                    return default(TValue);
                }

                if (items[i].Key.Equals(key))
                {
                    return items[i].Value;
                }
            }

            for (int i = 0; i < hash; i++)
            {
                if (items[i] == null)
                {
                    return default(TValue);
                }

                if (items[i].Key.Equals(key))
                {
                    return items[i].Value;
                }
            }
            throw new Exception("Element not found");
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
