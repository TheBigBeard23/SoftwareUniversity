namespace CommandPattern.Core.Contracts
{
    public interface ICommandFactoy
    {
        ICommand CreateCommand(string commandType); 
    }
}
