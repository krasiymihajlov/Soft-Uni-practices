namespace BashSoftProgram.Contracts.Repository.RepositoryFilter
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake);
    }
}
