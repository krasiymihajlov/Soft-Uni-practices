namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Contracts.Repository.StudentsRepository;
    using BashSoftProgram.Contracts.Tester;
    using BashSoftProgram.Exceptions;

    public class ShowWantedDataCommand : Command, IExecutable
    {
        public ShowWantedDataCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2 && this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else 
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
        }
    }
}
