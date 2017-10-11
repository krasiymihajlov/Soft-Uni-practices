namespace _03BarracksFactory.Core.Factories
{
    using System;
    using _03BarracksFactory.Contracts;
    using _03.BarrackWars___ANewFactory.Contracts;
    using System.Linq;
    using System.Reflection;
    using _03.BarrackWars___ANewFactory.Attributes;

    public class CommandFactory : ICommandFactory
    {
        public IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            string pathName = $"_03BarracksFactory.Core.Commands.{data[0].First().ToString().ToUpper()}{data[0].Substring(1)}Command";
            Type type = Type.GetType(pathName);

            var fields = type.GetFields()
                .Select(f => new
                {
                    Name = f.Name,
                    Attribute = f.GetCustomAttributes(false).Select(atr => (InjectionAttribute)atr).FirstOrDefault()
                })
                .Where(x => x.Attribute != null)
                .ToArray();

            object[] commandParams = new object[] { data, repository, unitFactory };           

            return (IExecutable)Activator.CreateInstance(type, commandParams);
        }
    }
}
