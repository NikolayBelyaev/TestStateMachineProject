using System;

namespace Core
{
    public class StateMachine : IStateMachine
    {
        private readonly IStateContext _context;

        public StateMachine(IStateContext context)
        {
            _context = context;
        }

        public static IStateMachine Create(IStateContext context)
        {
            return new StateMachine(context);
        }

        public IStateSequence StartSequence(Type type)
        {
            var sequence = new StateSequence(this, _context);
            sequence.ActivateState(type);

            return sequence;
        }
    }
}