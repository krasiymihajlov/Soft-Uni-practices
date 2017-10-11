namespace _09.CollectionHierarchy.Interfaces
{
    public interface IRemoveable<T>
    {
        void Remove();

        string RemoveCollection(int removeElement);
    }
}
