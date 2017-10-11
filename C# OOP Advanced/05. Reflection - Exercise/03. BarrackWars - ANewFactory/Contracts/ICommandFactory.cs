namespace _03.BarrackWars___ANewFactory.Contracts
{
    using _03BarracksFactory.Contracts;

    public interface ICommandFactory
    {
        IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory);
    }
}
