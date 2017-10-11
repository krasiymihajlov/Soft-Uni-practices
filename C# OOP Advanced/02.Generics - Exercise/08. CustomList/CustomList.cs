namespace _08.CustomList
{
    using _08.CustomList.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>, IEnumerable<T>
    {
        private List<T> list;

        public CustomList() : this(new List<T>())
        {
        }

        public CustomList(List<T> element)
        {
            this.list = element;
        }

        public List<T> List
        {
            get { return this.list; }
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove(int index)
        {
            if (this.list.Count > index)
            {
                T element = this.list[index];
                this.list.RemoveAt(index);
                return element;
            }

            return default(T);
        }

        public bool Contains(T element)
        {
            if (this.list.Contains(element))
            {
                return true;
            }

            return false;
        }

        public void Swap(int index1, int index2)
        {
            if (this.list.Count <= index1 || this.list.Count <= index2)
            {
                return;
            }

            T swap = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = swap;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            for (int i = 0; i < this.list.Count; i++)
            {
                if (this.list[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            return this.list.Max();
        }

        public T Min()
        {
            return this.list.Min();
        }

        public string Print()
        {
            return $"{string.Join(Environment.NewLine, this.list)}";
        }
    }
}
