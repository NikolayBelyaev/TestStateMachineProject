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

        public void ActivateState<T> () where T : IState
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
                _currentState = null;
            }

            _currentState = Activator.CreateInstance(typeof(T)) as IState;
            if (_currentState == null)
            {
                throw new Exception($"Can't find state of type {typeof(T)}");
            }
            
            _currentState.Setup(_stateContext, _stateMachine, this);
            _currentState.OnEnter();
        }

    }
}