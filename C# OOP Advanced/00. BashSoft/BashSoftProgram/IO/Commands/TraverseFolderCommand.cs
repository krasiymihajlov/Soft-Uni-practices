namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Contracts.Repository.StudentsRepository;
    using BashSoftProgram.Contracts.Tester;
    using BashSoftProgram.Exceptions;

    public class TraverseFolderCommand : Command, IExecutable
    {
        public TraverseFolderCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
            else 
            {
                int depth;
                var success = int.TryParse(this.Data[1], out depth);
                if (success)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidNumberParseException();
                }
            }
        }
    }
}
