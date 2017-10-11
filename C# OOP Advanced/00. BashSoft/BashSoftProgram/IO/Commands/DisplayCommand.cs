namespace SimpleJudje.IO
{
    using System;
    using System.Collections.Generic;
    using BashSoftProgram;
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Contracts.DataStructures;
    using BashSoftProgram.Contracts.Repository.StudentsRepository;
    using BashSoftProgram.Contracts.Tester;
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.IO;
    using BashSoftProgram.IO.Commands;

    public class DisplayCommand : Command
    {
        public DisplayCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) 
            : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<IStudent> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<IStudent> list = this.Repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<ICourse> list = this.Repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((first, second) => first.CompareTo(second));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((first, second) => second.CompareTo(first));
            }

            throw new InvalidCommandException(this.Input);
        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((first, second) => first.CompareTo(second));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((first, second) => second.CompareTo(first));
            }

            throw new InvalidCommandException(this.Input);
        }
    }
}
