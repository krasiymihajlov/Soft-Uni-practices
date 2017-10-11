namespace _09.CollectionHierarchy.Collections
{
    using System;
    using _09.CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class AddCollection<T> : IAddable<T>
    {
        private IList<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public void Add(T element)
        {
            this.collection.Add(element);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.collection.Count; i++)
            {
                sb.Append(i).Append(" ");
            }

            return sb.ToString();
        }
    }
}
