namespace _09.CollectionHierarchy.Collections
{
    using _09.CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class AddRemoveCollection<T> : IAddable<T>, IRemoveable<T>
    {
        private IList<T> collection;
        private IList<T> removeResult;

        public AddRemoveCollection()
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
            T remove = this.collection[this.collection.Count - 1];
            this.collection.Remove(this.collection[this.collection.Count - 1]);
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
