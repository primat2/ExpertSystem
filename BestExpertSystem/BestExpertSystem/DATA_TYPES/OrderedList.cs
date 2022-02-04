using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.DATA_TYPES
{
    public class OrderedList<T> : IEnumerable<T> where T : INFRASTRUCTURE.IOrdered
    {
        private List<T> values;

        public int Count
        {
            get { return values.Count; }
        }

        //public int Coun() => return values.Count;



        public OrderedList()
        {
            values = new List<T>();
        }

        public OrderedList(List<T> Values)
        {
            values = Values;
        }

        public T Add(T item)
        {
            item.Order = values.Count;
            values.Add(item);
            return item;
        }

        public T this[int index]
        {
            get { return values[index]; }
        }

        public INFRASTRUCTURE.IOrdered Find(Predicate<T> p)
        {
            foreach (var v in values)
            {
                if (p(v))
                {
                    return v;
                }
            }
            return null;
        }

        public void Insert(T item, int position)
        {
            if (values.ElementAtOrDefault(position) != null || position == values.Count)
            {
                values.Insert(position, item);
                item.Order = position;
                for (int i = position + 1; i < values.Count; i++)
                {
                    values[i].Order = i;// values[i].Order + 1;
                }
            }
        }

        public T RemoveAt(int position)
        {
            T deleted = default(T);
            if (values.ElementAtOrDefault(position) != null)
            {
                deleted = values[position];
                values.RemoveAt(position);

                for (int i = position; i < values.Count; i++)
                {
                    values[i].Order = i; // values[i].Order - 1;
                }
            }
            return deleted;
        }



        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
