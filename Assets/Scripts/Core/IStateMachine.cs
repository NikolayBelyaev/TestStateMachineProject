using System;

namespace Core
{
    public interface IStateMachine
    {
        IStateSequence StartSequence<T>() where T : IState;
    }
}