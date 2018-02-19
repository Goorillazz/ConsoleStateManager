namespace ConsoleStateManager
{
    public interface IState
    {
        string GetMassage();
        bool IsFinished();

        IState GetNewState(string userInput);
    }
}
