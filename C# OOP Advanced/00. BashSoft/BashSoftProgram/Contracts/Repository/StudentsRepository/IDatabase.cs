namespace BashSoftProgram.Contracts.Repository.StudentsRepository
{
    public interface IDatabase : IFilteredTaker, IRequester, IOrderedTaker
    {
        void LoadData(string fileName);

        void UnloadData();
    }
}
