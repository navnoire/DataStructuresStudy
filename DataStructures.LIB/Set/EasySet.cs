using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.LIB.LinkedList;

namespace DataStructures.LIB.Set
{
    public class EasySet<T>
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;

        public EasySet() { }

        public EasySet(T data)
        {
            if (typeof(T).IsValueType || data != null)
            {
                items.Add(data);
            }
        }

        public EasySet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public void Add(T data)
        {
            if (!items.Contains(data))
            {
                items.Add(data);
            }
        }

        public void Remove(T data)
        {
            items.Remove(data);
        }

        public EasySet<T> Union(EasySet<T> set)
        {
            //Linq - 
            //return new EasySet<T>(items.Union(set.items));

            //Long way
            var result = new EasySet<T>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            foreach (var item in set.items)
            {
                result.Add(item);
            }

            return result;
        }

        public EasySet<T> Intersect(EasySet<T> set)
        {
            //Linq
            //return new EasySet<T>(items.Intersect(set.items));

            //Long Way
            var result = new EasySet<T>();
            EasySet<T> big;
            EasySet<T> small;

            if (Count >= set.Count)
            {
                big = this;
                small = set;
            }
            else
            {
                big = set;
                small = this;
            }

            //кооличество операций будет по наименьшему множеству, небольшой прирост производительности.
            foreach (var item in small.items)
            {
                if (big.items.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public EasySet<T> Difference(EasySet<T> set)
        {
            //Linq
            //return new EasySet<T>(items.Except(set.items));

            var result = new EasySet<T>(items);
            foreach (var item in set.items)
            {
                result.Remove(item);
            }
            return result;
        }

        public bool IsSubset(EasySet<T> set)
        {
            //Linq
            //return items.All(i => set.items.Contains(i));

            foreach (var item in items)
            {
                if (!set.items.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

        public EasySet<T> SymmetricDifference(EasySet<T> set)
        {
            //Linq
            //return new EasySet<T>(items.Except(set.items).Union(set.items.Except(items)));

            var result = new EasySet<T>(items);
            foreach (var item in set.items)
            {
                if (!result.items.Contains(item))
                {
                    result.Add(item);
                }
                else
                {
                    result.Remove(item);
                }

            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();
            foreach (var item in items)
            {
                sbuilder.Append(item + " ");
            }
            return sbuilder.ToString();
        }
    }
}
