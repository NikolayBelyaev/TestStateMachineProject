using System;

namespace Core
{
    public class StateMachine : IStateMachine, IDisposable
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
            var sequece = new StateSequence(this, _context);
            sequece.ActivateState(type);

            return sequece;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}