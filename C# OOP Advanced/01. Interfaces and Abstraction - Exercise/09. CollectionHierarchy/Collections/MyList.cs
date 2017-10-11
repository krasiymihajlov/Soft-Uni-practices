namespace _09.CollectionHierarchy.Collections
{
    using System;
    using _09.CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class MyList<T> : IAddable<T>, IRemoveable<T>
    {
        private IList<T> collection;
        private IList<T> removeResult;

        public MyList()
        {
            this.collection = new List<T>();
            this.removeResult = new List<T>();
        }

        public void Add(T element)
        {
            this.collection.Insert(0, element);
        }

        public void Remove()
        {
            T remove = this.collection[0];
            this.collection.RemoveAt(0);
            removeResult.Add(remove);
        }

        public string RemoveCollection(int removeElement)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < removeElement; i++)
            {
                sb.Append(removeResult[i]).Append(" ");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.collection.Count; i++)
            {
                sb.Append(0).Append(" ");
            }

            return sb.ToString();
        }
    }
}
