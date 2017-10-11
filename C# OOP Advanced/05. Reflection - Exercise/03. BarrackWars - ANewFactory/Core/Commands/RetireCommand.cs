namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;
    using _03.BarrackWars___ANewFactory.Attributes;

    public class RetireCommand : Command
    {
        [Injection]
        private IRepository repository;

        [Injection]
        private IUnitFactory unitFactory;

        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
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
            string report = $"{this.Data[1]} retired!";

            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
            }
            catch (Exception e)
            {
                report = e.Message;
            }

            return report;
        }
    }
}
