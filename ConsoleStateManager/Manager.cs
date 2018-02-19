using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateManager
{
    public class Manager
    {
        private IState State { get; set; }

        public Manager(IState state)
        {
            if (state is null)
                throw new NullReferenceException("The state cannot be null");

            State = state;
        }

        public string GetMassage()
        {
            return State.GetMassage();
        }

        public void HandleUserInput(string userInput)
        {
            State = State.GetNewState(userInput);
        }

        public bool IsFinished()
        {
            return State.IsFinished();
        }
    }
}
