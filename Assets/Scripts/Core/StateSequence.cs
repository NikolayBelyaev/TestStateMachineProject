using System;

namespace Core
{
    public class StateSequence : IStateSequence
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStateContext _stateContext;

        private IState _currentState;

        public StateSequence(IStateMachine stateMachine, IStateContext stateContext)
        {
            _stateMachine = stateMachine;
            _stateContext = stateContext;
        }

        public void ActivateState(Type type)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
                _currentState = null;
            }

            _currentState = Activator.CreateInstance(type) as IState;
            if (_currentState == null)
            {
                throw new Exception($"Can't find state of type {type.FullName}");
            }
            
            _currentState.Setup(_stateContext, _stateMachine, this);
            _currentState.OnEnter();
        }

    }
}