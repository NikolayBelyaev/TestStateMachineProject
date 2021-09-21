using System;

namespace Core
{
    public interface IStateSequence
    {
        void ActivateState(Type type);
    }
}