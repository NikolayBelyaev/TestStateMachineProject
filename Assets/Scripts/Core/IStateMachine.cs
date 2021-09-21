using System;

namespace Core
{
    public interface IStateMachine
    {
        IStateSequence StartSequence(Type type);
    }
}