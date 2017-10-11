namespace BashSoftProgram.Contracts.Repository.StudentsRepository
{
    using System.Collections.Generic;
    using BashSoftProgram.Contracts.DataStructures;

    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string userName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
