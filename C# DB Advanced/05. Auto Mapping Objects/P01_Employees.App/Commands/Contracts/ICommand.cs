namespace P01_Employees.App.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
