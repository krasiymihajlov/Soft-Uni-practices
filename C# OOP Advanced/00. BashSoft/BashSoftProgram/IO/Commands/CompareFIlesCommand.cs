namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Contracts.Repository.StudentsRepository;
    using BashSoftProgram.Contracts.Tester;
    using BashSoftProgram.Exceptions;

    public class CompareFIlesCommand : Command, IExecutable
    {
        public CompareFIlesCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.Judge.CompareContent(firstPath, secondPath);
        }
    }
}
