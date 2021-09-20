namespace Core
{
    public interface IState
    {
        void Setup(IStateContext stateContext, IStateMachine stateMachine, IStateSequence sequence);
        void OnEnter();
        void OnExit();
    }
}