namespace BashSoftProgram.IO
{
    using System;
    using Contracts;
    using Contracts.Repository.StudentsRepository;
    using Contracts.Tester;
    using Exceptions;
    using IO.Commands;
    using SimpleJudje.IO;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFolderCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFIlesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdrel":
                    return new ChangePathRelativelyCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdabs":
                    return new ChangePathAbsoluteCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readdb":
                    return new ReadDatabaseFromFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new FilterAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new OrderAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);                
                case "show":
                    return new ShowWantedDataCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DrobDbCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "display":
                    return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                ////case "decOrder":
                ////    TryDecOrderAndTake(input, data);
                ////    break;
                ////case "download":
                ////    break;
                ////case "downloadAsynch":
                ////    break;

                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
