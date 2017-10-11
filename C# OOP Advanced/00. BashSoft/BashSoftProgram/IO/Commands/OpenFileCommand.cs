namespace BashSoftProgram.IO.Commands
{
    using System.Diagnostics;
    using BashSoftProgram.StaticData;
    using Contracts;
    using Contracts.Repository.StudentsRepository;
    using Contracts.Tester;
    using Exceptions;
    
    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.CurrentPath + "\\" + fileName);
        }
    }
}
