using System;
using Core;
using Services;
using UnityEngine;

public class QuestStepActivatorService : MonoBehaviour
{
    public static GameStepModel CurrentStep;

    private static IStateMachine _gameStateMachine;

    public static GameStepModel NextStep
    {
        get
        {
            var nextIndex = GameScenarioService.GameSteps.IndexOf(CurrentStep) + 1;
            return nextIndex == GameScenarioService.GameSteps.Count ? null : GameScenarioService.GameSteps[nextIndex];
        }
    }
    
    private static string TargetType => $"Quest{CurrentStep.Quest_ID}.Quest{CurrentStep.Quest_ID}State{CurrentStep.Step_ID}";

    private static Type CreateStateType()
    {
        var stateType = Type.GetType(TargetType);
        
        if ( stateType == null || !typeof(IState).IsAssignableFrom( stateType))
        {
            throw new ArgumentException($"Wrong type { stateType?.FullName}. Type must implements IState");
        }

        return stateType;
    }
    
    public static void CreateStateMachine()
    {
        var cs = FindObjectOfType<CoroutineService>();
        var view = FindObjectOfType<QuestView>();
        
        _gameStateMachine = StateMachine.Create(new QuestContext(GameScenarioService.GameSteps, view, cs));
        CurrentStep = GameScenarioService.GameSteps[0];
        
        _gameStateMachine.StartSequence(CreateStateType());
    }

    public static void ActivateNext(IStateSequence sequence)
    {
        if (NextStep == null)
        {
            Debug.Log("END OF GAME SEQUENCE");
            return;
        }

        CurrentStep = NextStep;
        
        sequence.ActivateState(CreateStateType());
    }
}
