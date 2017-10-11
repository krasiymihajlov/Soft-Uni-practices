namespace _03BarracksFactory.Core.Commands
{
    using _03.BarrackWars___ANewFactory.Attributes;
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        [Injection]
        private IRepository repository;

        [Injection]
        private IUnitFactory unitFactory;

        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }
        public IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            private set { this.unitFactory = value; }
        }


        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
