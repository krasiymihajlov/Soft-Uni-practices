namespace BashSoftProgram.IO.Commands
{
    using System;
    using Contracts;
    using Contracts.Repository.StudentsRepository;
    using Contracts.Tester;
    using Exceptions;
    
    public abstract class Command : IExecutable
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;
        private string input;
        private string[] data;

        public Command(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.input = input;
            this.data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public string Input
        {
            get
            {
                return this.input;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected IContentComparer Judge
        {
            get { return this.judge; }
        }

        protected IDatabase Repository
        {
            get { return this.repository; }
        }

        protected IDirectoryManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        public abstract void Execute();
    }
}
