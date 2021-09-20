using System;

namespace Core
{
    public interface IStateSequence
    {
        void ActivateState<T>() where T : IState;
    }
}