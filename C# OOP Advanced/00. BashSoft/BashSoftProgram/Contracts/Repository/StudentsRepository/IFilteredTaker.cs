namespace BashSoftProgram.Contracts.Repository.StudentsRepository
{
    public interface IFilteredTaker
    {
        void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null);
    }
}
