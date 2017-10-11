namespace BashSoftProgram.Contracts.Repository.StudentsRepository
{
    public interface IOrderedTaker
    {
        void OrderAndTake(string courseName, string comparision, int? studentsToTake = null);
    }
}
