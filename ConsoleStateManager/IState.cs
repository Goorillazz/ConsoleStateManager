namespace ConsoleStateManager
{
    public interface IState
    {
        string GetMessage();
        bool IsFinished();

        IState GetNewState(string userInput);
    }
}
